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
                LastUpdate = time.ToString();
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
        public String LastUpdate
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
