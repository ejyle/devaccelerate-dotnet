// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EF;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationEventRepository : DaNotificationEventRepository<int, int?, DaNotificationSubscriber, DaNotificationEvent, DaNotificationEventSubscriber, DaNotificationSubscriberDestination, DaNotificationItem, DaNotificationsDbContext>
    {
        public DaNotificationEventRepository(DaNotificationsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaNotificationEventRepository<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationSubscriber, TDbContext>, IDaNotificationEventRepository<TKey, TNotificationEvent>
        where TKey : IEquatable<TKey>
        where TNotificationSubscriber : DaNotificationSubscriber<TKey, TNotificationEventSubscriber, TNotificationSubscriberDestination>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventSubscriber>
        where TNotificationSubscriberDestination : DaNotificationSubscriberDestination<TKey, TNotificationSubscriber, TNotificationEventSubscriber>
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationSubscriber, TNotificationSubscriberDestination>
        where TNotificationItem : DaNotificationItem<TKey>
        where TDbContext : DaNotificationsDbContext<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem>
    {
        public DaNotificationEventRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public void Create(TNotificationEvent e)
        {
            DbContext.Events.Add(e);
            DbContext.SaveChanges();
        }

        public Task CreateAsync(TNotificationEvent e)
        {
            DbContext.Events.Add(e);
            return DbContext.SaveChangesAsync();
        }

        public void Delete(TNotificationEvent e)
        {
            DbContext.Events.Remove(e);
            DbContext.SaveChanges();
        }

        public Task DeleteAsync(TNotificationEvent e)
        {
            DbContext.Events.Remove(e);
            return DbContext.SaveChangesAsync();
        }

        public TNotificationEvent FindById(TKey id)
        {
            return DbContext.Events.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TNotificationEvent> FindByIdAsync(TKey id)
        {
            return DbContext.Events.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void Update(TNotificationEvent e)
        {
            DbContext.Entry(e).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public Task UpdateAsync(TNotificationEvent e)
        {
            DbContext.Entry(e).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }
    }
}
