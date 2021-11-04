using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("YogaStudioWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("YogaStudioWebAPI", "Web API", new [] { JwtClaimTypes.Name })
                {
                    Scopes = { "YogaStudioWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "yoga-studio-web-api",
                    ClientName = "Yoga Studio Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://localhost:44313/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:44313/"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:44313/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "YogaStudioWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
