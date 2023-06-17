// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Notifications.Delivery;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public class DaNotificationEventManager<TKey, TNotificationEvent> : DaEntityManagerBase<TKey, TNotificationEvent>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
    {
        public DaNotificationEventManager(IDaNotificationEventRepository<TKey, TNotificationEvent> repository)
            : base(repository)
        {
        }

        protected virtual IDaNotificationEventRepository<TKey, TNotificationEvent> Repository
        {
            get
            {
                return GetRepository<IDaNotificationEventRepository<TKey, TNotificationEvent>>();
            }
        }

        public IQueryable<TNotificationEvent> NotificationEvents
        {
            get
            {
                return Repository.NotificationEvents;
            }
        }

        public virtual async Task CreateAsync(TNotificationEvent notificationEvent)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationEvent, nameof(notificationEvent));

            await Repository.CreateAsync(notificationEvent);
        }

        public virtual void Create(TNotificationEvent notificationEvent)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(notificationEvent));
        }

        public virtual async Task UpdateAsync(TNotificationEvent notificationEvent)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationEvent, nameof(notificationEvent));

            await Repository.UpdateAsync(notificationEvent);
        }

        public virtual void Update(TNotificationEvent notificationEvent)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(notificationEvent));
        }

        public virtual async Task DeleteAsync(TNotificationEvent notificationEvent)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationEvent, nameof(notificationEvent));

            await Repository.DeleteAsync(notificationEvent);
        }

        public virtual void Delete(TNotificationEvent notificationEvent)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(notificationEvent));
        }

        public virtual TNotificationEvent FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public virtual Task<TNotificationEvent> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public DaPaginatedEntityList<TKey, TNotificationEvent> FindUnprocessed(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync(() => FindUnprocessedAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TNotificationEvent>> FindUnprocessedAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindUnprocessedAsync(paginationCriteria);
        }
    }
}