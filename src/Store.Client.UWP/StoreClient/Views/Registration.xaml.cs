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
    public sealed partial class Registration : Page
    {
        public Registration()
        {
            this.InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void RegiserNewUser(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Email = email.Text;
            if (IsValidEmail(user.Email))
            {
                emailError.Visibility = Visibility.Collapsed;
                user.Password = password.Text;
                if (user.Password.Length >= 8)
                {
                    ServiceLocator.Current.GetInstance<MainViewModel>().RegisterUserCommand.Execute(user);
                    this.Frame.Navigate(typeof(MainPage));
                }
                else passwordError.Visibility = Visibility.Visible;
            }
            else emailError.Visibility = Visibility.Visible;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
    
}
