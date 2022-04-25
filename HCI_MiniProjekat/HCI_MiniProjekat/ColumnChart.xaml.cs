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
using LiveCharts;
using LiveCharts.Wpf;

namespace HCI_MiniProjekat
{
    /// <summary>
    /// Interaction logic for ColumnChart.xaml
    /// </summary>
    public partial class ColumnChart : UserControl
    {
        public SeriesCollection kolekcija { get; set; }
        public List<string> dates { get; set; }
        public api.Responce responce { get; set; }
        private int start = 0;
        private int cnt = 60;

        public ColumnChart(api.Responce r)
        {
            InitializeComponent();
            responce = r;
            cntTextBox.Text = cnt.ToString();

            loadChart();
        }

        public Func<double, string> Formatter { get; set; }

        private void loadChart()
        {

            dates = responce.data.Select(x => x.date.ToString("MM/dd/yyyy")).ToList().GetRange(start, cnt);
            ChartValues<double> values = new ChartValues<double>();
            values.AddRange((responce.data.Select(x => Math.Round(Convert.ToDouble(x.value), 2))).Take(new Range(start, start + cnt)));

            kolekcija = new SeriesCollection
            {
                new ColumnSeries
                {
                    
                    Values = values
                }
            };
            this.DataContext = this;
            graf.Series = kolekcija;
            DateAxis.Labels = dates;
        }
        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (start - cnt >= 0)
            {
                start -= cnt;
            }
            else
            {
                start = 0;
                MessageBox.Show("Nalazite se na pocetku prikaza podataka.", "Paznja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            loadChart();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {

            if (start + cnt <= responce.data.Count - 1 - cnt)
            {
                start += cnt;
            }
            else
            {
                start = responce.data.Count - 1 - cnt;
                MessageBox.Show("Nalazite se na kraju prikaza podataka.", "Paznja", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            loadChart();
        }

        private void cntTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int pom = Convert.ToInt32(cntTextBox.Text);
                if (pom > 150 || pom <= 0)
                {
                    MessageBox.Show("Vrednost mora biti u opsegu 1 - 150!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    cntTextBox.Text = cnt.ToString();
                    cntTextBox.Focus();
                }
                else
                {
                    cnt = pom;
                    loadChart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pogresan unos. Uneta vrednost mora biti broj!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                cntTextBox.Text = cnt.ToString();
                cntTextBox.Focus();
            }
        }
    }
}
