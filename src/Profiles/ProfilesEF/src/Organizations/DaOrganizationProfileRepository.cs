// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Profiles.Organizations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.EF.Organizations
{
    public class DaOrganizationProfileRepository : DaOrganizationProfileRepository<int, DaOrganizationProfile, DbContext>
    {
        public DaOrganizationProfileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaOrganizationProfileRepository<TKey, TOrganizationProfile, TDbContext>
        : DaEntityRepositoryBase<TKey, TOrganizationProfile, TDbContext>, IDaOrganizationProfileRepository<TKey, TOrganizationProfile>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : DaOrganizationProfile<TKey>
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

        public Task<TOrganizationProfile> FindByIdAsync(TKey id)
        {
            return OrganizationProfiles.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TOrganizationProfile organizationProfile)
        {
            DbContext.Entry<TOrganizationProfile>(organizationProfile).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }

}
