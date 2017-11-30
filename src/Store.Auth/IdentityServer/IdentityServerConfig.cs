using System.Collections.Generic;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace Store.Auth.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "store_manager",
                    ClientName = "Store Manager",
                    AllowedGrantTypes =
                    {
                        GrantType.ResourceOwnerPassword,
                        "facebook"
                    },
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,

                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Email,
                        "store_management"
                    }
                }
            };
        }
        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
            };
        }

        public static List<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("store-management", new string[] { "role" })
            };
        }
    }
}