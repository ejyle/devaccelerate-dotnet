using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.MultiTenancy.ApiManagement
{
    public interface IDaApiKeyRepository<TKey, TApiKey> : IDaEntityRepository<TKey, TApiKey>
        where TKey : IEquatable<TKey>
        where TApiKey : IDaApiKey<TKey>
    {
        Task CreateAsync(TApiKey apiKey);
        Task DeleteAsync(TApiKey apiKey);
        Task UpdateAsync(TApiKey apiKey);
        Task<List<TApiKey>> FindAllAsync(TKey tenantId);
        Task<TApiKey> FindByApiKeyAsync(string apiKey);
    }
}
