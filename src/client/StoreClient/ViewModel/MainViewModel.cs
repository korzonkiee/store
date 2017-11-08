using GalaSoft.MvvmLight;
using StoreClient.DTOs;
using StoreClient.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StoreClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IProductsService productsService;

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

        public MainViewModel(IProductsService productsService)
        {
            this.productsService = productsService;

            Task.Run(async () =>
            {
                var products = await productsService.GetProducts();
                Products = new ObservableCollection<Product>(products);
            });
        }
    }
}