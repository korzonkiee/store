using Microsoft.Practices.ServiceLocation;
using StoreClient.DTOs;
using StoreClient.ViewModel;
using System;
using System.Collections.Generic;
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
    public sealed partial class AddProduct : Page
    {
        private MainViewModel viewModel;

        public AddProduct()
        {
            this.InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = e.Parameter as MainViewModel;
            base.OnNavigatedTo(e);
        }


        private void AddItem(object sender, RoutedEventArgs e)
        {
            if (name.Text.Length > 1 && description.Text.Length > 1 && price.Text.Length >= 1 && imageUrl.Text.Length > 1)
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

                    viewModel.AddProductCommand.Execute(product);

                    this.Frame.GoBack();
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
