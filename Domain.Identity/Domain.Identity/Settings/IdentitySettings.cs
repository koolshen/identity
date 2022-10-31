using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Domain.Identity.Settings
{
    public class IdentityServerSettings
    {
        public string? ApiSecret { get; set; }
        public string? ClientSecret { get; set; }

        public IReadOnlyCollection<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };
        public IReadOnlyCollection<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret(ApiSecret.Sha256()) }
                }
            };
        public IReadOnlyCollection<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret(ClientSecret.Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
                new Client
                {
                    ClientId = "application.user",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RequireClientSecret = false,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AllowedScopes = {
                        "identity.api",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile},
                    AllowOfflineAccess = true
                }
            };
        public IReadOnlyCollection<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
    }
}
