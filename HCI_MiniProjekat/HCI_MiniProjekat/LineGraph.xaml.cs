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
using System.Windows.Shapes;

namespace HCI_MiniProjekat
{
    /// <summary>
    /// Interaction logic for LineGraph.xaml
    /// </summary>
    public partial class LineGraph : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> dates { get; set; }
        public api.Responce responce { get; set; }

        public LineGraph(api.Responce r)
        {

            InitializeComponent();
            responce = r;
            dates = responce.data.Select(x => x.date.ToString("MM/dd/yyyy")).ToList();
            ChartValues<double> values = new ChartValues<double>();
            values.AddRange(responce.data.Select(x => Math.Round(Convert.ToDouble(x.value), 2)));

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = values,
                    PointGeometrySize = 0,
                    StrokeThickness = 4,
                    Fill = Brushes.Transparent
                }
            };

            responce.unit = "Values [ " +responce.unit+ " ]";
            DataContext = this;
            
        }
    
    }
}
