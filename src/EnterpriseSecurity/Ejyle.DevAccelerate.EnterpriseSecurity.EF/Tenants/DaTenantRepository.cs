// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Tenants
{
    public class DaTenantRepository : DaTenantRepository<string, DaTenant, DaTenantUser, DaTenantAttribute, DbContext>
    {
        public DaTenantRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaTenantRepository<TKey, TTenant, TTenantUser, TTenantAttribute, TDbContext>
         : DaEntityRepositoryBase<TKey, TTenant, DbContext>, IDaTenantRepository<TKey, TTenant, TTenantUser>
         where TKey : IEquatable<TKey>
         where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>
         where TTenantUser : DaTenantUser<TKey, TTenant>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
    {
        public DaTenantRepository(DbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TTenant> TenantsSet { get { return DbContext.Set<TTenant>(); } }
        private DbSet<TTenantUser> TenantUsersSet { get { return DbContext.Set<TTenantUser>(); } }

        public IQueryable<TTenant> Tenants => TenantsSet.AsQueryable();

        public IQueryable<TTenantUser> TenantUsers => TenantUsersSet.AsQueryable();

        public Task CreateAsync(TTenant tenant)
        {
            TenantsSet.Add(tenant);
            return SaveChangesAsync();
        }

        public Task<TTenant> FindByIdAsync(TKey tenantId)
        {
            return TenantsSet.Where(m => m.Id.Equals(tenantId))
                .Include(x => x.TenantUsers)
                .Include(x => x.Attributes)
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TTenant tenant)
        {
            DbContext.Entry<TTenant>(tenant).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public Task CreateTenantUserAsync(TTenantUser tenantUser)
        {
            TenantUsersSet.Add(tenantUser);
            return SaveChangesAsync();
        }

        public Task<List<TTenant>> FindByUserIdAsync(TKey userId)
        {
            return TenantsSet.Where(m => m.TenantUsers.Any(x => x.UserId.Equals(userId)))
                .Include(x => x.TenantUsers)
                .Include(x => x.Attributes)
                .ToListAsync();
        }

        public async Task<bool> CheckTenantUserActiveAssociationAsync(TKey tenantId, TKey userId)
        {
            var tenantUser = await TenantUsersSet.Where(m => m.TenantId.Equals(tenantId) && m.UserId.Equals(userId)).SingleOrDefaultAsync();

            if (!tenantUser.IsActive)
            {
                return false;
            }

            return (tenantUser != null);
        }

        public Task<List<TTenant>> FindByAttributeAsync(string attributeName, string attributeValue)
        {
            return TenantsSet.Where(m => m.Attributes.Any(x => x.AttributeName == attributeName && x.AttributeValue == attributeValue))
                .Include(x => x.TenantUsers)
                .Include(x => x.Attributes)
                .ToListAsync();
        }

        public Task<TTenant> FindByNameAsync(string name)
        {
            return TenantsSet.Where(m => m.Name == name)
                .Include(x => x.TenantUsers)
                .Include(x => x.Attributes)
                .SingleOrDefaultAsync();
        }
    }
}
