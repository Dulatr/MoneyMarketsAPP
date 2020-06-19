using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMarketsApp.ViewModel
{
    public sealed class Scheduler
    {
        public delegate void TimeHandler(object sender, TimeEventArgs e);
        public delegate void ProcessHandler(object sender, DataReceivedEventArgs e);
        public event ProcessHandler ProcessFinished;
        public event TimeHandler ClockFinished;
        
        //Singleton
        private static readonly object padlock = new object();
        private static Scheduler instance;
        public static Scheduler Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Scheduler();
                    }
                    return instance;
                }
            }
        }

        protected Scheduler()
        {
            runClock();
            collect_data_background();
        }

        private async void runClock()
        {
            while (true)
            {
                await Task.Delay(1000);
                ClockFinished(this, new TimeEventArgs(null));
            }
        }

        private void collect_data_background()
        {
            using (Process money = new Process())
            {
                money.StartInfo.UseShellExecute = false;
                money.StartInfo.CreateNoWindow = true;
                money.StartInfo.RedirectStandardError = true;
                money.StartInfo.RedirectStandardOutput = true;
                string path_variable = Environment.GetEnvironmentVariable("MONEY_MARKETS");
                Console.WriteLine(path_variable);
                money.StartInfo.FileName = path_variable + "/money.exe";
                money.StartInfo.Arguments = "-i story --front-page";
                money.OutputDataReceived += sendData;
                money.Start();
                money.BeginOutputReadLine();
            }
            using (Process money = new Process())
            {
                {
                    money.StartInfo.UseShellExecute = false;
                    money.StartInfo.CreateNoWindow = true;
                    money.StartInfo.RedirectStandardError = true;
                    money.StartInfo.RedirectStandardOutput = true;
                    string path_variable = Environment.GetEnvironmentVariable("MONEY_MARKETS");
                    money.StartInfo.FileName = path_variable + "/money.exe";
                    money.StartInfo.Arguments = "stock --overview";
                    money.Start();
                    money.BeginOutputReadLine();
                    money.OutputDataReceived += sendData;
                }
            }
            foreach (string selection in new List<string>() { "DOW", "NASDAQ", "S&P 500" })
            {
                string tableName;

                if (selection == "S&P 500")
                {
                    tableName = "sandp";
                }
                else
                {
                    tableName = selection;
                }
                using (Process money = new Process())
                {
                    money.StartInfo.UseShellExecute = false;
                    money.StartInfo.CreateNoWindow = true;
                    money.StartInfo.RedirectStandardError = true;
                    money.StartInfo.RedirectStandardOutput = true;

                    string path_variable = Environment.GetEnvironmentVariable("MONEY_MARKETS");
                    money.StartInfo.FileName = path_variable + "/money.exe";
                    money.StartInfo.Arguments = string.Format("stock --US {0}", tableName);

                    money.Start();
                    money.BeginOutputReadLine();
                    money.OutputDataReceived += sendData;
                }
            }
        }

        private void sendData(object sender, DataReceivedEventArgs e)
        {
            ProcessFinished(sender,e);
        }
    }

    public class TimeEventArgs : EventArgs
    {
        public DateTime Time { get; }
        public string Data { get; set; }
        public TimeEventArgs(string data)
        {
            Time = DateTime.Now;
            Data = string.IsNullOrEmpty(data) ? "" : data ;
        }
    }
}
