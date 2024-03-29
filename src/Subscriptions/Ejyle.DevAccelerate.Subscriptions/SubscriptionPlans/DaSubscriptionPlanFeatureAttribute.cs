// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright � Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans
{
    public class DaSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<string, DaSubscriptionPlanFeature>
    {
        public DaSubscriptionPlanFeatureAttribute() : base()
        { }
    }

    public class DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature> : DaEntityBase<TKey>, IDaSubscriptionPlanFeatureAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlanFeature : IDaSubscriptionPlanFeature<TKey>
    {
        public TKey SubscriptionPlanFeatureId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TSubscriptionPlanFeature SubscriptionPlanFeature { get; set; }
    }
}
