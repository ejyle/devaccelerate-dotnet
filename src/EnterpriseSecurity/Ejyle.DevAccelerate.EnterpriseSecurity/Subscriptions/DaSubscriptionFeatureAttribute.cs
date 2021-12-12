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

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<int, DaSubscriptionFeature>
    {
        public DaSubscriptionFeatureAttribute()
            : base()
        { }
    }

    public class DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature> : DaAuditedEntityBase<TKey>, IDaSubscriptionFeatureAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
    {
        [Required]
        public TKey SubscriptionFeatureId { get; set; }

        [Required]
        [StringLength(256)]
        public string AttributeName { get; set; }
        public string? AttributeValue { get; set; }
        public virtual TSubscriptionFeature SubscriptionFeature { get; set; }
    }
}
