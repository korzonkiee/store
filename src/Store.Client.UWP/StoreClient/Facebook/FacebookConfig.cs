using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Facebook
{
    public static class FacebookConfig
    {
        public const string FacebookAppId = "166348153966845";
        public static readonly string[] FacebookRequiredPermissions = new string[]
        {
            "email"
        };

        public const string FacebookAssertion = "facebook";
    }
}
