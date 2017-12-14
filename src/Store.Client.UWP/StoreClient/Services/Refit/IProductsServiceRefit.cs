using Refit;
using StoreClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services.Refit
{
    public interface IProductsServiceRefit
    {
        [Get("/api/products")]
        Task<List<Product>> GetProducts();

        [Get("/api/products/1")]
        Task<List<Product>> GetProductById();

        [Post("/api/products")]
        Task AddProduct(Product product);

        [Get("/api/products/search/{name}")]
        Task<List<Product>> SearchProductsByName(String name);

        [Get("/api/products/delete/{id}")]
        Task DeleteProductById(Guid id);
    }


}
