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
using Ejyle.DevAccelerate.Notifications.Requests;
using Ejyle.DevAccelerate.Notifications.Delivery;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationRequestRepository : DaNotificationRequestRepository<string, DaNotificationRequest, DaNotificationRequestChannel, DaNotificationRequestVariable, DaNotificationRequestRecipient, DaNotificationRequestRecipientVariable, DbContext>
    {
        public DaNotificationRequestRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaNotificationRequestRepository<TKey, TNotificationRequest, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient, TNotificationRequestRecipientVariable, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationRequest, TDbContext>, IDaNotificationRequestRepository<TKey, TNotificationRequest>
        where TKey : IEquatable<TKey>
        where TNotificationRequest : DaNotificationRequest<TKey, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient>
        where TNotificationRequestChannel : DaNotificationRequestChannel<TKey, TNotificationRequest>
        where TNotificationRequestVariable : DaNotificationRequestVariable<TKey, TNotificationRequest>
        where TNotificationRequestRecipient : DaNotificationRequestRecipient<TKey, TNotificationRequest, TNotificationRequestRecipientVariable>
        where TNotificationRequestRecipientVariable : DaNotificationRequestRecipientVariable<TKey, TNotificationRequestRecipient>
        where TDbContext : DbContext
    {
        public DaNotificationRequestRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TNotificationRequest> NotificationRequestsSet { get { return DbContext.Set<TNotificationRequest>(); } }

        public IQueryable<TNotificationRequest> NotificationRequests => NotificationRequestsSet.AsQueryable();

        public Task CreateAsync(TNotificationRequest notification)
        {
            NotificationRequestsSet.Add(notification);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TNotificationRequest notification)
        {
            NotificationRequestsSet.Remove(notification);
            return SaveChangesAsync();
        }

        public Task<TNotificationRequest> FindByIdAsync(TKey id)
        {
            return NotificationRequestsSet.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TNotificationRequest notificationTemplate)
        {
            DbContext.Entry<TNotificationRequest>(notificationTemplate).State = EntityState.Modified;
            return SaveChangesAsync();
        }


        public async Task<DaPaginatedEntityList<TKey, TNotificationRequest>> FindUnprocessedAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await NotificationRequestsSet.Where(m => m.IsProcessingComplete == false).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = NotificationRequestsSet
                .Where(m => m.IsProcessingComplete == false)
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TNotificationRequest>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
