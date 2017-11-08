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
    }
}
