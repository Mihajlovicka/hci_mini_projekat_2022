using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveCharts;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace HCI_MiniProjekat
{
    public class LineChart
    {
        public LineChart() { }

        public LineChart(api.Responce responce, MainWindow mainWindow)
        {
            mainWindow.dates = responce.data.Select(x => x.date.ToString("MM/dd/yyyy")).ToList();
            ChartValues<double> values = new ChartValues<double>();
            values.AddRange(responce.data.Select(x => Math.Round(Convert.ToDouble(x.value), 2)));

            mainWindow.SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Values = values,
                        PointGeometrySize = 0,
                        StrokeThickness = 4,
                        Fill = Brushes.Transparent
                    }
                };

            responce.unit = "Values [ " + responce.unit + " ]";
        }
    }
}
