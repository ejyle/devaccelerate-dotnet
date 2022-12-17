// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<DaBillingCycle, DaSubscriptionFeature>
    { }

    public class DaBillingCycleFeatureUsage<TBillingCycle, TSubscriptionFeatue> : DaBillingCycleFeatureUsage<string, TBillingCycle, TSubscriptionFeatue>
        where TBillingCycle : IDaBillingCycle<string>
        where TSubscriptionFeatue : IDaSubscriptionFeature<string>
    { }

    public class DaBillingCycleFeatureUsage<TKey, TBillingCycle, TSubscriptionFeature> : DaEntityBase<TKey>, IDaBillingCycleFeatureUsage<TKey>
        where TKey : IEquatable<TKey>
        where TBillingCycle : IDaBillingCycle<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
    {
        public virtual TBillingCycle BillingCycle { get; set; }
        public virtual TSubscriptionFeature SubscriptionFeature { get; set; }
        public TKey BillingCycleId {get; set; }
        public TKey SubscriptionFeatureId {get; set; }
        public double Quantity {get; set; }
    }
}
