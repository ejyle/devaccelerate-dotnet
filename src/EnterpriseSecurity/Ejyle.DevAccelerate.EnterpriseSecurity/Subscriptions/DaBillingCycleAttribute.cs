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
    public class DaBillingCycleAttribute : DaBillingCycleAttribute<int, int?, DaBillingCycle>
    {
        public DaBillingCycleAttribute()
            : base()
        { }
    }

    public class DaBillingCycleAttribute<TKey, TNullableKey, TBillingCycle> : DaAuditedEntityBase<TKey>, IDaBillingCycleAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TBillingCycle : IDaBillingCycle<TKey, TNullableKey>
    {
        [Required]
        public TKey BillingCycleId { get; set; }

        [Required]
        [StringLength(256)]
        public string AttributeName { get; set; }
        public string? AttributeValue { get; set; }
        public virtual TBillingCycle BillingCycle { get; set; }
    }
}
