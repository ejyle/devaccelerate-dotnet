// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public class DaSubscriptionPlanFeature : DaSubscriptionPlanFeature<string, DaFeature, DaSubscriptionPlanFeatureAttribute, DaSubscriptionPlan>
    {
        public DaSubscriptionPlanFeature() : base()
        { }
    }

    public class DaSubscriptionPlanFeature<TKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan> : DaEntityBase<TKey>, IDaSubscriptionPlanFeature<TKey>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey>
        where TSubscriptionPlanFeatureAttribute : IDaSubscriptionPlanFeatureAttribute<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey>
    {
        public DaSubscriptionPlanFeature()
        {
            SubscriptionPlanFeatureAttributes = new HashSet<TSubscriptionPlanFeatureAttribute>();
        }

        public TKey SubscriptionPlanId { get; set; }
        public TKey FeatureId { get; set; }
        public virtual TFeature Feature { get; set; }
        public bool IsPremium { get; set; }
        public double? MaximumQuantity { get; set; }
        public DaSubscriptionPlanFeatureType SubscriptionPlanFeatureType { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<TSubscriptionPlanFeatureAttribute> SubscriptionPlanFeatureAttributes { get; set; }
        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
