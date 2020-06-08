using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MoneyMarketsApp.Types
{
    public class JsonData: Dictionary<string,string[]>
    {
        public JsonData() : base() { }

        public string[] DOW { get; set; }
        public string[] NASDAQ { get; set; }
        public string[] SP { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
