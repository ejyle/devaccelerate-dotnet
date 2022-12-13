// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Profiles.Organizations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.EF.Organizations
{
    public class DaOrganizationProfileRepository : DaOrganizationProfileRepository<int,int?, DaOrganizationProfile, DaOrganizationProfileAttribute, DaOrganizationGroup, DbContext>
    {
        public DaOrganizationProfileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaOrganizationProfileRepository<TKey, TNullableKey, TOrganizationProfile, TOrganizationProfileAttribute, TOrganizationGroup, TDbContext>
        : DaEntityRepositoryBase<TKey, TOrganizationProfile, TDbContext>, IDaOrganizationProfileRepository<TKey, TNullableKey, TOrganizationProfile, TOrganizationGroup>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : DaOrganizationProfile<TKey, TNullableKey, TOrganizationProfile, TOrganizationProfileAttribute, TOrganizationGroup>
        where TOrganizationProfileAttribute : DaOrganizationProfileAttribute<TKey, TNullableKey, TOrganizationProfile>
        where TOrganizationGroup : DaOrganizationGroup<TKey, TNullableKey, TOrganizationGroup, TOrganizationProfile>
        where TDbContext : DbContext
    {
        public DaOrganizationProfileRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TOrganizationProfile> OrganizationProfiles { get { return DbContext.Set<TOrganizationProfile>(); } }
        private DbSet<TOrganizationGroup> OrganizationGroups { get { return DbContext.Set<TOrganizationGroup>(); } }

        public Task CreateAsync(TOrganizationProfile organizationProfile)
        {
            OrganizationProfiles.Add(organizationProfile);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TOrganizationProfile organizationProfile)
        {
            OrganizationProfiles.Remove(organizationProfile);
            return SaveChangesAsync();
        }

        public Task<List<TOrganizationProfile>> FindByAttributeAsync(string attributeName, string attributeValue)
        {
            return OrganizationProfiles.Where(m => m.Attributes.Any(x => x.AttributeName == attributeName && x.AttributeValue == attributeValue))
                .Include(m => m.Attributes)
                .Include(m => m.Children)
                .Include(m => m.Groups)
                .ThenInclude(m => m.Children)
                .ToListAsync();
        }

        public Task<TOrganizationProfile> FindByIdAsync(TKey id)
        {
            return OrganizationProfiles.Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes)
                .Include(m => m.Children)
                .Include(m => m.Groups)
                .ThenInclude(m => m.Children)
                .SingleOrDefaultAsync();
        }

        public Task<List<TOrganizationProfile>> FindByTenantIdAsync(TKey tenantId)
        {
            return OrganizationProfiles.Where(m => m.TenantId.Equals(tenantId))
                .Include(m => m.Attributes)
                .Include(m => m.Children)
                .Include(m => m.Groups)
                .ThenInclude(m => m.Children)
                .ToListAsync();
        }

        public Task<TOrganizationGroup> FindOrganizaitonGroupByIdAsync(TKey id, TKey organizationGroupId)
        {
            return OrganizationGroups.Where(m => m.Id.Equals(organizationGroupId) && m.OrganizationProfileId.Equals(id)).Include(m => m.Children).SingleOrDefaultAsync();  
        }

        public Task UpdateAsync(TOrganizationProfile organizationProfile)
        {
            DbContext.Entry<TOrganizationProfile>(organizationProfile).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }

}
