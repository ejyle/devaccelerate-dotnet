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
    public class DaSubscriptionPlanManager<TKey, TSubscriptionPlan> : DaEntityManagerBase<TKey, TSubscriptionPlan>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey>
    {
        public DaSubscriptionPlanManager(IDaSubscriptionPlanRepository<TKey, TSubscriptionPlan> repository)
            : base(repository)
        {
        }

        protected virtual IDaSubscriptionPlanRepository<TKey, TSubscriptionPlan> Repository
        {
            get
            {
                return GetRepository<IDaSubscriptionPlanRepository<TKey, TSubscriptionPlan>>();
            }
        }

        public virtual async Task CreateAsync(TSubscriptionPlan subscriptionPlan)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(subscriptionPlan, nameof(subscriptionPlan));

            await Repository.CreateAsync(subscriptionPlan);
        }

        public virtual void Create(TSubscriptionPlan subscriptionPlan)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(subscriptionPlan));
        }

        public virtual async Task UpdateAsync(TSubscriptionPlan subscriptionPlan)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(subscriptionPlan, nameof(subscriptionPlan));

            await Repository.UpdateAsync(subscriptionPlan);
        }

        public virtual void Update(TSubscriptionPlan subscriptionPlan)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(subscriptionPlan));
        }

        public virtual async Task DeleteAsync(TSubscriptionPlan subscriptionPlan)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(subscriptionPlan, nameof(subscriptionPlan));

            await Repository.DeleteAsync(subscriptionPlan);
        }

        public virtual void Delete(TSubscriptionPlan subscriptionPlan)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(subscriptionPlan));
        }

        public virtual Task<TSubscriptionPlan> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TSubscriptionPlan FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TSubscriptionPlan>(() => FindByIdAsync(id));
        }

        public virtual Task<List<TSubscriptionPlan>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public virtual List<TSubscriptionPlan> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TSubscriptionPlan>>(() => FindAllAsync());
        }
    }
}
