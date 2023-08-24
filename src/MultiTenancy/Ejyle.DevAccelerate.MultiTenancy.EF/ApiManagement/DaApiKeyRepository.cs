using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.MultiTenancy.ApiManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.MultiTenancy.EF.ApiManagement
{
    public class DaApiKeyRepository : DaApiKeyRepository<string, DaApiKey, DbContext>
    {
        public DaApiKeyRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaApiKeyRepository<TKey, TApiKey, TDbContext> : DaEntityRepositoryBase<TKey, TApiKey, TDbContext>, IDaApiKeyRepository<TKey, TApiKey>
        where TKey : IEquatable<TKey>
        where TApiKey : DaApiKey<TKey>
        where TDbContext : DbContext
    {
        public DaApiKeyRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TApiKey> ApiKeySet { get { return DbContext.Set<TApiKey>(); } }

        public Task CreateAsync(TApiKey apiKey)
        {
            ApiKeySet.Add(apiKey);
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TApiKey apiKey)
        {
            ApiKeySet.Remove(apiKey);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<TApiKey>> FindAllAsync(TKey tenantId)
        {
            return ApiKeySet.Where(m => m.TenantId.Equals(tenantId)).ToListAsync();
        }

        public Task<TApiKey> FindByApiKeyAsync(string apiKey)
        {
            return ApiKeySet.Where(m => m.ApiKey.Equals(apiKey)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TApiKey apiKey)
        {
            ApiKeySet.Update(apiKey);
            return DbContext.SaveChangesAsync();
        }
    }
}
