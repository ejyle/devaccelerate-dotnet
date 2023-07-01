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
using Microsoft.EntityFrameworkCore;

using Ejyle.DevAccelerate.MultiTenancy.Tenants;

namespace Ejyle.DevAccelerate.MultiTenancy.EF.Tenants
{
    public class DaTenantRepository : DaTenantRepository<string, DaTenant, DaTenantUser, DaTenantAttribute, DaMTPTenant, DbContext>
    {
        public DaTenantRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaTenantRepository<TKey, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TDbContext>
         : DaEntityRepositoryBase<TKey, TTenant, DbContext>, IDaTenantRepository<TKey, TTenant, TTenantUser>
        where TKey : IEquatable<TKey>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>
        where TMTPTenant : DaMTPTenant<TKey>, new()
        where TTenantUser : DaTenantUser<TKey, TTenant>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
    {
        public DaTenantRepository(DbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TTenant> TenantsSet { get { return DbContext.Set<TTenant>(); } }
        private DbSet<TTenantUser> TenantUsersSet { get { return DbContext.Set<TTenantUser>(); } }
        private DbSet<TMTPTenant> MTPTenantsSet { get { return DbContext.Set<TMTPTenant>(); } }

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
            DbContext.Entry(tenant).State = EntityState.Modified;
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

            return tenantUser != null;
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

        public async Task CreateAsync(TTenant tenant, TKey mtpTenantId)
        {
            tenant.IsMTPManaged = true;

            TenantsSet.Add(tenant);
            await SaveChangesAsync();

            var mtpMember = new TMTPTenant()
            {
                IsActive = true,
                TenantId = tenant.Id,
                MTPTenantId = mtpTenantId,
                CreatedBy = tenant.CreatedBy,
                LastUpdatedBy = tenant.LastUpdatedBy,
                CreatedDateUtc = tenant.CreatedDateUtc,
                LastUpdatedDateUtc = tenant.LastUpdatedDateUtc
            };

            MTPTenantsSet.Add(mtpMember);
            await SaveChangesAsync();
        }

        public Task UpdateMTPTenantStatusAsync(TKey mtpTenantId, TKey tenantId, bool isActive)
        {
            var mtpTenant = MTPTenantsSet.Where(m => m.MTPTenantId.Equals(mtpTenantId) && m.TenantId.Equals(tenantId)).SingleOrDefault();

            if (mtpTenant == null)
            {
                throw new InvalidOperationException("MTPTenant not found.");
            }

            mtpTenant.IsActive = isActive;
            mtpTenant.LastUpdatedDateUtc = DateTime.UtcNow;

            DbContext.Entry(mtpTenant).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
