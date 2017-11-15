using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreClient.DTOs;
using StoreClient.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public RelayCommand<int> SortProductsCommand { get; set; }
        public RelayCommand<Product> AddProductCommand { get; set; }

        public MainViewModel(IProductsService productsService)
        {
            this.productsService = productsService;
            SortProductsCommand = new RelayCommand<int>((sortType) => SortProducts(sortType));
            AddProductCommand = new RelayCommand<Product>((product) => AddProduct(product));

            Task.Run(async () =>
            {
                var products = await productsService.GetProducts();
                Products = new ObservableCollection<Product>(products);
            });
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        private void SortProducts(int sortType)
        {
            switch (sortType)
            {
                case 0:
                    List<Product> sortedlistName = Products.OrderBy(o=>o.Name).ToList();
                    for(int i = 0; i < sortedlistName.Count(); i++)
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
    }
}