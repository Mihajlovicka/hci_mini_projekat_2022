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
    /// Interaction logic for SimpleOptionPage.xaml
    /// </summary>
    public partial class SimpleOptionPage : Page
    {
        private api.Responce responce;

        public SimpleOptionPage(api.Responce r)
        {
            InitializeComponent();
            responce = r;
        }

        private void Show_Table(object sender, RoutedEventArgs e)
        {
            Table table = new Table(responce);
            table.Show();
        }

        private void Show_LineGraph(object sender, RoutedEventArgs e)
        {
            
            LineGraph lineGraph = new LineGraph(responce);
            lineGraph.Show();
        }

        private void Show_PieChart(object sender, RoutedEventArgs e)
        {
        }

    }
}
