using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMarketsApp.Types;

namespace MoneyMarketsApp.ViewModel
{
    public class HomePageVM : ViewModelBase
    {

        public List<NewsStories> HomeStories
        {
            get
            {
                // check for available data here:> Populate list of stories to display:> Display them
                List<NewsStories> stories = new List<NewsStories>();
                stories.Add(new NewsStories());
                stories.Add(new NewsStories());
                int storycount = 0;
                foreach (NewsStories story in stories){
                    storycount++;
                    story.title = String.Format("Story {0}",storycount); 
                }
                return stories;
            }
        }
    }

}
