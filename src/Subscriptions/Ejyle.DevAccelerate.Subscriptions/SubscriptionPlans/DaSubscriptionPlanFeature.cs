// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans
{
    public class DaSubscriptionPlanFeature : DaSubscriptionPlanFeature<string, DaSubscriptionPlanFeatureAttribute, DaSubscriptionPlan>
    {
        public DaSubscriptionPlanFeature() : base()
        { }
    }

    public class DaSubscriptionPlanFeature<TKey, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan> : DaEntityBase<TKey>, IDaSubscriptionPlanFeature<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlanFeatureAttribute : IDaSubscriptionPlanFeatureAttribute<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey>
    {
        public DaSubscriptionPlanFeature()
        {
            SubscriptionPlanFeatureAttributes = new HashSet<TSubscriptionPlanFeatureAttribute>();
        }

        public TKey SubscriptionPlanId { get; set; }
        public TKey FeatureId { get; set; }
        public bool IsPremium { get; set; }
        public double? MaximumQuantity { get; set; }
        public DaSubscriptionPlanFeatureType SubscriptionPlanFeatureType { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<TSubscriptionPlanFeatureAttribute> SubscriptionPlanFeatureAttributes { get; set; }
        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
