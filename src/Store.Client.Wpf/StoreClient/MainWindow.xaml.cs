using MaterialDesignThemes.Wpf;
using Microsoft.Practices.ServiceLocation;
using StoreClient.ViewModel;
using StoreClient.Windows;
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

namespace StoreClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = DataContext as MainViewModel;
        }

        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var id = ((Card)sender).Tag;
        }

        private void SortList(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            var vm = DataContext as MainViewModel;
            vm.SortProductsCommand.Execute(cmb.SelectedIndex);
        }

        private void AddProduct(object sender, MouseButtonEventArgs e)
        {
            Window addProductWindow = new AddProduct();
            addProductWindow.Topmost = true;
            addProductWindow.Show();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void SearchByName(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (string.IsNullOrEmpty(searchByName.Text))
            {
                vm.GetAllProductsCommand.Execute(null);
            }
            else vm.SearchProductsByNameCommand.Execute(searchByName.Text);
        }
    }
}
