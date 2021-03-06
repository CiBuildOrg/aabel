﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace CInfinity.Identity.Webapp
{
    public class ClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(InMemoryManager.GetHybridAndClientCredentials("simplee", "secret"));
        }
    }
}
