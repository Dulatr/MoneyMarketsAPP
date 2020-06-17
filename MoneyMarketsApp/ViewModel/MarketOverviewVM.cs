﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.IO;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System.Windows;
using MoneyMarketsApp.Types;

namespace MoneyMarketsApp.ViewModel
{
    public class MarketOverviewVM : ViewModelBase
    {
        public MarketOverviewVM()
        {
            collect_data_background();
        }   
        
        private async void collect_data_background()
        {
            string stdout;

            using (Process money = new Process())
            {
                money.StartInfo.UseShellExecute = false;
                money.StartInfo.CreateNoWindow = true;
                money.StartInfo.RedirectStandardError = true;
                money.StartInfo.RedirectStandardOutput = true;
                string path_variable = Environment.GetEnvironmentVariable("MONEY_MARKETS");
                Console.WriteLine(path_variable);
                money.StartInfo.FileName = path_variable + "/money.exe";
                money.StartInfo.Arguments = "stock --overview";
                money.Start();
                stdout = await money.StandardOutput.ReadToEndAsync();
            
                ParseData(stdout);

            }
        }

        private void ParseData(string response)
        {
            var data = JsonConvert.DeserializeObject<JsonData>(response);
            
            DOWPoints = data.overview["Dow"][0];
            NASDAQPoints = data.overview["Nasdaq"][0];
            SPPoints = data.overview["S&P"][0];

            DOWPercentChange = data.overview["Dow"][1];
            NASDAQPercentChange = data.overview["Nasdaq"][1];
            SPPercentChange = data.overview["S&P"][1];

            DOWPointChange = data.overview["Dow"][2];
            NASDAQPointChange = data.overview["Nasdaq"][2];
            SPPointChange = data.overview["S&P"][2];

        }

        public string[] tableData;
        public string[] TableData
        {
            get
            {
                return tableData;
            }
            set
            {
                tableData = value;
                RaisePropertyChanged("TableData");
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
        #region Point Change Data
        private string dowPtChange;
        public string DOWPointChange
        {
            get => dowPtChange;
            set
            {
                dowPtChange = value;
                RaisePropertyChanged("DOWPointChange");
            }
        }
        private string nasPtChange;
        public string NASDAQPointChange
        {
            get => nasPtChange;
            set
            {
                nasPtChange = value;
                RaisePropertyChanged("NASDAQPointChange");
            }
        }
        private string spPtChange;
        public string SPPointChange
        {
            get => spPtChange;
            set
            {
                spPtChange = value;
                RaisePropertyChanged("SPPointChange");
            }
        }
        #endregion
        #region ToolTips
        public string PointsToolTip
        {
            get => "Current index price in points.";
        }
        public string PointChangeToolTip
        {
            get => "Total change from market open.";
        }
        public string PercentToolTip
        {
            get => "Percentage change in points since market open";
        }
        #endregion
    }
}
