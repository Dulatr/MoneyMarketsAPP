using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMarketsApp.ViewModel
{
    public class Scheduler
    {
        public delegate void TimeHandler(object sender, TimeEventArgs e);
        public delegate void ProcessHandler(object sender, DataReceivedEventArgs e);
        public event ProcessHandler ProcessFinised;
        public event TimeHandler ClockFinished;

        public async void runClock()
        {
            while (true)
            {
                await Task.Delay(1000);
                ClockFinished(this, new TimeEventArgs());
            }
        }
    }
    public class TimeEventArgs : EventArgs
    {
        public DateTime Time { get; }
        public TimeEventArgs()
        {
            Time = DateTime.Now;
        }
    }
}
