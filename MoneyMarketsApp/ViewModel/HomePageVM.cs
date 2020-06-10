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
        public HomePageVM()
        {
            homeStories = new List<NewsStories>();
            homeStories.Add(new NewsStories() { title = "Story 1", path= "C:/Users/Tyler Dula/Documents/Temporary/img/2.PNG"});
            homeStories.Add(new NewsStories() { title="Story 2", path= "C:/Users/Tyler Dula/Documents/Temporary/img/bro.PNG" });
        }

        public List<NewsStories> homeStories;
        public List<NewsStories> HomeStories
        {
            get => homeStories;
        }
    }

}
