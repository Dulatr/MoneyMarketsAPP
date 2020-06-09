using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace MoneyMarketsApp.ViewModel
{
    public class MarketOverviewVM : ViewModelBase
    {
        public MarketOverviewVM()
        {
            readJson();
        }   
        
        private async void readJson()
        {
            using (StreamReader sr = new StreamReader(@"F://ExternalCoderProjects/Python/MM_App/MoneyMarketsCLI/data/market_overview.json"))
            {
                string content = await sr.ReadToEndAsync();

                Dictionary<string, string[]> data = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(content);

                DOWPoints = data["Dow"][0];
                NASDAQPoints = data["Nasdaq"][0];
                SPPoints = data["S&P"][0];

                DOWPercentChange = data["Dow"][1];
                NASDAQPercentChange = data["Nasdaq"][1];
                SPPercentChange = data["S&P"][1];


            }
        }

        #region Points Data
        private string dowPoints;
        public string DOWPoints
        {
            get => dowPoints;
            set
            {
                dowPoints = value;
                RaisePropertyChanged("DOWPoints");
            }
        }
        private string nasPoints;
        public string NASDAQPoints
        {
            get => nasPoints;
            set
            {
                nasPoints = value;
                RaisePropertyChanged("NASDAQPoints");
            }
        }
        private string spPoints;
        public string SPPoints
        {
            get => spPoints;
            set
            {
                spPoints = value;
                RaisePropertyChanged("SPPoints");
            }
        }
        #endregion
        #region Percent Change Data
        private string dowPctChange;
        public string DOWPercentChange
        {
            get => dowPctChange;
            set
            {
                dowPctChange = value;
                RaisePropertyChanged("DOWPercentChange");
            }
        }
        private string nasPctChange;
        public string NASDAQPercentChange
        {
            get => nasPctChange;
            set
            {
                nasPctChange = value;
                RaisePropertyChanged("NASDAQPercentChange");
            }
        }
        private string spPctChange;
        public string SPPercentChange
        {
            get => spPctChange;
            set
            {
                spPctChange = value;
                RaisePropertyChanged("SPPercentChange");
            }
        }
        #endregion

    }
}
