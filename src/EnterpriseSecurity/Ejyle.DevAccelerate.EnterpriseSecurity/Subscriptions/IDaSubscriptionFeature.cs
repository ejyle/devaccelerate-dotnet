// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public interface IDaSubscriptionFeature<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey SubscriptionId { get; set; }
        TKey FeatureId { get; set; }
        bool IsActive { get; set; }
        bool IsPremium { get; set; }
        double? MaximumQuantity { get; set; }
        double? Quantity { get; set; }
        DaSubscriptionPlanFeatureType SubscriptionPlanFeatureType { get; set; }
    }
}
