
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StoreClient.Services
{
    public abstract class AuthService
    {
        protected TokenClient TokenClient;

        public AuthService()
        {
            TokenClient = InitializeTokenClient();
        }

        private TokenClient InitializeTokenClient()
        {
            return new TokenClient(Config.TokenEndpoint, Config.ClientId);
        }
    }
}
