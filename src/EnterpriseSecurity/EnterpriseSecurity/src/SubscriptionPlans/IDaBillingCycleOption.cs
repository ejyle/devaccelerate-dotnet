// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public interface IDaBillingCycleOption<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string Description { get; set; }
        TKey SubscriptionPlanId { get; set; }
        DaBillingCycleType BillingCycleType { get; set; }
        int BillingCycleDuration { get; set; }
        decimal Amount { get; set; }
    }
}
