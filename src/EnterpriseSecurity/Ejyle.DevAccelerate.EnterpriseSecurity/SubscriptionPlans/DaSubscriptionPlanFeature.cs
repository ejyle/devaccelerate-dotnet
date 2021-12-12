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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public class DaSubscriptionPlanFeature : DaSubscriptionPlanFeature<int, int?, DaFeature, DaSubscriptionPlanFeatureAttribute, DaSubscriptionPlan>
    {
        public DaSubscriptionPlanFeature() : base()
        { }
    }

    public class DaSubscriptionPlanFeature<TKey, TNullableKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan> : DaAuditedEntityBase<TKey>, IDaSubscriptionPlanFeature<TKey>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey, TNullableKey>
        where TSubscriptionPlanFeatureAttribute : IDaSubscriptionPlanFeatureAttribute<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey, TNullableKey>
    {
        public DaSubscriptionPlanFeature()
        {
            SubscriptionPlanFeatureAttributes = new HashSet<TSubscriptionPlanFeatureAttribute>();
        }

        [Required]
        public TKey SubscriptionPlanId { get; set; }

        [Required]
        public TKey FeatureId { get; set; }
        public virtual TFeature Feature { get; set; }

        [Required]
        public bool IsPremium { get; set; }
        public double? MaximumQuantity { get; set; }
        public DaSubscriptionPlanFeatureType SubscriptionPlanFeatureType { get; set; }
       
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<TSubscriptionPlanFeatureAttribute> SubscriptionPlanFeatureAttributes { get; set; }
        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
