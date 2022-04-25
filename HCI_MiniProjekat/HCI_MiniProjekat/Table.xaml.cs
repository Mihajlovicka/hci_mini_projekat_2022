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

        public Table(api.Responce r)
        {
            InitializeComponent();

            
            grid.ItemsSource = r.data;
            grid.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DataContext = this;


        }

       
    }
}
