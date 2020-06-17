using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMarketsApp.Types;

namespace MoneyMarketsApp.ViewModel
{
    public class HomePageVM : ViewModelBase
    {
        public HomePageVM()
        {
            homeStories = new List<Story>();
            collect_data_background();
            //homeStories.Add(new NewsStories() { title = "Story 1", path= "C:/Users/Tyler Dula/Documents/Temporary/img/2.PNG"});
            //homeStories.Add(new NewsStories() { title="Story 2", path= "C:/Users/Tyler Dula/Documents/Temporary/img/bro.PNG" });
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
                money.Start();
                money.BeginOutputReadLine();
                money.OutputDataReceived += ParseData;
            }
        }
        private void ParseData(object sender, DataReceivedEventArgs e)
        {
            StoryCollection stories;
            try
            {
                stories = JsonConvert.DeserializeObject<StoryCollection>(e.Data);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            foreach (string page in stories.stories.Keys)
            {
                foreach(string story in stories.stories[page].Keys)
                {
                    homeStories.Add(new Story() {
                        title = stories.stories[page][story]["title"],
                        path = stories.stories[page][story]["path"],
                    });
                }

            }
            HomeStories = homeStories;
        }
        public List<Story> homeStories;
        public List<Story> HomeStories
        {
            get => homeStories;
            set
            {
                homeStories = value;
                RaisePropertyChanged("HomeStories");
            }
        }
    }

}
