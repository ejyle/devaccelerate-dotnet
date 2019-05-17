// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaFeature : DaFeature<int, int?, DaApp, DaAppFeature, DaFeatureAction, DaSubscriptionFeature, DaSubscriptionPlanFeature>
    {
        public DaFeature() : base()
        { }
    }

    public class DaFeature<TKey, TnullableKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        : DaEntityBase<TKey>, IDaFeature<TKey, TnullableKey>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
        where TAppFeature : IDaAppFeature<TKey>
        where TFeatureAction : IDaFeatureAction<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
        where TSubscriptionPlanFeature : IDaSubscriptionPlanFeature<TKey>
    {
        public DaFeature()
            : base()
        {
            AppFeatures = new HashSet<TAppFeature>();
            FeatureActions = new HashSet<TFeatureAction>();
            SubscriptionFeatures = new HashSet<TSubscriptionFeature>();
            SubscriptionPlanFeatures = new HashSet<TSubscriptionPlanFeature>();
        }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Key { get; set; }

        [StringLength(500)]
        public string Location { get; set; }

        public TnullableKey AppId { get; set; }

        public DaEntityWorkflowStatus Status { get; set; }

        public DateTime LastUpdatedDateUtc { get; set; }

        public virtual TApp App { get; set; }

        public virtual ICollection<TAppFeature> AppFeatures { get; set; }

        public virtual ICollection<TFeatureAction> FeatureActions { get; set; }

        public virtual ICollection<TSubscriptionFeature> SubscriptionFeatures { get; set; }

        public virtual ICollection<TSubscriptionPlanFeature> SubscriptionPlanFeatures { get; set; }
    }
}
