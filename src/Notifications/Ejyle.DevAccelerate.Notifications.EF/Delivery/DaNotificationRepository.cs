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
using Ejyle.DevAccelerate.Core.Data;
using System.Xml.Linq;
using Ejyle.DevAccelerate.Notifications.Delivery;

namespace Ejyle.DevAccelerate.Notifications.EF.Delivery
{
    public class DaNotificationRepository : DaNotificationRepository<string, DaNotification, DbContext>
    {
        public DaNotificationRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaNotificationRepository<TKey, TNotification, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotification, TDbContext>, IDaNotificationRepository<TKey, TNotification>
        where TKey : IEquatable<TKey>
        where TNotification : DaNotification<TKey>
        where TDbContext : DbContext
    {
        public DaNotificationRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TNotification> NotificationsSet { get { return DbContext.Set<TNotification>(); } }

        public IQueryable<TNotification> Notifications => NotificationsSet.AsQueryable();

        public Task CreateAsync(TNotification notification)
        {
            NotificationsSet.Add(notification);
            return SaveChangesAsync();
        }

        public Task CreateAsync(List<TNotification> notifications)
        {
            NotificationsSet.AddRange(notifications);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TNotification notification)
        {
            NotificationsSet.Remove(notification);
            return SaveChangesAsync();
        }

        public Task<TNotification> FindByIdAsync(TKey id)
        {
            return NotificationsSet.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TNotification notification)
        {
            DbContext.Update(notification);
            return SaveChangesAsync();
        }

        public Task UpdateAsync(List<TNotification> notifications)
        {
            DbContext.UpdateRange(notifications);
            return SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TNotification>> FindByStatusAsync(DaNotificationStatus status, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await NotificationsSet.Where(m => m.Status.Equals(status)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = NotificationsSet
                .Where(m => m.Status.Equals(status))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TNotification>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
