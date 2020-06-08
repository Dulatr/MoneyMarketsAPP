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

        private async Task<DateTime> checkTime()
        {
            await Task.Delay(1000);
            
            return System.DateTime.Now; 
        }

        private async void setTime()
        {
            while (true)
            {
                DateTime time = await checkTime();
                LastUpdate = time.ToString();
            }

        }

        public void run()
        {
            setTime();
        }

        public String ProgStatus
        {
            get => "Program Connected";
        }

        private string lastUpdate;
        public String LastUpdate
        {
            get {
                return lastUpdate;
            }
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
