// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<DaBillingCycle, DaSubscriptionFeature>
    { }

    public class DaBillingCycleFeatureUsage<TBillingCycle, TSubscriptionFeatue> : DaBillingCycleFeatureUsage<int, int?, TBillingCycle, TSubscriptionFeatue>
        where TBillingCycle : IDaBillingCycle<int, int?>
        where TSubscriptionFeatue : IDaSubscriptionFeature<int>
    { }

    public class DaBillingCycleFeatureUsage<TKey, TNullableKey, TBillingCycle, TSubscriptionFeature> : DaEntityBase<TKey>, IDaBillingCycleFeatureUsage<TKey>
        where TKey : IEquatable<TKey>
        where TBillingCycle : IDaBillingCycle<TKey, TNullableKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
    {
        public virtual TBillingCycle BillingCycle { get; set; }
        public virtual TSubscriptionFeature SubscriptionFeature { get; set; }
        public TKey BillingCycleId {get; set; }
        public TKey SubscriptionFeatureId {get; set; }
        public double Quantity {get; set; }
        public DateTime CreatedDateUtc {get; set; }
        public DateTime LastUpdatedDateUtc {get; set; }
    }
}
