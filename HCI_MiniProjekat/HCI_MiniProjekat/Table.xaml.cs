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
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        MainWindow parent;
        public Table(api.Responce r, MainWindow w)
        {
            InitializeComponent();
            changeSource(r);
            parent = w; 
            


        }
        public void changeSource(api.Responce r) {
            grid.ItemsSource = r.data;
            grid.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DataContext = this;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.setTableToNull();
        }
    }
}
