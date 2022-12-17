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
    public class DaBillingCycleOption : DaBillingCycleOption<string, DaSubscriptionPlan>
    {
        public DaBillingCycleOption() : base()
        { }
    }

    public class DaBillingCycleOption<TKey, TSubscriptionPlan> : DaAuditedEntityBase<TKey>, IDaBillingCycleOption<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey>
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
