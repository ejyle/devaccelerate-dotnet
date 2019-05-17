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
    public class DaNotificationSubscriberRepository : DaNotificationSubscriberRepository<int, int?, DaNotificationSubscriber, DaNotificationEvent, DaNotificationEventSubscriber, DaNotificationSubscriberDestination, DaNotificationItem, DaNotificationsDbContext>
    {
        public DaNotificationSubscriberRepository(DaNotificationsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaNotificationSubscriberRepository<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationSubscriber, TDbContext>, IDaNotificationSubscriberRepository<TKey, TNotificationSubscriber>
        where TKey : IEquatable<TKey>
        where TNotificationSubscriber : DaNotificationSubscriber<TKey, TNotificationEventSubscriber, TNotificationSubscriberDestination>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventSubscriber>
        where TNotificationSubscriberDestination : DaNotificationSubscriberDestination<TKey, TNotificationSubscriber, TNotificationEventSubscriber>
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationSubscriber, TNotificationSubscriberDestination>
        where TNotificationItem : DaNotificationItem<TKey>
        where TDbContext : DaNotificationsDbContext<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem>
    {
        public DaNotificationSubscriberRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public void Create(TNotificationSubscriber subscriber)
        {
            DbContext.Subscribers.Add(subscriber);
            DbContext.SaveChanges();
        }

        public Task CreateAsync(TNotificationSubscriber subscriber)
        {
            DbContext.Subscribers.Add(subscriber);
            return DbContext.SaveChangesAsync();
        }

        public void Delete(TNotificationSubscriber subscriber)
        {
            DbContext.Subscribers.Remove(subscriber);
            DbContext.SaveChanges();
        }

        public Task DeleteAsync(TNotificationSubscriber subscriber)
        {
            DbContext.Subscribers.Remove(subscriber);
            return DbContext.SaveChangesAsync();
        }

        public List<TNotificationSubscriber> FindByDestination(string destination)
        {
            return DbContext.Subscribers.Where(m => m.Destinations.Any(n => n.Destination == destination)).ToList();
        }

        public Task<List<TNotificationSubscriber>> FindByDestinationAsync(string destination)
        {
            return DbContext.Subscribers.Where(m => m.Destinations.Any(n => n.Destination == destination)).ToListAsync();
        }

        public TNotificationSubscriber FindById(TKey id)
        {
            return DbContext.Subscribers.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TNotificationSubscriber> FindByIdAsync(TKey id)
        {
            return DbContext.Subscribers.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void Update(TNotificationSubscriber subscriber)
        {
            DbContext.Entry(subscriber).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public Task UpdateAsync(TNotificationSubscriber subscriber)
        {
            DbContext.Entry(subscriber).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }
    }
}
