using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMarketsApp.Types
{
    public class Stock
    {
        public string Ticker { get; set; }
        public string Price { get; set; }
        public string Change { get; set; }
        public string PctChange { get; set; }
        public string Vol { get; set; }
        public string YTD { get; set; }
    }
}
