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
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscriptionManager<TKey, TNullableKey, TSubscription> : DaEntityManagerBase<TKey, TSubscription>
        where TKey : IEquatable<TKey>
        where TSubscription : IDaSubscription<TKey, TNullableKey>
    {
        public DaSubscriptionManager(IDaSubscriptionRepository<TKey, TNullableKey, TSubscription> repository)
            : base(repository)
        {
        }

        protected virtual IDaSubscriptionRepository<TKey, TNullableKey, TSubscription> Repository
        {
            get
            {
                return GetRepository<IDaSubscriptionRepository<TKey, TNullableKey, TSubscription>>();
            }
        }

        public virtual async Task CreateAsync(TSubscription subscription)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(subscription, nameof(subscription));

            await Repository.CreateAsync(subscription);
        }

        public virtual void Create(TSubscription subscription)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(subscription));
        }

        public virtual async Task UpdateAsync(TSubscription subscription)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(subscription, nameof(subscription));

            await Repository.UpdateAsync(subscription);
        }

        public virtual void Update(TSubscription subscription)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(subscription));
        }

        public virtual Task<List<TSubscription>> FindByTenantIdAsync(TKey tenantId)
        {
            ThrowIfDisposed();
            return Repository.FindByTenantIdAsync(tenantId);
        }

        public virtual List<TSubscription> FindByTenantId(TKey tenantId)
        {
            return DaAsyncHelper.RunSync<List<TSubscription>>(() => FindByTenantIdAsync(tenantId));
        }

        public virtual Task<TSubscription> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TSubscription FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TSubscription>(() => FindByIdAsync(id));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TSubscription>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public virtual DaPaginatedEntityList<TKey, TSubscription> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TSubscription>>(() => FindAllAsync(paginationCriteria));
        }

        public virtual void SetBillingCycleFeatureUsageQuantity(TKey billingCycleFeatureUsageId, double value)
        {
            DaAsyncHelper.RunSync(() => SetBillingCycleFeatureUsageQuantityAsync(billingCycleFeatureUsageId, value));
        }

        public Task SetBillingCycleFeatureUsageQuantityAsync(TKey billingCycleFeatureUsageId, double value)
        {
            ThrowIfDisposed();
            return Repository.SetBillingCycleFeatureUsageQuantityAsync(billingCycleFeatureUsageId, value);
        }
    }
}
