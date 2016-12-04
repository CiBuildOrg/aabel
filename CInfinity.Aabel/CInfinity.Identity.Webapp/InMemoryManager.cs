namespace CInfinity.Identity.Webapp
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using IdentityServer4.Models;
    using IdentityServer4.Services.InMemory;
    using static IdentityServer4.IdentityServerConstants;

    /// <summary>
    /// Defines the in-memory configuration for the identity service.
    /// </summary>
    internal static class InMemoryManager
    {
        #region Public methods
        /// <summary>
        /// Returns the identity resources protected by the identity server.
        /// </summary>
        /// <returns>
        /// The collection of identity resources.
        /// </returns>
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        /// <summary>
        /// Returns the api resources protected by the identity server.
        /// </summary>
        /// <returns>
        /// The collection of api resources.
        /// </returns>
        public static IEnumerable<ApiResource> GetApiResources() =>
            new ApiResource[]
            {
                new ApiResource(StandardScopes.OpenId),
                new ApiResource(StandardScopes.Profile),
                new ApiResource("api1", "My API")
            };

        /// <summary>
        /// Returns the clients allowed to access the resources.
        /// </summary>
        /// <returns>
        /// The collection of clients.
        /// </returns>
        public static IEnumerable<Client> GetClients() =>
            new Client[]
            {
                GetClientCredentials("simplee", "secret"),
                GetResourceOwnerPassword("simplee", "secret"),
                GetHybridAndClientCredentials("simplee", "secret")
            };
        #endregion

        #region Helper methods
        /// <summary>
        /// Returns a client which has client credentidials grant type.
        /// </summary>
        /// <param name="clientIdPrefix">
        /// The prefix of the client identifier.
        /// </param>
        /// <param name="secret">
        /// The secret of the client.
        /// </param>
        /// <returns>
        /// The instance of the <see cref="Client"/> class.
        /// </returns>
        private static Client GetClientCredentials(string clientIdPrefix, string secret) =>
            new Client
            {
                ClientId = $"{clientIdPrefix}.cc",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret(secret.Sha256())
                },
                AllowedScopes =
                {
                    StandardScopes.OpenId,
                    "api1"
                }
            };

        /// <summary>
        /// Returns a client which has resource owner password grant type.
        /// </summary>
        /// <param name="clientIdPrefix">
        /// The prefix of the client identifier.
        /// </param>
        /// <param name="secret">
        /// The secret of the client.
        /// </param>
        /// <returns>
        /// The instance of the <see cref="Client"/> class.
        /// </returns>
        private static Client GetResourceOwnerPassword(string clientIdPrefix, string secret) =>
            new Client
            {
                ClientId = $"{clientIdPrefix}.ro",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret(secret.Sha256())
                },
                AllowedScopes =
                {
                    "api1"
                }
            };

        /// <summary>
        /// Returns a client which has hybrid and client credentials grant type.
        /// </summary>
        /// <param name="clientIdPrefix">
        /// The prefix of the client identifier.
        /// </param>
        /// <param name="secret">
        /// The secret of the client.
        /// </param>
        /// <returns>
        /// The instance of the <see cref="Client"/> class.
        /// </returns>
        private static Client GetHybridAndClientCredentials(string clientIdPrefix, string secret) =>
            new Client
            {
                ClientId = $"{clientIdPrefix}.hcc",
                ClientName = $"Simplee Main ASP.NET",
                ClientSecrets =
                {
                    new Secret(secret.Sha256())
                },
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                RequireConsent = false,

                RedirectUris =
                {
                    "http://localhost:5002/signin-oidc"
                },
                PostLogoutRedirectUris =
                {
                    "http://localhost:5002",
                    "http://localhost:5002/",
                    "http://localhost:5002/signout-callback-oidc"
                },
                AllowedScopes =
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    "api1"
                },
                AllowOfflineAccess = true
            };
        #endregion
    }
}
