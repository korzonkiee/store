using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using StoreClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services.Refit
{
    public interface ICategoriesServiceRefit
    {
        [Get("/api/category")]
        Task<List<Category>> GetCategories();
    }
}
