// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Subscriptions
{
    public interface IDaNotificationSubscriptionRepository<TKey, TNotificationSubscription> : IDaEntityRepository<TKey, TNotificationSubscription>
        where TKey : IEquatable<TKey>
        where TNotificationSubscription : IDaNotificationSubscription<TKey>
    {
        Task CreateAsync(TNotificationSubscription notificationSubscription);
        Task<List<TNotificationSubscription>> FindByUserIdAsync(string userId);
        Task<TNotificationSubscription> FindByIdAsync(TKey id);
        Task UpdateAsync(TNotificationSubscription notificationSubscription);
        Task DeleteAsync(TNotificationSubscription notificationSubscription);
    }
}
