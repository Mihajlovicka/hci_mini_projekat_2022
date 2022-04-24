using LiveCharts;
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

namespace HCI_MiniProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Show_IntervalFrame(object sender, RoutedEventArgs e)
        {
            simpleOptionFrame.Content = null;
            intervalOptionFrame.Content = null;
            btn_cpi.Background = Brushes.White;
            btn_inflation.Background = Brushes.White;
            btn_retail_sales.Background = Brushes.White;
            Button btn = (Button)sender;
            btn.Background = Brushes.LightBlue;

            
            intervalOptionFrame.Content = new IntervalOptionPage();            
        }

        private void Show_SimpleFrame(object sender, RoutedEventArgs e)
        {
            simpleOptionFrame.Content = null;
            intervalOptionFrame.Content = null;
            btn_cpi.Background = Brushes.White;
            btn_inflation.Background = Brushes.White;
            btn_retail_sales.Background = Brushes.White;
            Button btn = (Button)sender;
            btn.Background = Brushes.LightBlue;

            api.Responce responce = null;
            if(btn.Name == "btn_inflation")
            {
                responce = api.Inflation.get();
            }
            if (btn.Name == "btn_retail_sales")
            {
                responce = api.RetailSales.get();
            }
            
            simpleOptionFrame.Content = new SimpleOptionPage(responce);
        }
    }
}
