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
    public interface IDaNotificationSubscriberRepository<TKey, TNotificationSubscriber> 
        : IDaEntityRepository<TKey, TNotificationSubscriber>
        where TKey : IEquatable<TKey>
        where TNotificationSubscriber : IDaNotificationSubscriber<TKey>
    {
        Task CreateAsync(TNotificationSubscriber subscriber);
        void Create(TNotificationSubscriber subscriber);

        Task UpdateAsync(TNotificationSubscriber subscriber);
        void Update(TNotificationSubscriber subscriber);

        Task DeleteAsync(TNotificationSubscriber subscriber);
        void Delete(TNotificationSubscriber subscriber);

        Task<TNotificationSubscriber> FindByIdAsync(TKey id);
        TNotificationSubscriber FindById(TKey id);

        Task<List<TNotificationSubscriber>> FindByDestinationAsync(string destination);
        List<TNotificationSubscriber> FindByDestination(string destination);
    }
}
