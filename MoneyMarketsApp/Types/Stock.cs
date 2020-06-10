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
        
        public Stock()
        {
            Ticker = "";
            Price = "";
        }
    }
}
