// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Identity.UserActivities;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Identity.EF.UserActivities
{
    public class DaUserActivityRepository : DaUserActivityRepository<DaUserActivityCategory, DaUserActivity, DbContext>
    {
        public DaUserActivityRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaUserActivityRepository<TUserActivityCategory, TUserActivity, TDbContext>
        : DaUserActivityRepository<int, int?, TUserActivityCategory, TUserActivity, TDbContext>
        where TUserActivityCategory : DaUserActivityCategory<int, int?, TUserActivity>
        where TUserActivity : DaUserActivity<int, int?, TUserActivityCategory>
        where TDbContext : DbContext
    {
        public DaUserActivityRepository(TDbContext context)
            : base(context)
        { }
    }

    public class DaUserActivityRepository<TKey, TNullableKey, TUserActivityCategory, TUserActivity, TDbContext>
         : DaEntityRepositoryBase<TKey, TUserActivity, TDbContext>, IDaUserActivityRepository<TKey, TNullableKey, TUserActivity>
         where TKey : IEquatable<TKey>
         where TUserActivityCategory : DaUserActivityCategory<TKey, TNullableKey, TUserActivity>
         where TUserActivity : DaUserActivity<TKey, TNullableKey, TUserActivityCategory>
         where TDbContext : DbContext
    {
        public DaUserActivityRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TUserActivity> UserActivities { get { return DbContext.Set<TUserActivity>(); } }
        private DbSet<TUserActivityCategory> UserActivityCategories { get { return DbContext.Set<TUserActivityCategory>(); } }

        public Task CreateAsync(TUserActivity userActivity)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userActivity, nameof(userActivity));
            UserActivities.Add(userActivity);
            return SaveChangesAsync();
        }

        public Task CreateUserActivityCategoryAsync(TUserActivityCategory userActivityCategory)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userActivityCategory, nameof(userActivityCategory));
            UserActivityCategories.Add(userActivityCategory);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(int olderThanInDays)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserActivityCategoryAsync(TUserActivityCategory userActivityCategory)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userActivityCategory, nameof(userActivityCategory));
            UserActivityCategories.Remove(userActivityCategory);
            return SaveChangesAsync();
        }

        public Task<TUserActivity> FindByIdAsync(TKey id)
        {
            return UserActivities.Where(m => m.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAndUserActivityTypeAsync(DaDataPaginationCriteria paginationCriteria, TKey userId, DaUserActivityType userActivityType)
        {
            throw new NotImplementedException();
        }

        public Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAsync(DaDataPaginationCriteria paginationCriteria, TKey userId)
        {
            throw new NotImplementedException();
        }
    }
}
