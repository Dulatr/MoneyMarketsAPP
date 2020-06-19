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
        public TabViewVM()
        {
            Scheduler.Instance.ClockFinished += OnClockFinish;
        }

        public void OnClockFinish(object sender, TimeEventArgs e)
        {
            LastUpdate = e.Time.ToString();
        }

        #region Tooltips
        public string ProgStatusToolTip
        {
            get
            {
                if (ProgStatus is "Disconnected")
                {
                    return "CNN Money Markets information is unavailable at this time.\n\nCheck that you have internet connection or that MoneyMarketsCLI tools are installed.";
                }
                return "Currently updating info from CNN Money Markets";
            }
        }
        public string MarketStatusToolTip
        {
            get
            {
                if (MarketStatus is "Closed")
                {
                    return "Your local stock exchanges are closed for the day.";
                }
                return "Your local stock exchanges are currently open.";
            }
        }
        #endregion

        #region  Status bindings
        public string ProgStatus
        {
            get => "Disconnected";
        }
        private string lastUpdate;
        public string LastUpdate
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
        #endregion
    }

}
