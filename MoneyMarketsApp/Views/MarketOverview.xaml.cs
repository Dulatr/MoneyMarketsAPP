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
            
            for (int i = 1; i < DOW30Table.RowDefinitions.Count; i++)
            {
                Button bttn = new Button();
           
                bttn.Name = String.Format("Ticker{0}", i);
                
                bttn.HorizontalAlignment = HorizontalAlignment.Stretch;
                bttn.VerticalAlignment = VerticalAlignment.Stretch;
                bttn.SetValue(Grid.ColumnProperty, 0);
                bttn.SetValue(Grid.RowProperty, i);
                bttn.BorderThickness = new Thickness(0);
                bttn.Background = Brushes.Beige;
                bttn.SetBinding(Button.ContentProperty, String.Format("TableData[{0}]",i));
                Console.WriteLine(bttn.Content);
                DOW30Table.Children.Add(bttn);
                DOW30Table.UpdateLayout();
            }
        }
    }
}
