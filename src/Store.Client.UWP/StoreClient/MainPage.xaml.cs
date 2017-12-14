using StoreClient.DTOs;
using StoreClient.MyProducts;
using StoreClient.Services;
using StoreClient.ViewModel;
using StoreClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StoreClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var vm = DataContext as MainViewModel;
            MyProductsObject.Products = new ObservableCollection<Product>();
        }

        private void SortList(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            var vm = DataContext as MainViewModel;
            vm.SortProductsCommand.Execute(cmb.SelectedIndex);
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddProduct), DataContext as MainViewModel);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void SearchByName(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (string.IsNullOrEmpty(searchByName.Text))
            {
                vm.GetAllProductsCommand.Execute(null);
            }
            else vm.SearchProductsByNameCommand.Execute(searchByName.Text);
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registration));
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            Button button = (Button)sender;
            vm.DeleteProductByIDCommand.Execute(button.Tag);
        }

        private void AddToCard(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            Button button = (Button)sender;
            var ProductToAdd = vm.Products.FirstOrDefault(p => p.Id == (Guid)button.Tag);
            MyProductsObject.Products.Add(ProductToAdd);
        }

        private void GoToMyCard(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.MyProducts));
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginService loginService = new LoginService();

            Task.Run(async () =>
            {

                await loginService.Logout();
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                     {
                         this.Frame.Navigate(typeof(Views.Login));
                     });
            });
        }
    }
}
