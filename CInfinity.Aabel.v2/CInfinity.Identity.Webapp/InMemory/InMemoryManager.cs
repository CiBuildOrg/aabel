using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace CInfinity.Identity.Webapp
{
    public static class InMemoryManager
    {
        public static IEnumerable<Scope> GetScopes() =>
            new Scope[]
            {
                new Scope
                {
                    Name = "api1",
                    Description = "My API 1"
                }
            };


        public static IEnumerable<Client> GetClients() =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        "api1"
                    }
                }
            };
    }
}
