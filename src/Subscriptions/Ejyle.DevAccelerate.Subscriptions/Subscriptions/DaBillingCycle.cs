// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Subscriptions.Subscriptions
{
    public class DaBillingCycle : DaBillingCycle<string,  DaBillingCycleAttribute, DaSubscription, DaBillingCycleFeatureUsage>
    {
        public DaBillingCycle() : base()
        { }
    }

    public class DaBillingCycle<TKey, TAttribute, TSubscription, TBillingCycleFeatureUsage> : DaAuditedEntityBase<TKey>, IDaBillingCycle<TKey>
        where TKey : IEquatable<TKey>
        where TAttribute : IDaBillingCycleAttribute<TKey>
        where TSubscription : IDaSubscription<TKey>
        where TBillingCycleFeatureUsage : IDaBillingCycleFeatureUsage<TKey>
    {
        public DaBillingCycle() : base()
        {
            Attributes = new HashSet<TAttribute>();
            FeatureUsage = new HashSet<TBillingCycleFeatureUsage>();
        }

        public TKey SubscriptionId { get; set; }
        public DateTime FromDateUtc { get; set; }
        public DateTime? ToDateUtc { get; set; }
        public decimal? Amount { get; set; }
        public TKey CurrencyId { get; set; }
        public TKey InvoiceId { get; set; }
        public bool IsPaid { get; set; }
        public TKey TransactionId { get; set; }
        public virtual TSubscription Subscription { get; set; }
        public virtual ICollection<TAttribute> Attributes { get; set; }
        public virtual ICollection<TBillingCycleFeatureUsage> FeatureUsage { get; set; }
    }
}