using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using MoneyMarketsApp.Types;

namespace MoneyMarketsApp.ViewModel
{
    public class TableViewVM : ViewModelBase
    {
        public TableViewVM()
        {
            currentSelection = TableOptions[0];
            data = new List<Stock>();
            collect_data_background();
            
        }

        public async void collect_data_background()
        {
            string stdout;
            using (Process money = new Process())
            {
                money.StartInfo.UseShellExecute = false;
                money.StartInfo.CreateNoWindow = true;
                money.StartInfo.RedirectStandardError = true;
                money.StartInfo.RedirectStandardOutput = true;
                string path_variable = Environment.GetEnvironmentVariable("MONEY_MARKETS");
                money.StartInfo.FileName = path_variable + "/money.exe";
                money.StartInfo.Arguments = "stock --key-stats";
                money.Start();
                stdout = await money.StandardOutput.ReadToEndAsync();

                ParseData(stdout);
            }
        }

        public void ParseData(string response)
        {

            JsonData _temp_data = JsonConvert.DeserializeObject<JsonData>(response);
            Dictionary<string, string[]> keystats = _temp_data.tables["keystats"];
            foreach (string key in keystats.Keys)
            {
                if (key != "Company")
                {
                    data.Add(new Stock()
                    {
                        Ticker = key,
                        Price = _temp_data.tables["keystats"][key][0],
                        Change = _temp_data.tables["keystats"][key][1],
                        PctChange = _temp_data.tables["keystats"][key][2],
                        Vol = _temp_data.tables["keystats"][key][3],
                        YTD = _temp_data.tables["keystats"][key][4],
                    });
                }
            }
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
