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
    public class DaTenantRepository : DaTenantRepository<int, int?, DaTenant, DaTenantUser, DaTenantAttribute, DbContext>
    {
        public DaTenantRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaTenantRepository<TKey, TNullableKey, TTenant, TTenantUser, TTenantAttribute, TDbContext>
         : DaEntityRepositoryBase<TKey, TTenant, DbContext>, IDaTenantRepository<TKey, TNullableKey, TTenant>
         where TKey : IEquatable<TKey>
         where TTenant : DaTenant<TKey, TNullableKey, TTenantUser, TTenantAttribute>
         where TTenantUser : DaTenantUser<TKey, TNullableKey, TTenant>
        where TTenantAttribute : DaTenantAttribute<TKey, TNullableKey, TTenant>
    {
        public DaTenantRepository(DbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TTenant> Tenants { get { return DbContext.Set<TTenant>(); } }
        private DbSet<TTenantUser> TenantUsers { get { return DbContext.Set<TTenantUser>(); } }

        public Task CreateAsync(TTenant tenant)
        {
            Tenants.Add(tenant);
            return SaveChangesAsync();
        }

        public Task<TTenant> FindByNameAsync(string name)
        {
            return Tenants.Where(m => m.Name == name).SingleOrDefaultAsync();
        }

        public Task<TTenant> FindByIdAsync(TKey tenantId)
        {
            return Tenants.Where(m => m.Id.Equals(tenantId)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TTenant tenant)
        {
            DbContext.Entry<TTenant>(tenant).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public Task CreateTenantUserAsync(TTenantUser tenantUser)
        {
            TenantUsers.Add(tenantUser);
            return SaveChangesAsync();
        }

        public Task<List<TTenant>> FindByUserIdAsync(TKey userId)
        {
            return Tenants.Where(m => m.TenantUsers.Any(x => x.UserId.Equals(userId))).ToListAsync();
        }

        public async Task<bool> CheckTenantUserActiveAssociationAsync(TKey tenantId, TKey userId)
        {
            var tenantUser = await TenantUsers.Where(m => m.TenantId.Equals(tenantId) && m.UserId.Equals(userId)).SingleOrDefaultAsync();

            if (!tenantUser.IsActive)
            {
                return false;
            }

            return (tenantUser != null);
        }
    }
}
