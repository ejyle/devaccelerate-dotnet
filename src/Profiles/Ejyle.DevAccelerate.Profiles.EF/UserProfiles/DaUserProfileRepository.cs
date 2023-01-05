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
using Ejyle.DevAccelerate.Profiles.UserProfiles;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Profiles.EF.UserProfiles
{
    public class DaUserProfileRepository : DaUserProfileRepository<string, DaUserProfile, DaUserProfileAttribute, DbContext>
    {
        public DaUserProfileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaUserProfileRepository<TKey, TUserProfile, TUserProfileAttribute, TDbContext>
        : DaEntityRepositoryBase<TKey, TUserProfile, TDbContext>, IDaUserProfileRepository<TKey, TUserProfile>
        where TKey : IEquatable<TKey>
        where TUserProfile : DaUserProfile<TKey, TUserProfileAttribute>
        where TUserProfileAttribute : DaUserProfileAttribute<TKey, TUserProfile>
        where TDbContext : DbContext
    {
        public DaUserProfileRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TUserProfile> UserProfilesSet { get { return DbContext.Set<TUserProfile>(); } }

        public IQueryable<TUserProfile> UserProfiles => UserProfilesSet.AsQueryable();

        public Task CreateAsync(TUserProfile userProfile)
        {
            UserProfilesSet.Add(userProfile);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TUserProfile userProfile)
        {
            UserProfilesSet.Remove(userProfile);
            return SaveChangesAsync();
        }

        public Task<List<TUserProfile>> FindAllAsync()
        {
            return UserProfilesSet.ToListAsync();
        }

        public Task<TUserProfile> FindByIdAsync(TKey id)
        {
            return UserProfilesSet.Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes).SingleOrDefaultAsync();
        }

        public Task<List<TUserProfile>> FindByUserIdAsync(TKey userId)
        {
            return UserProfilesSet.Where(m => m.OwnerUserId.Equals(userId))
                .Include(m => m.Attributes).ToListAsync();
        }

        public Task UpdateAsync(TUserProfile userProfile)
        {
            DbContext.Entry<TUserProfile>(userProfile).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
