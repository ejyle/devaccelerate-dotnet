// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Notifications.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public interface IDaNotificationEventRepository<TKey, TNotificationEvent> : IDaEntityRepository<TKey, TNotificationEvent>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
    {
        IQueryable<TNotificationEvent> NotificationEvents { get; }
        Task CreateAsync(TNotificationEvent notificationEvent);
        Task<TNotificationEvent> FindByIdAsync(TKey id);
        Task UpdateAsync(TNotificationEvent notificationEvent);
        Task UpdateAsync(List<TNotificationEvent> notificationEvents);
        Task DeleteAsync(TNotificationEvent notificationEvent);
        Task<List<TNotificationEvent>> FindUnprocessedAsync(int count);
    }
}
