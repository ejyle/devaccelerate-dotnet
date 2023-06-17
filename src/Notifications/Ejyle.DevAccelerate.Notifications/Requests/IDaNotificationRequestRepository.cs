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

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public interface IDaNotificationRequestRepository<TKey, TNotificationRequest> : IDaEntityRepository<TKey, TNotificationRequest>
        where TKey : IEquatable<TKey>
        where TNotificationRequest : IDaNotificationRequest<TKey>
    {
        IQueryable<TNotificationRequest> NotificationRequests { get; }
        Task CreateAsync(TNotificationRequest notificationRequest);
        Task<TNotificationRequest> FindByIdAsync(TKey id);
        Task UpdateAsync(TNotificationRequest notificationRequest);
        Task DeleteAsync(TNotificationRequest notificationRequest);
        Task<DaPaginatedEntityList<TKey, TNotificationRequest>> FindUnprocessedAsync(DaDataPaginationCriteria paginationCriteria);
    }
}
