using StoreClient.DTOs;
using StoreClient.ViewModel;
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
using StoreClient.Services;
using Microsoft.Practices.ServiceLocation;

namespace StoreClient.Windows
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void AddItem(object sender, MouseButtonEventArgs e)
        {
            Product product = new Product
            {
                Id = Guid.Empty,
                Name = name.Text,
                Description = description.Text,
                Price = (Decimal.Parse(price.Text)),
                ImageUrl = imageUrl.Text

            };
            product.ToString();
            ServiceLocator.Current.GetInstance<MainViewModel>().productsService.AddProductToDatabase(product);
            this.Close();
        }
    }
}
