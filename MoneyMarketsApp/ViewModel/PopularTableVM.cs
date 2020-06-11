using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MoneyMarketsApp.Types;

namespace MoneyMarketsApp.ViewModel
{
    public class PopularTableVM : ViewModelBase
    {
        public PopularTableVM()
        {
            losers = new List<Stock>();
            gainers = new List<Stock>();
            mostActive = new List<Stock>();

            losers.Add(new Stock() { Ticker = "CRON", Price = "5.88" });
            gainers.Add(new Stock() { Ticker = "AAPL", Price = "322" });
            mostActive.Add(new Stock() { Ticker = "F", Price = "8.00" });
        }

        private List<Stock> mostActive;
        public List<Stock> MostActiveData
        {
            get => mostActive;
            set
            {
                mostActive = value;
                RaisePropertyChanged("MostActiveData");
            }
        }
        private List<Stock> gainers;
        public List<Stock> GainersData
        {
            get => gainers;
            set
            {
                gainers = value;
                RaisePropertyChanged("GainersData");
            }
        }
        private List<Stock> losers;
        public List<Stock> LosersData
        {
            get => losers;
            set
            {
                losers = value;
                RaisePropertyChanged("LosersData");
            }
        }
    }
}
