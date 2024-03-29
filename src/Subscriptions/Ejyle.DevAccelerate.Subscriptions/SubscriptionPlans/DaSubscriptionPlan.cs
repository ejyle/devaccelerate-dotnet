// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright � Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Subscriptions.Subscriptions;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans
{
    public class DaSubscriptionPlan : DaSubscriptionPlan<string, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscription>
    {
        public DaSubscriptionPlan() : base()
        { }
    }

    public class DaSubscriptionPlan<TKey, TSubscriptionPlanAttribute, TBillingCycleOptions, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription> : DaAuditedEntityBase<TKey>, IDaSubscriptionPlan<TKey>        
        where TKey : IEquatable<TKey>
        where TSubscriptionPlanAttribute : IDaSubscriptionPlanAttribute<TKey>
        where TBillingCycleOptions : IDaBillingCycleOption<TKey>
        where TSubscriptionPlanFeature : IDaSubscriptionPlanFeature<TKey>
        where TSubscriptionPlanApp : IDaSubscriptionPlanApp<TKey>
        where TSubscription : IDaSubscription<TKey>
    {
        public DaSubscriptionPlan()
        {
            Attributes = new HashSet<TSubscriptionPlanAttribute>();
            BillingCycleOptions = new HashSet<TBillingCycleOptions>();
            SubscriptionPlanApps = new HashSet<TSubscriptionPlanApp>();
            SubscriptionPlanFeatures = new HashSet<TSubscriptionPlanFeature>();
            Subscriptions = new HashSet<TSubscription>();
        }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Code { get; set; }

        public bool IsAutoRenewUntilCanceled { get; set; }

        public int? ValidityInMonths { get; set; }

        public bool IsFeatured { get; set; }

        public DaSubscriptionPlanStatus Status { get; set; }

        public string Currency { get; set; }

        public double? SetupFee { get; set; }

        public int Level { get; set; }

        public bool AllowTrial { get; set; }

        public bool StartOnlyWithTrial { get; set; }

        public int? TrialDays { get; set; }

        public bool IsFree { get; set; }

        public string UserAgreementVersionId { get; set; }

        public DateTime? PublishedDateUtc { get; set; }

        public TKey DefaultBillingCycleId { get; set; }

        public virtual ICollection<TSubscriptionPlanAttribute> Attributes { get; set; }

        public virtual ICollection<TBillingCycleOptions> BillingCycleOptions { get; set; }

        public virtual ICollection<TSubscriptionPlanApp> SubscriptionPlanApps { get; set; }

        public virtual ICollection<TSubscriptionPlanFeature> SubscriptionPlanFeatures { get; set; }

        public virtual ICollection<TSubscription> Subscriptions { get; set; }

        public DaBillingType BillingType { get; set; }
    }
}
