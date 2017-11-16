using Refit;
using StoreClient.DTOs;
using StoreClient.Services.Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProducts();
        Task AddProductToDatabase(Product product);

        Task<List<Product>> SearchProductsByName(String name);
    }


    public class ProductsService : IProductsService
    {
        public async Task<List<Product>> GetProducts()
        {
            return await RestService
                .For<IProductsServiceRefit>("http://localhost:5000")
                .GetProducts();
        }

        public async Task<List<Product>> GetProductById(String Id)
        {
            return await RestService
                .For<IProductsServiceRefit>("http://localhost:5000")
                .GetProductById();
        }


        public async Task AddProductToDatabase(Product product)
        {
            await RestService.For<IProductsServiceRefit>("http://localhost:5000").AddProduct(product);
        }

        public async Task<List<Product>> SearchProductsByName(String name)
        {
            return await RestService.For<IProductsServiceRefit>("http://localhost:5000").SearchProductsByName(name);
        }
    }


}


