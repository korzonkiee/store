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
            if (name.Text.Length > 1 && description.Text.Length > 1 && price.Text.Length >= 1 && imageUrl.Text.Length > 1 )
            {
                try
                {
                    Product product = new Product
                    {
                        Id = Guid.Empty,
                        Name = name.Text,
                        Description = description.Text,
                        Price = (Decimal.Parse(price.Text)),
                        ImageUrl = imageUrl.Text
                    };
                    ServiceLocator.Current.GetInstance<MainViewModel>().AddProductCommand.Execute(product);
                    
                    this.Close();
                }
                catch (Exception)
                {
                    wrongProduct.Visibility = Visibility.Visible;
                }
            }
            else 
                wrongProduct.Visibility = Visibility.Visible;

        }
    }
}
