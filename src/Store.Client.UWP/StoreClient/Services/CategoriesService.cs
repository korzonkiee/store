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
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategories();
    }
    class CategoriesService : ICategoriesService
    {
        public async Task<List<Category>> GetCategories()
        {
            return await RestService
               .For<ICategoriesServiceRefit>("http://localhost:5000")
               .GetCategories();
        }
    }
}
