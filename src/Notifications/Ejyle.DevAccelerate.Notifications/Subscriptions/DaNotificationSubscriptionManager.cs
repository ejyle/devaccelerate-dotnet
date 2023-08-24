// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Subscriptions
{
    public class DaNotificationSubscriptionManager<TKey, TNotificationSubscription> : DaEntityManagerBase<TKey, TNotificationSubscription>
        where TKey : IEquatable<TKey>
        where TNotificationSubscription : IDaNotificationSubscription<TKey>
    {
        public DaNotificationSubscriptionManager(IDaNotificationSubscriptionRepository<TKey, TNotificationSubscription> repository)
            : base(repository)
        {
        }

        protected virtual IDaNotificationSubscriptionRepository<TKey, TNotificationSubscription> Repository
        {
            get
            {
                return GetRepository<IDaNotificationSubscriptionRepository<TKey, TNotificationSubscription>>();
            }
        }

        public virtual async Task CreateAsync(TNotificationSubscription notificationSubscription)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationSubscription, nameof(notificationSubscription));

            await Repository.CreateAsync(notificationSubscription);
        }

        public virtual void Create(TNotificationSubscription notificationSubscription)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(notificationSubscription));
        }

        public virtual async Task UpdateAsync(TNotificationSubscription notificationSubscription)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationSubscription, nameof(notificationSubscription));

            await Repository.UpdateAsync(notificationSubscription);
        }

        public virtual void Update(TNotificationSubscription notificationSubscription)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(notificationSubscription));
        }

        public virtual async Task DeleteAsync(TNotificationSubscription notificationSubscription)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationSubscription, nameof(notificationSubscription));

            await Repository.DeleteAsync(notificationSubscription);
        }

        public virtual void Delete(TNotificationSubscription notificationSubscription)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(notificationSubscription));
        }

        public virtual List<TNotificationSubscription> FindByUserId(string userId)
        {
            return DaAsyncHelper.RunSync(() => FindByUserIdAsync(userId));
        }

        public virtual Task<List<TNotificationSubscription>> FindByUserIdAsync(string userId)
        {
            ThrowIfDisposed();
            return Repository.FindByUserIdAsync(userId);
        }

        public virtual TNotificationSubscription FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public virtual Task<TNotificationSubscription> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }
    }
}