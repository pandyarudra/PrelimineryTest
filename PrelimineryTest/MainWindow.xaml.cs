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
using PrelimineryTest.Services;

namespace PrelimineryTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetAllFiles();
        }

        private void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            // Call servie method to fetch data
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YearSelectorDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dt = MainUtility.GetDataTableFromCsv(YearSelectorDropdown.SelectedItem.ToString());
            CSVDataGridView.ItemsSource = dt.DefaultView;
        }

        public void GetAllFiles()
        {
            var abc = TableInsertionService.ReadFiles();
            foreach (var item in abc)
            {
                YearSelectorDropdown.Items.Add(item);
            }
        }
    }
}
