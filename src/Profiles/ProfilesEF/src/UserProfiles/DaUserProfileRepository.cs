// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Profiles.UserProfiles;

namespace Ejyle.DevAccelerate.Profiles.EF.UserProfiles
{
    public class DaUserProfileRepository : DaUserProfileRepository<int, DaUserProfile, DbContext>
    {
        public DaUserProfileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaUserProfileRepository<TKey, TUserProfile, TDbContext>
        : DaEntityRepositoryBase<TKey, TUserProfile, TDbContext>, IDaUserProfileRepository<TKey, TUserProfile>
        where TKey : IEquatable<TKey>
        where TUserProfile : DaUserProfile<TKey>
        where TDbContext : DbContext
    {
        public DaUserProfileRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TUserProfile> UserProfiles { get { return DbContext.Set<TUserProfile>(); } }
        public Task CreateAsync(TUserProfile userProfile)
        {
            UserProfiles.Add(userProfile);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TUserProfile userProfile)
        {
            UserProfiles.Remove(userProfile);
            return SaveChangesAsync();
        }

        public Task<TUserProfile> FindByIdAsync(TKey id)
        {
            return UserProfiles.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TUserProfile userProfile)
        {
            DbContext.Entry<TUserProfile>(userProfile).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
