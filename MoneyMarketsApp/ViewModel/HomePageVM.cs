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
            Scheduler.Instance.ProcessFinished += ParseData;
        }

        private void ParseData(object sender, DataReceivedEventArgs e)
        {
            var proccess = (Process)sender;
            string argument = proccess.StartInfo.Arguments.Split()[1];
            if (argument != "story")
            {
                return;
            }
                
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
