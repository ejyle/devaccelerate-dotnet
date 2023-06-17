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

namespace Ejyle.DevAccelerate.Notifications.Delivery
{
    public class DaNotificationManager<TKey, TNotification> : DaEntityManagerBase<TKey, TNotification>
        where TKey : IEquatable<TKey>
        where TNotification : IDaNotification<TKey>
    {
        public DaNotificationManager(IDaNotificationRepository<TKey, TNotification> repository)
            : base(repository)
        {
        }

        protected virtual IDaNotificationRepository<TKey, TNotification> Repository
        {
            get
            {
                return GetRepository<IDaNotificationRepository<TKey, TNotification>>();
            }
        }

        public IQueryable<TNotification> Notifications
        {
            get
            {
                return Repository.Notifications;
            }
        }

        public virtual async Task CreateAsync(TNotification notification)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notification, nameof(notification));

            await Repository.CreateAsync(notification);
        }

        public virtual void Create(TNotification notification)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(notification));
        }

        public virtual async Task UpdateAsync(TNotification notification)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notification, nameof(notification));

            await Repository.UpdateAsync(notification);
        }

        public virtual void Update(TNotification notification)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(notification));
        }

        public virtual async Task DeleteAsync(TNotification notification)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notification, nameof(notification));

            await Repository.DeleteAsync(notification);
        }

        public virtual void Delete(TNotification notification)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(notification));
        }

        public virtual TNotification FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public virtual Task<TNotification> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public DaPaginatedEntityList<TKey, TNotification> FindByStatus(DaNotificationStatus status, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync(() => FindByStatusAsync(status, paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TNotification>> FindByStatusAsync(DaNotificationStatus status, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByStatusAsync(status, paginationCriteria);
        }
    }
}