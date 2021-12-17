// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public interface IDaBillingCycleFeatureUsage<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey BillingCycleId { get; set; }
        TKey SubscriptionFeatureId { get; set; }
        double Quantity { get; set; }
    }
}
