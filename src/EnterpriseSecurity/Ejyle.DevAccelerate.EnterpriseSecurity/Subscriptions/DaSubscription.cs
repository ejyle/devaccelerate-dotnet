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

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscription : DaSubscription<int, int?, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionPlan, DaBillingCycle>
    {
        public DaSubscription() : base()
        { }
    }

    public class DaSubscription<TKey, TNullableKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle> : DaAuditedEntityBase<TKey>, IDaSubscription<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionAttribute : IDaSubscriptionAttribute<TKey>
        where TSubscriptionApp : IDaSubscriptionApp<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey, TNullableKey>
        where TBillingCycle : IDaBillingCycle<TKey, TNullableKey>
    {
        public DaSubscription()
        {
            Attributes = new HashSet<TSubscriptionAttribute>();
            SubscriptionApps = new HashSet<TSubscriptionApp>();
            SubscriptionFeatures = new HashSet<TSubscriptionFeature>();
            BillingCycles = new HashSet<TBillingCycle>();
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsFree { get; set; }
        public DateTime? ExpiryDateUtc { get; set; }
        public TKey CurrencyId { get; set; }
        public TKey CountryId { get; set; }
        public decimal BillingAmount { get; set; }
        public DaBillingInterval? BillingInterval { get; set; }
        public TKey TenantId { get; set; }
        public int Level { get; set; }
        public TNullableKey UserAgreementVersionId { get; set; }
        public TKey OwnerUserId { get; set; }
        public TNullableKey LastTransactionId { get; set; }
        public TNullableKey LastPaymentMethodId { get; set; }
        public TKey SubscriptionPlanId { get; set; }
        public bool IsCurrentlyInTrial { get; set; }

        public virtual ICollection<TSubscriptionAttribute> Attributes { get; set; }

        public virtual ICollection<TSubscriptionApp> SubscriptionApps { get; set; }

        public virtual ICollection<TSubscriptionFeature> SubscriptionFeatures { get; set; }

        public virtual ICollection<TBillingCycle> BillingCycles { get; set; }

        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }

        public DateTime? TrialPeriodStartDateUtc { get; set; }

        public DateTime? TrialPeriodEndDateUtc { get; set; }

        public DateTime StartDateUtc { get; set; }

        public bool IsAutoRenewUntilCanceled { get; set; }

        public string ReferenceNumber { get; set; }

        public DateTime? NextBillingDateUtc { get; set; }

        public DateTime? TrialStartDateUtc { get; set; }

        public DaBillingType BillingType { get; set; }
    }
}
