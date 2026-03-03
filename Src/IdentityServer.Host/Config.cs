namespace IdentityServer.Host;

using System.Collections.Generic;
using Duende.IdentityServer.Models;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles", "Ihre Benutzerrollen", new[] { "role" })
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("orderapi", "Zugriff auf die Bestell-API")
        ];

    public static IEnumerable<Client> Clients =>
        [
            new Client
            {
                ClientId = "blazor-client",
                ClientName = "Blazor WebAssembly Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,
                AllowedCorsOrigins = { "https://localhost:7003" },

                RedirectUris = { "https://localhost:7003/authentication/login-callback" },
                PostLogoutRedirectUris = { "https://localhost:7003/" },
                AllowedScopes = { "openid", "profile", "orderapi" }
            }
        ];
}
