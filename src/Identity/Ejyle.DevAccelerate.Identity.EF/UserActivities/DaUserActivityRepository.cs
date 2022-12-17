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
        : DaUserActivityRepository<string, TUserActivityCategory, TUserActivity, TDbContext>
        where TUserActivityCategory : DaUserActivityCategory<string, TUserActivity>
        where TUserActivity : DaUserActivity<string, TUserActivityCategory>
        where TDbContext : DbContext
    {
        public DaUserActivityRepository(TDbContext context)
            : base(context)
        { }
    }

    public class DaUserActivityRepository<TKey, TUserActivityCategory, TUserActivity, TDbContext>
         : DaEntityRepositoryBase<TKey, TUserActivity, TDbContext>, IDaUserActivityRepository<TKey, TUserActivity>
         where TKey : IEquatable<TKey>
         where TUserActivityCategory : DaUserActivityCategory<TKey, TUserActivity>
         where TUserActivity : DaUserActivity<TKey, TUserActivityCategory>
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

        public Task DeleteUserActivityCategoryAsync(TUserActivityCategory userActivityCategory)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userActivityCategory, nameof(userActivityCategory));
            UserActivityCategories.Remove(userActivityCategory);
            return SaveChangesAsync();
        }

        public Task<TUserActivity> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return UserActivities.Where(m => m.Equals(id))
                .Include(m => m.UserActivityCategory)
                .SingleOrDefaultAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAndUserActivityTypeAsync(DaDataPaginationCriteria paginationCriteria, TKey userId, DaUserActivityType userActivityType)
        {
            ThrowIfDisposed();

            var totalCount = await UserActivities.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = UserActivities
                .Where(m => m.UserId.Equals(userId) && m.UserActivityType == userActivityType)
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.UserActivityCategory)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TUserActivity>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public async Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAsync(DaDataPaginationCriteria paginationCriteria, TKey userId)
        {
            ThrowIfDisposed();

            var totalCount = await UserActivities.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = UserActivities
                .Where(m => m.UserId.Equals(userId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.UserActivityCategory)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TUserActivity>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
