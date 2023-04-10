using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.MultiTenancy.ApiManagement
{
    public class DaApiKeyManager<TKey, TApiKey> : DaEntityManagerBase<TKey, TApiKey>
        where TKey : IEquatable<TKey>
        where TApiKey : IDaApiKey<TKey>
    {
        public DaApiKeyManager(IDaApiKeyRepository<TKey, TApiKey> repository)
            : base(repository)
        { }

        protected virtual IDaApiKeyRepository<TKey, TApiKey> Repository
        {
            get
            {
                return GetRepository<IDaApiKeyRepository<TKey, TApiKey>>();
            }
        }

        public async Task<string> CreateAsync(TApiKey apiKey)
        {
            string salt = null;
            var secret = Guid.NewGuid().ToString();

            var hashedSecretKey = DaHashAlgorithm.GenerateHashedString(secret, out salt);
            apiKey.ApiKey = Guid.NewGuid().ToString();
            apiKey.HashedSecretKey = hashedSecretKey;
            apiKey.Salt = salt;

            await Repository.CreateAsync(apiKey);
            return secret;
        }

        public virtual string Create(TApiKey apiKey)
        {
            return DaAsyncHelper.RunSync(() => CreateAsync(apiKey));
        }

        public Task DeleteAsync(TApiKey apiKey)
        {
            return Repository.DeleteAsync(apiKey);
        }

        public virtual void Delete(TApiKey apiKey)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(apiKey));
        }

        public Task UpdateAsync(TApiKey apiKey)
        {
            return Repository.UpdateAsync(apiKey);
        }

        public virtual void Update(TApiKey apiKey)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(apiKey));
        }

        public Task<List<TApiKey>> FindAllAsync(TKey tenantId)
        {
            return Repository.FindAllAsync(tenantId);
        }

        public virtual List<TApiKey> FindAll(TKey tenantId)
        {
            return DaAsyncHelper.RunSync(() => FindAllAsync(tenantId));
        }

        public Task<TApiKey> FindByApiKeyAsync(string apiKey)
        {
            return Repository.FindByApiKeyAsync(apiKey);
        }

        public virtual TApiKey FindByApiKey(string apiKey)
        {
            return DaAsyncHelper.RunSync(() => FindByApiKeyAsync(apiKey));
        }
    }
}
