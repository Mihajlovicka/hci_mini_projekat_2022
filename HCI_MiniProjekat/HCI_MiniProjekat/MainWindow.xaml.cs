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
        ColumnChart columnChart;

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
            if (typeCmb.SelectedIndex != 0)
            {
                graph_cmb.SelectedIndex = 0;

                SeriesCollection = null;
                dates = null;
                responce = null;
                if (line_chart != null)
                    line_chart.Visibility = Visibility.Hidden;
                if (GrafikGridicNepotrebniAliPotrebni != null)
                    GrafikGridicNepotrebniAliPotrebni.Visibility = Visibility.Hidden;
                if (table != null)
                {
                    table.Close();
                    table = null;
                }
                if (interval_cmb != null)
                    if (interval_cmb.Visibility == Visibility.Visible)
                    {
                        interval_cmb.Visibility = Visibility.Hidden;

                    }
                if (CPI_cmb == typeCmb.SelectedItem)
                {

                    interval_cmb.Visibility = Visibility.Visible;
                    interval_cmb.SelectedIndex = 0;
                    graph_cmb.IsEnabled = false;
                    chart_title.Content = "";

                }
                else
                {
                    if (inflation_cmb == typeCmb.SelectedItem)
                    {
                        responce = api.Inflation.get();


                    }
                    if (retailsales_cmb == typeCmb.SelectedItem)
                    {
                        responce = api.RetailSales.get();

                    }

                    graph_cmb.SelectedIndex = 1;
                }

            }
        }
        private void interval_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (interval_cmb.SelectedIndex != 0)
            {
                graph_cmb.IsEnabled = true;

                graph_cmb.SelectedIndex = 0;
                SeriesCollection = null;
                dates = null;
                responce = null;
                if (line_chart != null)
                    line_chart.Visibility = Visibility.Hidden;
                if (GrafikGridicNepotrebniAliPotrebni != null)
                    GrafikGridicNepotrebniAliPotrebni.Visibility = Visibility.Hidden;
                if (month_cmb == interval_cmb.SelectedItem)
                {
                    responce = api.CPI.get("month");

                }
                if (semiannual_cmb == interval_cmb.SelectedItem)
                {
                    responce = api.CPI.get("semiannual");

                }
                if(table != null) table.changeSource(responce);
                graph_cmb.SelectedIndex=1;
            }

        }

        private void graph_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (graph_cmb.SelectedIndex != 0)
            {
                if (line_chart != null)
                    line_chart.Visibility = Visibility.Hidden;
                if (GrafikGridicNepotrebniAliPotrebni != null)
                    GrafikGridicNepotrebniAliPotrebni.Visibility = Visibility.Hidden;
                if (line_graph_cmb == graph_cmb.SelectedItem)
                {
                    LineChart lineChart = new LineChart(responce, this);
                    DataContext = this;
                    chart_title.Content = responce.name;
                    LineYAxis.Title = responce.unit;
                    line_chart.Series = SeriesCollection;
                    XLine.Labels = dates;
                    line_chart.Visibility = Visibility.Visible;
                    GrafikGridicNepotrebniAliPotrebni.Visibility = Visibility.Hidden;
                }
                if (column_cmb == graph_cmb.SelectedItem)
                {
                    //ucitaj
                    line_chart.Visibility = Visibility.Hidden;
                    columnChart = new ColumnChart(responce);
                    GrafikGridicNepotrebniAliPotrebni.Children.Clear();
                    GrafikGridicNepotrebniAliPotrebni.Children.Add(columnChart);

                    GrafikGridicNepotrebniAliPotrebni.Visibility = Visibility.Visible;
                    
                        

                }
            }
        }

        private void btn_ShowTable_Click(object sender, RoutedEventArgs e)
        {
            
            if (responce != null && table==null) { 
                table = new Table(responce,this);
                table.Show();
            }
            else if (table != null)
            {
                MessageBox.Show("Tabela vec otvorena.","Greska",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Odaberite zeljeni prikaz.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        public void setTableToNull()
        {
            table = null;
        }
       
    }
}
