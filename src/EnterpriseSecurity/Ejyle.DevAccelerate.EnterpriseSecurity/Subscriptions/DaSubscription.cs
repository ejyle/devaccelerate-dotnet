// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright � Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsFree { get; set; }

        public DateTime? ExpiryDateUtc { get; set; }

        [Required]
        public TKey CurrencyId { get; set; }

        [Required]
        public TKey CountryId { get; set; }

        [Required]
        public decimal BillingAmount { get; set; }

        public DaBillingInterval? BillingInterval { get; set; }

        [Required]
        public TKey TenantId { get; set; }

        [Required]
        public int Level { get; set; }

        public TNullableKey UserAgreementVersionId { get; set; }

        [Required]
        public TKey OwnerUserId { get; set; }

        public TNullableKey LastTransactionId { get; set; }

        public TNullableKey LastPaymentMethodId { get; set; }

        [Required]
        public TKey SubscriptionPlanId { get; set; }

        [Required]
        public bool IsCurrentlyInTrial { get; set; }

        public virtual ICollection<TSubscriptionAttribute> Attributes { get; set; }

        public virtual ICollection<TSubscriptionApp> SubscriptionApps { get; set; }

        public virtual ICollection<TSubscriptionFeature> SubscriptionFeatures { get; set; }

        public virtual ICollection<TBillingCycle> BillingCycles { get; set; }

        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }

        public DateTime? TrialPeriodStartDateUtc { get; set; }

        public DateTime? TrialPeriodEndDateUtc { get; set; }

        [Required]
        public DateTime StartDateUtc { get; set; }

        [Required]
        public bool IsAutoRenewUntilCanceled { get; set; }

        public string? ReferenceNumber { get; set; }

        public DateTime? NextBillingDateUtc { get; set; }

        public DateTime? TrialStartDateUtc { get; set; }

        [Required]
        public DaBillingType BillingType { get; set; }
    }
}