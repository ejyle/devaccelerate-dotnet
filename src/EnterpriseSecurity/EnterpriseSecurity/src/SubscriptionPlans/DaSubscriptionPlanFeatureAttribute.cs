// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public class DaSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<int, DaSubscriptionPlanFeature>
    {
        public DaSubscriptionPlanFeatureAttribute() : base()
        { }
    }

    public class DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature> : DaEntityBase<TKey>, IDaSubscriptionPlanFeatureAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlanFeature : IDaSubscriptionPlanFeature<TKey>
    {
        public TKey SubscriptionPlanFeatureId { get; set; }
        [Required]
        [StringLength(256)]
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public virtual TSubscriptionPlanFeature SubscriptionPlanFeature { get; set; }
    }
}
