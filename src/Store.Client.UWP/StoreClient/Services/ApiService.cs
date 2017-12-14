using Refit;
using StoreClient.Auth;
using StoreClient.Services.Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services
{
    public abstract class ApiService
    {
        public IProductsServiceRefit ProductsServiceRefit { get; private set; } =
            RestService.For<IProductsServiceRefit>(new HttpClient(new AuthenticatedHttpClientHandler())
            {
                BaseAddress = new Uri("http://localhost5000")
            });
    }
}
