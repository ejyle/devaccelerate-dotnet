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

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public class DaNotificationRequestManager<TKey, TNotificationRequest> : DaEntityManagerBase<TKey, TNotificationRequest>
        where TKey : IEquatable<TKey>
        where TNotificationRequest : IDaNotificationRequest<TKey>
    {
        public DaNotificationRequestManager(IDaNotificationRequestRepository<TKey, TNotificationRequest> repository)
            : base(repository)
        {
        }

        protected virtual IDaNotificationRequestRepository<TKey, TNotificationRequest> Repository
        {
            get
            {
                return GetRepository<IDaNotificationRequestRepository<TKey, TNotificationRequest>>();
            }
        }

        public IQueryable<TNotificationRequest> NotificationRequests
        {
            get
            {
                return Repository.NotificationRequests;
            }
        }

        public virtual async Task CreateAsync(TNotificationRequest notificationRequest)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationRequest, nameof(notificationRequest));

            await Repository.CreateAsync(notificationRequest);
        }

        public virtual void Create(TNotificationRequest notificationRequest)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(notificationRequest));
        }

        public virtual async Task UpdateAsync(TNotificationRequest notificationRequest)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationRequest, nameof(notificationRequest));

            await Repository.UpdateAsync(notificationRequest);
        }

        public virtual void Update(TNotificationRequest notificationRequest)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(notificationRequest));
        }

        public virtual async Task DeleteAsync(TNotificationRequest notificationRequest)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationRequest, nameof(notificationRequest));

            await Repository.DeleteAsync(notificationRequest);
        }

        public virtual void Delete(TNotificationRequest notificationRequest)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(notificationRequest));
        }

        public virtual TNotificationRequest FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public virtual Task<TNotificationRequest> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public DaPaginatedEntityList<TKey, TNotificationRequest> FindUnprocessed(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync(() => FindUnprocessedAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TNotificationRequest>> FindUnprocessedAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindUnprocessedAsync(paginationCriteria);
        }
    }
}