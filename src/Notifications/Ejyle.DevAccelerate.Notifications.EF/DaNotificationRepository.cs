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
using Ejyle.DevAccelerate.Notifications;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationRepository : DaNotificationRepository<string, DaNotification, DaNotificationVariable, DaNotificationRecipient, DaNotificationRecipientVariable, DbContext>
    {
        public DaNotificationRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaNotificationRepository<TKey, TNotification, TNotificationVariable, TNotificationRecipient, TNotificationRecipientVariable, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotification, TDbContext>, IDaNotificationRepository<TKey, TNotification>
        where TKey : IEquatable<TKey>
        where TNotification : DaNotification<TKey, TNotificationVariable, TNotificationRecipient>
        where TNotificationVariable : DaNotificationVariable<TKey, TNotification>
        where TNotificationRecipient : DaNotificationRecipient<TKey, TNotification, TNotificationRecipientVariable>
        where TNotificationRecipientVariable : DaNotificationRecipientVariable<TKey, TNotificationRecipient>
        where TDbContext : DbContext
    {
        public DaNotificationRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TNotification> NotificationsSet { get { return DbContext.Set<TNotification>(); } }

        public IQueryable<TNotification> Messages => NotificationsSet.AsQueryable();

        public Task CreateAsync(TNotification notification)
        {
            NotificationsSet.Add(notification);
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

        public Task UpdateAsync(TNotification notificationTemplate)
        {
            DbContext.Entry<TNotification>(notificationTemplate).State = EntityState.Modified;
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
