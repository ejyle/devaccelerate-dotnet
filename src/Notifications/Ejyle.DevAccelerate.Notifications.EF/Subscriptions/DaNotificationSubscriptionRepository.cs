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
using Ejyle.DevAccelerate.Notifications.EventDefinitions;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using System.Xml.Linq;

/* Unmerged change from project 'Ejyle.DevAccelerate.Notifications.EF (netcoreapp3.1)'
Before:
using Ejyle.DevAccelerate.Notifications.Subscriptions;
After:
using Ejyle.DevAccelerate.Notifications.Subscriptions;
using Ejyle;
using Ejyle.DevAccelerate;
using Ejyle.DevAccelerate.Notifications;
using Ejyle.DevAccelerate.Notifications.EF;
using Ejyle.DevAccelerate.Notifications.EF.Subscriptions;
*/
using Ejyle.DevAccelerate.Notifications.Subscriptions;

namespace Ejyle.DevAccelerate.Notifications.EF.Subscriptions
{
    public class DaNotificationSubscriptionRepository : DaNotificationSubscriptionRepository<string, DaNotificationSubscription, DbContext>
    {
        public DaNotificationSubscriptionRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaNotificationSubscriptionRepository<TKey, TNotificationSubscription, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationSubscription, TDbContext>, IDaNotificationSubscriptionRepository<TKey, TNotificationSubscription>
        where TKey : IEquatable<TKey>
        where TNotificationSubscription : DaNotificationSubscription<TKey>
        where TDbContext : DbContext
    {
        public DaNotificationSubscriptionRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TNotificationSubscription> NotificationSubscriptions { get { return DbContext.Set<TNotificationSubscription>(); } }

        public Task CreateAsync(TNotificationSubscription notificationSubscription)
        {
            NotificationSubscriptions.Add(notificationSubscription);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TNotificationSubscription notificationSubscription)
        {
            NotificationSubscriptions.Remove(notificationSubscription);
            return SaveChangesAsync();
        }

        public Task<TNotificationSubscription> FindByIdAsync(TKey id)
        {
            return NotificationSubscriptions.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<List<TNotificationSubscription>> FindByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TNotificationSubscription notificationSubscription)
        {
            DbContext.Entry(notificationSubscription).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
