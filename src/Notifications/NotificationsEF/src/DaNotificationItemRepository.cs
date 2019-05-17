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
    public class DaNotificationItemRepository : DaNotificationItemRepository<int, int?, DaNotificationSubscriber, DaNotificationEvent, DaNotificationEventSubscriber, DaNotificationSubscriberDestination, DaNotificationItem, DaNotificationsDbContext>
    {
        public DaNotificationItemRepository(DaNotificationsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaNotificationItemRepository<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationSubscriber, TDbContext>, IDaNotificationItemRepository<TKey, TNotificationItem>
        where TKey : IEquatable<TKey>
        where TNotificationSubscriber : DaNotificationSubscriber<TKey, TNotificationEventSubscriber, TNotificationSubscriberDestination>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventSubscriber>
        where TNotificationSubscriberDestination : DaNotificationSubscriberDestination<TKey, TNotificationSubscriber, TNotificationEventSubscriber>
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationSubscriber, TNotificationSubscriberDestination>
        where TNotificationItem : DaNotificationItem<TKey>
        where TDbContext : DaNotificationsDbContext<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem>
    {
        public DaNotificationItemRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public void Create(TNotificationItem subscriber)
        {
            DbContext.Items.Add(subscriber);
            DbContext.SaveChanges();
        }

        public Task CreateAsync(TNotificationItem subscriber)
        {
            DbContext.Items.Add(subscriber);
            return DbContext.SaveChangesAsync();
        }

        public void Delete(TNotificationItem subscriber)
        {
            DbContext.Items.Remove(subscriber);
            DbContext.SaveChanges();
        }

        public Task DeleteAsync(TNotificationItem subscriber)
        {
            DbContext.Items.Remove(subscriber);
            return DbContext.SaveChangesAsync();
        }

        public TNotificationItem FindById(TKey id)
        {
            return DbContext.Items.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TNotificationItem> FindByIdAsync(TKey id)
        {
            return DbContext.Items.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public List<TNotificationItem> FindByStatus(DaNotificationItemStatus status, int start, int length)
        {
            return DbContext.Items.Where(m => m.Status == status).Skip((start - 1) * length).Take(length).ToList();
        }

        public Task<List<TNotificationItem>> FindByStatusAsync(DaNotificationItemStatus status, int start, int length)
        {
            return DbContext.Items.Where(m => m.Status == status).Skip((start - 1) * length).Take(length).ToListAsync();
        }

        public void Update(TNotificationItem subscriber)
        {
            DbContext.Entry(subscriber).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public Task UpdateAsync(TNotificationItem subscriber)
        {
            DbContext.Entry(subscriber).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }
    }
}
