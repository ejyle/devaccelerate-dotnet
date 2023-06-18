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

namespace Ejyle.DevAccelerate.Notifications.Delivery
{
    public interface IDaNotificationRepository<TKey, TNotification> : IDaEntityRepository<TKey, TNotification>
        where TKey : IEquatable<TKey>
        where TNotification : IDaNotification<TKey>
    {
        IQueryable<TNotification> Notifications { get; }
        Task CreateAsync(TNotification notification);
        Task CreateAsync(List<TNotification> notifications);
        Task<TNotification> FindByIdAsync(TKey id);
        Task UpdateAsync(TNotification notification);
        Task UpdateAsync(List<TNotification> notifications);
        Task DeleteAsync(TNotification notification);
        Task<DaPaginatedEntityList<TKey, TNotification>> FindAsync(DaDataPaginationCriteria paginationCriteria, DaNotificationStatus? status, DaNotificationChannel? channel);
    }
}
