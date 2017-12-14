using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient
{

    public static class Config
    {
        public const string AuthBaseUrl = "http://localhost:5005";
        public const string TokenEndpoint = "http://localhost:5005/connect/token";

        public const string ClientId = "store_manager";
    }
}
