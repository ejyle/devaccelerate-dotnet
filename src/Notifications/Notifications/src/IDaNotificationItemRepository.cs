// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications
{
    public interface IDaNotificationItemRepository<TKey, TNotificationItem>
        : IDaEntityRepository<TKey, TNotificationItem>
        where TKey : IEquatable<TKey>
        where TNotificationItem : IDaNotificationItem<TKey>
    {
        Task CreateAsync(TNotificationItem subscriber);
        void Create(TNotificationItem subscriber);

        Task UpdateAsync(TNotificationItem subscriber);
        void Update(TNotificationItem subscriber);

        Task DeleteAsync(TNotificationItem subscriber);
        void Delete(TNotificationItem subscriber);

        Task<TNotificationItem> FindByIdAsync(TKey id);
        TNotificationItem FindById(TKey id);

        Task<List<TNotificationItem>> FindByStatusAsync(DaNotificationItemStatus status, int start, int length);
        List<TNotificationItem> FindByStatus(DaNotificationItemStatus status, int start, int length);
    }
}
