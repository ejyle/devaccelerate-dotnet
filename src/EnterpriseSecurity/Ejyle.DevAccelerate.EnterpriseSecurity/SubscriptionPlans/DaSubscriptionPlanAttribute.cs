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
    public class DaSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<int, int?, DaSubscriptionPlan>
    {
        public DaSubscriptionPlanAttribute() : base()
        { }
    }

    public class DaSubscriptionPlanAttribute<TKey, TNullableKey, TSubscriptionPlan> : DaEntityBase<TKey>, IDaSubscriptionPlanAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey, TNullableKey>
    {
        public TKey SubscriptionPlanId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public DaSubscriptionPlanAttributeTarget Target { get; set; }
        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
