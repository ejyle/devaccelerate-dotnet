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
    public class DaBillingCycleOption : DaBillingCycleOption<int, int?, DaSubscriptionPlan>
    {
        public DaBillingCycleOption() : base()
        { }
    }

    public class DaBillingCycleOption<TKey, TNullableKey, TSubscriptionPlan> : DaEntityBase<TKey>, IDaBillingCycleOption<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey, TNullableKey>
    {
        public DaBillingCycleOption() : base()
        { }

        public DaBillingInterval BillingInterval { get; set; }

        public decimal Amount { get; set; }

        public TKey SubscriptionPlanId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
