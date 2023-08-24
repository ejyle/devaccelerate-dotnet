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

namespace Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans
{
    public class DaBillingCycleOptionManager<TKey, TBillingCycle> : DaEntityManagerBase<TKey, TBillingCycle>
        where TKey : IEquatable<TKey>
        where TBillingCycle : IDaBillingCycleOption<TKey>
    {
        public DaBillingCycleOptionManager(IDaBillingCycleRepository<TKey, TBillingCycle> repository)
            : base(repository)
        {
        }

        protected virtual IDaBillingCycleRepository<TKey, TBillingCycle> Repository
        {
            get
            {
                return GetRepository<IDaBillingCycleRepository<TKey, TBillingCycle>>();
            }
        }

        public virtual async Task CreateAsync(TBillingCycle billingCycle)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(billingCycle, nameof(billingCycle));

            await Repository.CreateAsync(billingCycle);
        }

        public virtual void Create(TBillingCycle billingCycle)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(billingCycle));
        }

        public virtual async Task UpdateAsync(TBillingCycle billingCycle)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(billingCycle, nameof(billingCycle));

            await Repository.UpdateAsync(billingCycle);
        }

        public virtual void Update(TBillingCycle billingCycle)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(billingCycle));
        }

        public virtual async Task DeleteAsync(TBillingCycle billingCycle)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(billingCycle, nameof(billingCycle));

            await Repository.DeleteAsync(billingCycle);
        }

        public virtual void Delete(TBillingCycle billingCycle)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(billingCycle));
        }

        public virtual Task<TBillingCycle> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TBillingCycle FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TBillingCycle>(() => FindByIdAsync(id));
        }

        public virtual Task<List<TBillingCycle>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public virtual List<TBillingCycle> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TBillingCycle>>(() => FindAllAsync());
        }
    }
}
