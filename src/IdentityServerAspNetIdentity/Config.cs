using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerAspNetIdentity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("color", new [] { "favorite_color" })
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("api", "My API"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // interactive ASP.NET Core Web App
            new Client
            {
                ClientId = "blazor-client",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    
                // where to redirect to after login
                RedirectUris = { "https://localhost:7189/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:7189/signout-callback-oidc" },
                
                AllowOfflineAccess = true,
                
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api",
                    "color"
                }
            }
        };
}
