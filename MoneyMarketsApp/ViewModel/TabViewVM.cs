using GalaSoft.MvvmLight;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMarketsApp.ViewModel
{
    public class TabViewVM : ViewModelBase
    {

        private async Task<DateTime> setTime()
        {
            while (true)
            {
                await Task.Delay(1000);
                DateTime time = DateTime.Now;
                LastUpdate = String.Format("{0}:{1}:{2}",time.Hour,time.Minute,time.Second);
            }

        }

        public void run()
        {
            var task = setTime();
        }

        public String ProgStatus
        {
            get => "Program Connected";
        }

        private string lastUpdate;
        public string LastUpdate
        {
            get => lastUpdate;

            set
            {
                lastUpdate = value;
                RaisePropertyChanged("LastUpdate");
            }
        }

        public String MarketStatus
        {
            get => "Closed";
        }
    }
}
