using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MoneyMarketsApp.Types
{

    public class Story
    {
        public string title { get; set; }
        public string path{ get; set; }
        public string web_link { get; set; }
        public string img_link { get; set; }
    }

    public class StoryCollection : JsonData
    {
        public Dictionary<string, Dictionary<string, Dictionary<string,string>>> stories { get; set; }
    }
}
