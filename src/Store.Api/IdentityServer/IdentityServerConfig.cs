using System.Collections.Generic;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace Store.Api.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "store",
                    ClientName = "Store",
                    AllowedGrantTypes =
                    {
                        GrantType.ResourceOwnerPassword,
                    },
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,

                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Email
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
    }
}