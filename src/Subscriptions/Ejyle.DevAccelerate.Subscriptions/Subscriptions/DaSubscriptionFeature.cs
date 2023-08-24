// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Subscriptions.Subscriptions
{
    public class DaSubscriptionFeature : DaSubscriptionFeature<string, DaSubscriptionFeatureAttribute, DaSubscriptionFeatureRole, DaSubscription, DaSubscriptionFeatureUser, DaBillingCycleFeatureUsage>
    {
        public DaSubscriptionFeature() : base()
        { }
    }

    public class DaSubscriptionFeature<TKey, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage> : DaEntityBase<TKey>, IDaSubscriptionFeature<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeatureAttribute : IDaSubscriptionFeatureAttribute<TKey>
        where TSubscriptionFeatureRole : IDaSubscriptionFeatureRole<TKey>
        where TSubscription : IDaSubscription<TKey>
        where TSubscriptionFeatureUser : IDaSubscriptionFeatureUser<TKey>
        where TBillingCycleFeatureUsage : IDaBillingCycleFeatureUsage<TKey>
    {
        public DaSubscriptionFeature()
        {
            SubscriptionFeatureAttributes = new HashSet<TSubscriptionFeatureAttribute>();
            SubscriptionFeatureRoles = new HashSet<TSubscriptionFeatureRole>();
            SubscriptionFeatureUsers = new HashSet<TSubscriptionFeatureUser>();
            FeatureUsage = new HashSet<TBillingCycleFeatureUsage>();
        }

        public TKey SubscriptionId { get; set; }
        public TKey FeatureId { get; set; }
        public bool IsPremium { get; set; }
        public double? MaximumQuantity { get; set; }
        public double? Quantity { get; set; }
        public bool IsActive { get; set; }

        public DaSubscriptionPlanFeatureType SubscriptionPlanFeatureType { get; set; }
        public virtual ICollection<TSubscriptionFeatureAttribute> SubscriptionFeatureAttributes { get; set; }
        public virtual ICollection<TSubscriptionFeatureRole> SubscriptionFeatureRoles { get; set; }
        public virtual TSubscription Subscription { get; set; }
        public virtual ICollection<TSubscriptionFeatureUser> SubscriptionFeatureUsers { get; set; }
        public virtual ICollection<TBillingCycleFeatureUsage> FeatureUsage { get; set; }
    }
}
