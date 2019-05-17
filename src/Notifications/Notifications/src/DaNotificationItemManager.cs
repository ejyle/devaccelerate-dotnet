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
    public class DaNotificationItemManager<TKey, TNotificationItem>
         : DaEntityManagerBase<TKey, TNotificationItem>
        where TKey : IEquatable<TKey>
        where TNotificationItem : IDaNotificationItem<TKey>
    {
        public DaNotificationItemManager(IDaNotificationItemRepository<TKey, TNotificationItem> repository)
            : base(repository)
        { }

        private IDaNotificationItemRepository<TKey, TNotificationItem> GetRepository()
        {
            return GetRepository<IDaNotificationItemRepository<TKey, TNotificationItem>>();
        }

        public Task CreateAsync(TNotificationItem subscriber)
        {
            return GetRepository().CreateAsync(subscriber);
        }

        public void Create(TNotificationItem subscriber)
        {
            GetRepository().Create(subscriber);
        }

        public Task UpdateAsync(TNotificationItem subscriber)
        {
            return GetRepository().UpdateAsync(subscriber);
        }

        public void Update(TNotificationItem subscriber)
        {
            GetRepository().Update(subscriber);
        }

        public Task DeleteAsync(TNotificationItem subscriber)
        {
            return GetRepository().DeleteAsync(subscriber);
        }

        public void Delete(TNotificationItem subscriber)
        {
            GetRepository().Delete(subscriber);
        }

        public Task<TNotificationItem> FindByIdAsync(TKey id)
        {
            return GetRepository().FindByIdAsync(id);
        }

        public TNotificationItem FindById(TKey id)
        {
            return GetRepository().FindById(id);
        }

        public Task<List<TNotificationItem>> FindByStatusAsync(DaNotificationItemStatus status, int start, int length)
        {
            return GetRepository().FindByStatusAsync(status, start, length);
        }

        public List<TNotificationItem> FindByStatus(DaNotificationItemStatus status, int start, int length)
        {
            return GetRepository().FindByStatus(status, start, length);
        }
    }
}
