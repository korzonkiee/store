using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreClient.DTOs;
using StoreClient.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using GalaSoft.MvvmLight.Threading;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;

namespace StoreClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly IProductsService productsService;

        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                RaisePropertyChanged(nameof(Products));
            }
        }
        // private ObservableCollection<Category> categories = new ObservableCollection<Categori>

        public RelayCommand<int> SortProductsCommand { get; set; }
        public RelayCommand<Product> AddProductCommand { get; set; }
        public RelayCommand<String> SearchProductsByNameCommand { get; set; }
        public RelayCommand GetAllProductsCommand { get; set; }
        public RelayCommand<User> RegisterUserCommand { get; set; }
        public RelayCommand<Guid> DeleteProductByIDCommand { get; set; }

        public MainViewModel(IProductsService productsService)
        {
            this.productsService = productsService;
            SortProductsCommand = new RelayCommand<int>((sortType) => SortProducts(sortType));
            AddProductCommand = new RelayCommand<Product>(async (product) => await AddProduct(product));
            SearchProductsByNameCommand = new RelayCommand<String>((name) => SearchProductsByName(name));
            RegisterUserCommand = new RelayCommand<User>((user) => RegisterUser(user));
            GetAllProductsCommand = new RelayCommand(GetAllProducts);
            DeleteProductByIDCommand = new RelayCommand<Guid>((id) => DeleteProductByID(id));


            Task.Run(async () =>
            {
                var products = await productsService.GetProducts();
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Products = new ObservableCollection<Product>(products);
                });
            });
        }

        private void DeleteProductByID(Guid id)
        {
            Task.Run(async () =>
            {
                await productsService.DeleteProductById(id);
                var products = await productsService.GetProducts();
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Products = new ObservableCollection<Product>(products);
                });
            });
        }

        private void SearchProductsByName(string name)
        {
            Task.Run(async () =>
            {
                var products = await productsService.SearchProductsByName(name);
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Products = new ObservableCollection<Product>(products);
                });
            });
        }

        public async Task AddProduct(Product product)
        {
            try
            {
                await productsService.AddProductToDatabase(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var products = await productsService.GetProducts();
            Products = new ObservableCollection<Product>(products);
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Products = new ObservableCollection<Product>(products);
            });
        }

        private void SortProducts(int sortType)
        {
            switch (sortType)
            {
                case 0:
                    List<Product> sortedlistName = Products.OrderBy(o => o.Name).ToList();
                    for (int i = 0; i < sortedlistName.Count(); i++)
                        Products.Move(Products.IndexOf(sortedlistName[i]), i);
                    break;
                case 1:
                    List<Product> sortedlistPrice = Products.OrderBy(o => o.Price).ToList();
                    for (int i = 0; i < sortedlistPrice.Count(); i++)
                        Products.Move(Products.IndexOf(sortedlistPrice[i]), i);
                    break;
                case 2:
                    List<Product> sortedlistDeliveryTime = Products.OrderBy(o => o.DeliveryTime).ToList();
                    for (int i = 0; i < sortedlistDeliveryTime.Count(); i++)
                        Products.Move(Products.IndexOf(sortedlistDeliveryTime[i]), i);
                    break;
            }
        }

        private void GetAllProducts()
        {
            Task.Run(async () =>
            {
                var products = await productsService.GetProducts();
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Products = new ObservableCollection<Product>(products);
                });
            });
        }

        public void RegisterUser(User user)
        {
            Task.Run(async () =>
            {
                RegistrationService registrationService = new RegistrationService();
                await registrationService.AddUser(user);
            });
        }
    }
}
