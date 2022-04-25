using LiveCharts;
using LiveCharts.Wpf;
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

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> dates { get; set; }
        public api.Responce responce { get; set; }
        public Table table = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void typeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SeriesCollection = null;
            dates = null;
            responce = null;
            if(line_chart != null)
                line_chart.Visibility = Visibility.Hidden;
            if (table != null)
            {
                table.Close();
            }
            if(interval_cmb != null)
            if(interval_cmb.Visibility == Visibility.Visible)
            {
                interval_cmb.Visibility = Visibility.Hidden;
            }
            if (CPI_cmb == typeCmb.SelectedItem)
            {
                interval_cmb.Visibility = Visibility.Visible;
                
                    
            }
            if (inflation_cmb == typeCmb.SelectedItem)
            {
                responce = api.Inflation.get();
                if (line_graph_cmb == graph_cmb.SelectedItem)
                {
                    LineChart lineChart = new LineChart(responce, this);
                    DataContext = this;
                    chart_title.Content = responce.name;
                    LineYAxis.Title = responce.unit;                    
                    line_chart.Series = SeriesCollection;
                    XLine.Labels = dates;
                    line_chart.Visibility = Visibility.Visible;
                }
                
            }
            if (retailsales_cmb == typeCmb.SelectedItem)
            {
                responce = api.RetailSales.get();
                if (line_graph_cmb == graph_cmb.SelectedItem)
                {
                    LineChart lineChart = new LineChart(responce, this);
                    DataContext = this;
                    chart_title.Content = responce.name;
                    LineYAxis.Title = responce.unit;
                    line_chart.Series = SeriesCollection;
                    XLine.Labels = dates;
                    line_chart.Visibility = Visibility.Visible;
                }
            }

            
            
        }

        private void interval_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SeriesCollection = null;
            dates = null;
            responce = null;
            if (line_chart != null)
                line_chart.Visibility = Visibility.Hidden;
            if (month_cmb == interval_cmb.SelectedItem)
            {
                responce = api.CPI.get("month");
                LineChart lineChart = new LineChart(responce, this);
                DataContext = this;
                chart_title.Content = responce.name;
                LineYAxis.Title = responce.unit;
                line_chart.Series = SeriesCollection;
                XLine.Labels = dates;
                line_chart.Visibility = Visibility.Visible;
            }
            if (semiannual_cmb == interval_cmb.SelectedItem)
            {
                responce = api.CPI.get("semiannual");
                LineChart lineChart = new LineChart(responce, this);
                DataContext = this;
                chart_title.Content = responce.name;
                LineYAxis.Title = responce.unit;
                line_chart.Series = SeriesCollection;
                XLine.Labels = dates;
                line_chart.Visibility = Visibility.Visible;
            }
        }

        private void graph_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_ShowTable_Click(object sender, RoutedEventArgs e)
        {
            if (responce != null) { 
                table = new Table(responce);
                table.Show();
            }
            else
            {
                MessageBox.Show("Odaberite zeljeni prikaz.");
            }
            
        }
       
    }
}
