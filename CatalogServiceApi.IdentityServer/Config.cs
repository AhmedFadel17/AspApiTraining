using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace CatalogServiceApi.IdentityServer
{
    public enum UserRole
    {
        Customer,
        Manager,
        Store
    }
    public static class Config
    {
        
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "User roles", new[] { "role" }) 
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { new ApiScope("scope1", "scope1"),
            new ApiScope("scope2", "scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                { 
                    ClientId = "client1",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = 
                    { 
                        new Secret("78195A38-7267-7267-8F2E-8F4EB3FECF34".Sha256()) 
                    },
                    AllowedScopes = {  "openid", "profile", "api1", "roles", "scope1", "scope2" } 
                },
                new Client
                { 
                    ClientId = "client2",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = 
                    { 
                        new Secret("78195A38-7268-7268-8F2E-8F4EB3FECF34".Sha256()) 
                    },
                    AllowedScopes = {  "openid", "profile", "api2", "roles", "scope1", "scope2" } 
                },
            };

    }
}
