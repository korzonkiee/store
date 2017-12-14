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
        Task DeleteProductById(Guid id);

        Task<List<Product>> SearchProductsByName(String name);
    }


    public class ProductsService : ApiService, IProductsService
    {
        public async Task<List<Product>> GetProducts()
        {
            return await ProductsServiceRefit
                .GetProducts();
        }

        public async Task<List<Product>> GetProductById(String Id)
        {
            return await ProductsServiceRefit
                .GetProductById();
        }


        public async Task AddProductToDatabase(Product product)
        {
            await ProductsServiceRefit
                .AddProduct(product);
        }

        public async Task<List<Product>> SearchProductsByName(String name)
        {
            return await ProductsServiceRefit
                .SearchProductsByName(name);
        }

        public async Task DeleteProductById(Guid id)
        {
            await ProductsServiceRefit
                .DeleteProductById(id);
        }
    }


}


