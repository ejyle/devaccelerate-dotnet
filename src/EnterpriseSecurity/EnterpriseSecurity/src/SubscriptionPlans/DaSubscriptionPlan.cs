// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public class DaSubscriptionPlan : DaSubscriptionPlan<int, int?, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscription>
    {
        public DaSubscriptionPlan() : base()
        { }
    }

    public class DaSubscriptionPlan<TKey, TNullableKey, TSubscriptionPlanAttribute, TBillingCycleOptions, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription> : DaEntityBase<TKey>, IDaSubscriptionPlan<TKey, TNullableKey>        
        where TKey : IEquatable<TKey>
        where TSubscriptionPlanAttribute : IDaSubscriptionPlanAttribute<TKey>
        where TBillingCycleOptions : IDaBillingCycleOption<TKey>
        where TSubscriptionPlanFeature : IDaSubscriptionPlanFeature<TKey>
        where TSubscriptionPlanApp : IDaSubscriptionPlanApp<TKey>
        where TSubscription : IDaSubscription<TKey, TNullableKey>
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

        public string Description { get; set; }

        public string Code { get; set; }

        public bool IsAutoRenewUntilCanceled { get; set; }

        public int? ValidityInMonths { get; set; }

        public bool IsFeatured { get; set; }

        public DaEntityWorkflowStatus Status { get; set; }

        public TKey CurrencyId { get; set; }

        public double? SetupFee { get; set; }

        public bool AllowTrial { get; set; }

        public bool StartOnlyWithTrial { get; set; }

        public int? TrialDays { get; set; }

        public TNullableKey UserAgreementVersionId { get; set; }

        public DateTime? PublishedDateUtc { get; set; }

        public TNullableKey DefaultBillingCycleId { get; set; }

        public virtual ICollection<TSubscriptionPlanAttribute> Attributes { get; set; }

        public virtual ICollection<TBillingCycleOptions> BillingCycleOptions { get; set; }

        public virtual ICollection<TSubscriptionPlanApp> SubscriptionPlanApps { get; set; }

        public virtual ICollection<TSubscriptionPlanFeature> SubscriptionPlanFeatures { get; set; }

        public virtual ICollection<TSubscription> Subscriptions { get; set; }
    }
}
