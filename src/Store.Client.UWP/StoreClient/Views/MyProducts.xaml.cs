using StoreClient.DTOs;
using StoreClient.MyProducts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StoreClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyProducts : Page
    {
        public MyProducts()
        {
            this.InitializeComponent();
            DataContext = this;
        }
        public static ObservableCollection<Product> MyNonStaticProperty { get { return MyProductsObject.Products; } }
       private void DeleteProductFromCard(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var ProductToRemove = MyProductsObject.Products.FirstOrDefault(p => p.Id == (Guid)button.Tag);
            MyProductsObject.Products.Remove(ProductToRemove);
        }

        private void ReturnToMainView(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
