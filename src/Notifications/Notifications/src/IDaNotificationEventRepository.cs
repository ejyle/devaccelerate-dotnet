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
    public interface IDaNotificationEventRepository<TKey, TNotificationEvent>
        : IDaEntityRepository<TKey, TNotificationEvent>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
    {
        Task CreateAsync(TNotificationEvent e);
        void Create(TNotificationEvent e);

        Task UpdateAsync(TNotificationEvent e);
        void Update(TNotificationEvent e);

        Task DeleteAsync(TNotificationEvent e);
        void Delete(TNotificationEvent e);

        Task<TNotificationEvent> FindByIdAsync(TKey id);
        TNotificationEvent FindById(TKey id);
    }
}
