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
    public class DaNotificationEventManager<TKey, TNotificationEvent>
         : DaEntityManagerBase<TKey, TNotificationEvent>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
    {
        public DaNotificationEventManager(IDaNotificationEventRepository<TKey, TNotificationEvent> repository)
            : base(repository)
        { }

        private IDaNotificationEventRepository<TKey, TNotificationEvent> GetRepository()
        {
            return GetRepository<IDaNotificationEventRepository<TKey, TNotificationEvent>>();
        }

        public Task CreateAsync(TNotificationEvent e)
        {
            return GetRepository().CreateAsync(e);
        }

        public void Create(TNotificationEvent e)
        {
            GetRepository().Create(e);
        }

        public Task UpdateAsync(TNotificationEvent e)
        {
            return GetRepository().UpdateAsync(e);
        }

        public void Update(TNotificationEvent e)
        {
            GetRepository().Update(e);
        }

        public Task DeleteAsync(TNotificationEvent e)
        {
            return GetRepository().DeleteAsync(e);
        }

        public void Delete(TNotificationEvent e)
        {
            GetRepository().Delete(e);
        }

        public Task<TNotificationEvent> FindByIdAsync(TKey id)
        {
            return GetRepository().FindByIdAsync(id);
        }

        public TNotificationEvent FindById(TKey id)
        {
            return GetRepository().FindById(id);
        }
    }
}
