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
    public interface IDaBillingCycleRepository<TKey, TBillingCycle>
        : IDaEntityRepository<TKey, TBillingCycle>
        where TKey : IEquatable<TKey>
        where TBillingCycle : IDaBillingCycleOption<TKey>
    {
        Task CreateAsync(TBillingCycle billingCycle);
        Task UpdateAsync(TBillingCycle billingCycle);
        Task DeleteAsync(TBillingCycle billingCycle);
        Task<List<TBillingCycle>> FindAllAsync();
        Task<TBillingCycle> FindByIdAsync(TKey id);
    }
}
