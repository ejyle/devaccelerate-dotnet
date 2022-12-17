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

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public interface IDaSubscriptionPlanRepository<TKey, TSubscriptionPlan>
        : IDaEntityRepository<TKey, TSubscriptionPlan>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey>
    {
        Task CreateAsync(TSubscriptionPlan subscriptionPlan);
        Task UpdateAsync(TSubscriptionPlan subscriptionPlan);
        Task DeleteAsync(TSubscriptionPlan subscriptionPlan);
        Task<List<TSubscriptionPlan>> FindAllAsync();
        Task<TSubscriptionPlan> FindByIdAsync(TKey id);
        Task<TSubscriptionPlan> FindByCodeAsync(string code);
    }
}
