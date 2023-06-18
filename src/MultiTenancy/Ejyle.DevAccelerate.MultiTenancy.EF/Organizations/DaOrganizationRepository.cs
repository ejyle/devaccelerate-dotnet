// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.MultiTenancy.Organizations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.MultiTenancy.EF.Organizations
{
    public class DaOrganizationRepository : DaOrganizationRepository<string, DaOrganization, DaOrganizationAttribute, DaOrganizationGroup, DbContext>
    {
        public DaOrganizationRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaOrganizationRepository<TKey, TOrganization, TOrganizationAttribute, TOrganizationGroup, TDbContext>
        : DaEntityRepositoryBase<TKey, TOrganization, TDbContext>, IDaOrganizationProfileRepository<TKey, TOrganization, TOrganizationGroup>
        where TKey : IEquatable<TKey>
        where TOrganization : DaOrganization<TKey, TOrganization, TOrganizationAttribute, TOrganizationGroup>
        where TOrganizationAttribute : DaOrganizationAttribute<TKey, TOrganization>
        where TOrganizationGroup : DaOrganizationGroup<TKey, TOrganizationGroup, TOrganization>
        where TDbContext : DbContext
    {
        public DaOrganizationRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TOrganization> Organizations { get { return DbContext.Set<TOrganization>(); } }
        private DbSet<TOrganizationGroup> OrganizationGroups { get { return DbContext.Set<TOrganizationGroup>(); } }

        public Task CreateAsync(TOrganization organization)
        {
            Organizations.Add(organization);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TOrganization organization)
        {
            Organizations.Remove(organization);
            return SaveChangesAsync();
        }

        public Task<List<TOrganization>> FindByAttributeAsync(string attributeName, string attributeValue)
        {
            return Organizations.Where(m => m.Attributes.Any(x => x.AttributeName == attributeName && x.AttributeValue == attributeValue))
                .Include(m => m.Attributes)
                .Include(m => m.Children)
                .Include(m => m.Groups)
                .ThenInclude(m => m.Children)
                .ToListAsync();
        }

        public Task<TOrganization> FindByIdAsync(TKey id)
        {
            return Organizations.Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes)
                .Include(m => m.Children)
                .Include(m => m.Groups)
                .ThenInclude(m => m.Children)
                .SingleOrDefaultAsync();
        }

        public Task<List<TOrganization>> FindByTenantIdAsync(TKey tenantId)
        {
            return Organizations.Where(m => m.TenantId.Equals(tenantId))
                .Include(m => m.Attributes)
                .Include(m => m.Children)
                .Include(m => m.Groups)
                .ThenInclude(m => m.Children)
                .ToListAsync();
        }

        public Task<TOrganizationGroup> FindOrganizationGroupByIdAsync(TKey id, TKey organizationGroupId)
        {
            return OrganizationGroups.Where(m => m.Id.Equals(organizationGroupId) && m.OrganizationId.Equals(id)).Include(m => m.Children).SingleOrDefaultAsync();  
        }

        public Task UpdateAsync(TOrganization organization)
        {
            DbContext.Entry<TOrganization>(organization).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }

}
