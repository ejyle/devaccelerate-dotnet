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
    public class DaNotificationSubscriberManager<TKey, TNotificationSubscriber>
         : DaEntityManagerBase<TKey, TNotificationSubscriber>
        where TKey : IEquatable<TKey>
        where TNotificationSubscriber : IDaNotificationSubscriber<TKey>
    {
        public DaNotificationSubscriberManager(IDaNotificationSubscriberRepository<TKey, TNotificationSubscriber> repository)
            : base(repository)
        { }

        private IDaNotificationSubscriberRepository<TKey, TNotificationSubscriber> GetRepository()
        {
            return GetRepository<IDaNotificationSubscriberRepository<TKey, TNotificationSubscriber>>();
        }

        public Task CreateAsync(TNotificationSubscriber subscriber)
        {
            return GetRepository().CreateAsync(subscriber);
        }

        public void Create(TNotificationSubscriber subscriber)
        {
            GetRepository().Create(subscriber);
        }

        public Task UpdateAsync(TNotificationSubscriber subscriber)
        {
            return GetRepository().UpdateAsync(subscriber);
        }

        public void Update(TNotificationSubscriber subscriber)
        {
            GetRepository().Update(subscriber);
        }

        public Task DeleteAsync(TNotificationSubscriber subscriber)
        {
            return GetRepository().DeleteAsync(subscriber);
        }

        public void Delete(TNotificationSubscriber subscriber)
        {
            GetRepository().Delete(subscriber);
        }

        public Task<TNotificationSubscriber> FindByIdAsync(TKey id)
        {
            return GetRepository().FindByIdAsync(id);
        }

        public TNotificationSubscriber FindById(TKey id)
        {
            return GetRepository().FindById(id);
        }

        public Task<List<TNotificationSubscriber>> FindByDestinationAsync(string destination)
        {
            return GetRepository().FindByDestinationAsync(destination);
        }

        public List<TNotificationSubscriber> FindByDestination(string destination)
        {
            return GetRepository().FindByDestination(destination);
        }
    }
}
