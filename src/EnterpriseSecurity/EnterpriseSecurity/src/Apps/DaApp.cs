// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaApp : DaApp<int, int?, DaFeature, DaAppFeature, DaSubscriptionApp, DaSubscriptionPlanApp, DaUserAgreement>
    {
        public DaApp() : base()
        { }
    }

    public class DaApp<TKey, TNullableKey, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement> : DaEntityBase<TKey>, IDaApp<TKey>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey, TNullableKey>
        where TAppFeature : IDaAppFeature<TKey>
        where TSubscriptionApp : IDaSubscriptionApp<TKey>
        where TUserAgreement : IDaUserAgreement<TKey, TNullableKey>
    {
        public DaApp()
        {
            AppFeatures = new HashSet<TAppFeature>();
            Features = new HashSet<TFeature>();
            SubscriptionApps = new HashSet<TSubscriptionApp>();
            SubscriptionPlanApps = new HashSet<TSubscriptionPlanApp>();
            UserAgreements = new HashSet<TUserAgreement>();
        }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Key { get; set; }

        public string Description { get; set; }

        public DaEntityWorkflowStatus Status { get; set; }

        public DateTime LastUpdatedDateUtc { get; set; }

        public virtual ICollection<TAppFeature> AppFeatures { get; set; }

        public virtual ICollection<TFeature> Features { get; set; }

        public virtual ICollection<TSubscriptionApp> SubscriptionApps { get; set; }

        public virtual ICollection<TSubscriptionPlanApp> SubscriptionPlanApps { get; set; }

        public virtual ICollection<TUserAgreement> UserAgreements { get; set; }
    }
}
