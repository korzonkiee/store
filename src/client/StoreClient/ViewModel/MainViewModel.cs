using GalaSoft.MvvmLight;
using StoreClient.Services;
using System.Threading.Tasks;

namespace StoreClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IProductsService productsService;

        public MainViewModel(IProductsService productsService)
        {
            this.productsService = productsService;

            Task.Run(async () =>
            {
                var products = await productsService.GetProducts();
            });
        }
    }
}