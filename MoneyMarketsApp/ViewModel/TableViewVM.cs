using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using MoneyMarketsApp.Types;

namespace MoneyMarketsApp.ViewModel
{
    public class TableViewVM : ViewModelBase
    {
        public TableViewVM()
        {
            currentSelection = TableOptions[0];
            data = new List<Stock>();
            data.Add(new Stock() { Price = "12", Ticker = "AAPL" });
            data.Add(new Stock() { Price = "15", Ticker = "MMM" });
        }

        public List<string> TableOptions
        {
            get
            {
                return new List<string>() { "DOW", "NASDAQ", "S&P 500" };
            }
        }
        private string currentSelection;
        public string CurrentTableSelection
        {
            get => currentSelection;
            set
            {
                currentSelection = value;
                RaisePropertyChanged("CurrentTableSelection");
                RaisePropertyChanged("Data");
            }
        }

        private List<Stock> data; 
        public List<Stock> Data
        {
            get => data;
            set
            {
                data = value;
                RaisePropertyChanged("data");
            }
        }
    }
}
