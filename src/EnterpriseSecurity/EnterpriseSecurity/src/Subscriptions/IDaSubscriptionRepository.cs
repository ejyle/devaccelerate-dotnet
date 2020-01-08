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

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public interface IDaSubscriptionRepository<TKey, TNullableKey, TSubscription>
        : IDaEntityRepository<TKey, TSubscription>
        where TKey : IEquatable<TKey>
        where TSubscription : IDaSubscription<TKey, TNullableKey>
    {
        Task CreateAsync(TSubscription subscription);
        Task UpdateAsync(TSubscription subscription);
        Task<TSubscription> FindByIdAsync(TKey id);
        Task<List<TSubscription>> FindByTenantIdAsync(TKey tenantId);
        Task<List<TSubscription>> FindAllAsync();
        Task UpdateBillingCycleAttributeAsync(TKey billingCycleAttributeId, string value);
    }
}
