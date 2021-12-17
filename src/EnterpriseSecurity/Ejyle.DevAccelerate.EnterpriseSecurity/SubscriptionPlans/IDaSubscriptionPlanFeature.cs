// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public interface IDaSubscriptionPlanFeature<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey SubscriptionPlanId { get; set; }
        TKey FeatureId { get; set; }
        bool IsPremium { get; set; }
        double? MaximumQuantity { get; set;}
        DaSubscriptionPlanFeatureType SubscriptionPlanFeatureType { get; set; }
        bool IsActive { get; set; }
    }
}
