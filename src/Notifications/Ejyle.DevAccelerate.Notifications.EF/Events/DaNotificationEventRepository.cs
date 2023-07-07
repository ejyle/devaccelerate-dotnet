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
using Ejyle.DevAccelerate.Notifications.Events;

namespace Ejyle.DevAccelerate.Notifications.EF.Events
{
    public class DaNotificationEventRepository : DaNotificationEventRepository<string, DaNotificationEvent, DaNotificationEventChannel, DaNotificationEventVariable, DaNotificationEventSubscriber, DaNotificationEventSubscriberVariable, DbContext>
    {
        public DaNotificationEventRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaNotificationEventRepository<TKey, TNotificationEvent, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber, TNotificationEventSubscriberVariable, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationEvent, TDbContext>, IDaNotificationEventRepository<TKey, TNotificationEvent>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber>
        where TNotificationEventChannel : DaNotificationEventChannel<TKey, TNotificationEvent>
        where TNotificationEventVariable : DaNotificationEventVariable<TKey, TNotificationEvent>
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationEventSubscriberVariable>
        where TNotificationEventSubscriberVariable : DaNotificationEventSubscriberVariable<TKey, TNotificationEventSubscriber>
        where TDbContext : DbContext
    {
        public DaNotificationEventRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TNotificationEvent> NotificationEventsSet { get { return DbContext.Set<TNotificationEvent>(); } }

        public IQueryable<TNotificationEvent> NotificationEvents => NotificationEventsSet.AsQueryable();

        public Task CreateAsync(TNotificationEvent notification)
        {
            NotificationEventsSet.Add(notification);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TNotificationEvent notification)
        {
            NotificationEventsSet.Remove(notification);
            return SaveChangesAsync();
        }

        public Task<TNotificationEvent> FindByIdAsync(TKey id)
        {
            return NotificationEventsSet.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TNotificationEvent notificationEvent)
        {
            DbContext.Update(notificationEvent);
            return SaveChangesAsync();
        }

        public Task UpdateAsync(List<TNotificationEvent> notificationEvents)
        {
            DbContext.UpdateRange(notificationEvents);
            return SaveChangesAsync();
        }

        public Task<List<TNotificationEvent>> FindUnprocessedAsync(int count)
        {
            return NotificationEventsSet
                .Where(m => m.IsProcessingComplete == false)
                .Include(m => m.Channels)
                .Include(m => m.Subscribers.Where(n => n.IsNotificationCreated == false))
                .ThenInclude(m => m.Variables)
                .Take(count).ToListAsync();
        }
    }
}
