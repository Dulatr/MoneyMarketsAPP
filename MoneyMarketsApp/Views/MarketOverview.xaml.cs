using MoneyMarketsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyMarketsApp.Views
{
    /// <summary>
    /// Interaction logic for MarketOverview.xaml
    /// </summary>
    public partial class MarketOverview : UserControl
    {
        public MarketOverview()
        {
            InitializeComponent();
            DataContext = new MarketOverviewVM();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            int index;
            if (obj.Name is "DOWButtonHeader"){
                index = 0;
            }
            else if (obj.Name is "NASButtonHeader")
            {
                index = 1;
            }
            else
            {
                index = 2;
            }
            TableHome.TableSelection.SelectedValue = TableHome.TableSelection.Items[index];
        }
    }
}
