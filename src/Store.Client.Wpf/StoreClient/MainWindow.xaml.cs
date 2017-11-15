using MaterialDesignThemes.Wpf;
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
        }

        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var id = ((Card)sender).Tag;

            //ProductInfo pi = new ProductInfo();
            //pi.Id = id.ToString(); 
            //pi.Show();
            //pi.ShowInTaskbar = false;
            //pi.Owner = this;
        }

        private void SortList(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            var vm = DataContext as MainViewModel;
            vm.SortProductsCommand.Execute(cmb.SelectedIndex);
        }

        private void addProduct(object sender, MouseButtonEventArgs e)
        {
            Window test = new AddProduct();
            test.Topmost = true; 
            test.Show();
        }
    }
}
