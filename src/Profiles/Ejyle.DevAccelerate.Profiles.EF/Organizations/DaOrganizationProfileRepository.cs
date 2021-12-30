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
    public class DaOrganizationProfileRepository : DaOrganizationProfileRepository<int,int?, DaOrganizationProfile, DaOrganizationProfileAttribute, DbContext>
    {
        public DaOrganizationProfileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaOrganizationProfileRepository<TKey, TNullableKey, TOrganizationProfile, TOrganizationProfileAttribute, TDbContext>
        : DaEntityRepositoryBase<TKey, TOrganizationProfile, TDbContext>, IDaOrganizationProfileRepository<TKey, TNullableKey, TOrganizationProfile>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : DaOrganizationProfile<TKey, TNullableKey, TOrganizationProfileAttribute>
        where TOrganizationProfileAttribute : DaOrganizationProfileAttribute<TKey, TNullableKey, TOrganizationProfile>
        where TDbContext : DbContext
    {
        public DaOrganizationProfileRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TOrganizationProfile> OrganizationProfiles { get { return DbContext.Set<TOrganizationProfile>(); } }
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
                .Include(m => m.Attributes).ToListAsync();
        }

        public Task<TOrganizationProfile> FindByIdAsync(TKey id)
        {
            return OrganizationProfiles.Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes).SingleOrDefaultAsync();
        }

        public Task<List<TOrganizationProfile>> FindByTenantIdAsync(TKey tenantId)
        {
            return OrganizationProfiles.Where(m => m.TenantId.Equals(tenantId))
                .Include(m => m.Attributes).ToListAsync();
        }

        public Task UpdateAsync(TOrganizationProfile organizationProfile)
        {
            DbContext.Entry<TOrganizationProfile>(organizationProfile).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }

}
