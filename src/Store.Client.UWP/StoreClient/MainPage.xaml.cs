﻿using StoreClient.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        }

        private void SortList(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            var vm = DataContext as MainViewModel;
            vm.SortProductsCommand.Execute(cmb.SelectedIndex);
        }

        //private void AddProduct(object sender, MouseButtonEventArgs e)
        //{
        //    Window addProductWindow = new AddProduct();
        //    addProductWindow.Topmost = true;
        //    addProductWindow.Show();
        //}

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void SearchByName(object sender, MouseEventArgs e)
        {
            //var vm = DataContext as MainViewModel;
            //if (string.IsNullOrEmpty(searchByName.Text))
            //{
            //    vm.GetAllProductsCommand.Execute(null);
            //}
            //else vm.SearchProductsByNameCommand.Execute(searchByName.Text);
        }
    }
}
