using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MoneyMarketsApp.Types
{
    public class JsonData
    {
        public Dictionary<string, string[]> overview { get; set; }
        public Dictionary<string,Dictionary<string,string[]>> tables { get; set; }
        public string lastUpdated { get; set; }
    }
}
