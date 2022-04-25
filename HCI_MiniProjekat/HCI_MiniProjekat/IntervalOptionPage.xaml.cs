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
    /// Interaction logic for IntervalOptionPage.xaml
    /// </summary>
    public partial class IntervalOptionPage : Page
    {
        public IntervalOptionPage()
        {
            InitializeComponent();
        }

        private void Show_TableMonth(object sender, RoutedEventArgs e)
        {
            Table table = new Table(api.CPI.get("month"));
            table.Show();
        }

        private void Show_LineGraphMonth(object sender, RoutedEventArgs e)

        {

            api.Responce responce = api.CPI.get("month");
            LineGraph lineGraph = new LineGraph(responce);
            lineGraph.Show();
        }

        private void Show_PieChartMonth(object sender, RoutedEventArgs e)
        {
        }

        private void Show_TableSemiannual(object sender, RoutedEventArgs e)
        {
            Table table = new Table(api.CPI.get("semiannual"));
            table.Show();
        }

        private void Show_LineGraphSemiannual(object sender, RoutedEventArgs e)
        {
            api.Responce responce = api.CPI.get("semiannual");
            LineGraph lineGraph = new LineGraph(responce);
            lineGraph.Show();
        }

        private void Show_PieChartSemiannual(object sender, RoutedEventArgs e)
        {
        }
    }
}
