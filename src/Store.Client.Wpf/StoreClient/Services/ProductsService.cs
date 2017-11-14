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
    }
    public class ProductsService : IProductsService
    {
        public async Task<List<Product>> GetProducts()
        {
            return await RestService
                .For<IProductsServiceRefit>("http://localhost:5000")
                .GetProducts();
        }
    }
}
