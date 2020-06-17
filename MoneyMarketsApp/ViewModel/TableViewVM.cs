using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MoneyMarketsApp.Views.TableViews;
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
            dowTable = new List<Stock>();
            nasTable = new List<Stock>();
            spTable = new List<Stock>();

            NotBusy = false;
            foreach (string selection in TableOptions)
            {
                collect_data_background(selection);
            }
        }

        public void collect_data_background(string tableName)
        {
            if (tableName == "S&P 500")
            {
                tableName = "sandp";
            }
            NotBusy = false;
            using (Process money = new Process())
            {
                money.StartInfo.UseShellExecute = false;
                money.StartInfo.CreateNoWindow = true;
                money.StartInfo.RedirectStandardError = true;
                money.StartInfo.RedirectStandardOutput = true;

                string path_variable = Environment.GetEnvironmentVariable("MONEY_MARKETS");
                money.StartInfo.FileName = path_variable + "/money.exe";
                money.StartInfo.Arguments = string.Format("stock --US {0}",tableName);

                money.Start();
                money.BeginOutputReadLine();
                money.OutputDataReceived += money_OutputDataReceived;
            }
        }

        private void money_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var proccess = (Process)sender;
            string argument = proccess.StartInfo.Arguments.Split()[2];
            string toTable = (argument == "sandp") ? "S&P 500" : argument;

            List<Stock> stockList;
            switch (toTable)
            {
                case "NASDAQ":
                    stockList = nasTable;
                    break;
                case "S&P 500":
                    stockList = spTable;
                    break;
                default:
                    stockList = dowTable;
                    break;

            }
            JsonData _temp_data = new JsonData();
            Dictionary<string, string[]> keystats = new Dictionary<string, string[]>();
            try
            {
                _temp_data = JsonConvert.DeserializeObject<JsonData>(e.Data);
                keystats = _temp_data.tables[argument];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (string key in keystats.Keys)
            {
                try
                {
                    if (key != "Company")
                    {
                        stockList.Add(new Stock()
                        {
                            Ticker = key,
                            Price = keystats[key][0],
                            Change = keystats[key][1],
                            PctChange = keystats[key][2],
                            Vol = keystats[key][3],
                            YTD = keystats[key][4],
                        });
                    }
                }
                catch
                {
                    if (key != "Company")
                    {
                        stockList.Add(new Stock()
                        {
                            Ticker = key,
                            Price = keystats[key][0],
                        });
                    }
                }
                    
            }
            Data = stockList;
            NotBusy = true;
        }

        private bool notBusy;
        public bool NotBusy
        {
            get => notBusy;
            set
            {
                notBusy = value;
                RaisePropertyChanged("NotBusy");
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
                switch (value)
                {
                    case "NASDAQ":
                        Data = nasTable;
                        break;
                    case "S&P 500":
                        Data = spTable;
                        break;
                    default:
                        Data = dowTable;
                        break;
                }
                RaisePropertyChanged("CurrentTableSelection");
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

        private List<Stock> dowTable;
        public List<Stock> DowTable
        {
            get => dowTable;
            set
            {
                dowTable = value;
                RaisePropertyChanged("DowTable");
            }
        }
        private List<Stock> nasTable;
        public List<Stock> NasTable
        {
            get => nasTable;
            set
            {
                nasTable = value;
                RaisePropertyChanged("NasTable");
            }
        }
        private List<Stock> spTable;
        public List<Stock> SPTable
        {
            get => spTable;
            set
            {
                spTable = value;
                RaisePropertyChanged("SPTable");
            }
        }
    }
}
