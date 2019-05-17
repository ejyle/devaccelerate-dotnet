// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscriptionFeature : DaSubscriptionFeature<int, int?, DaFeature, DaSubscriptionFeatureAttribute, DaSubscriptionFeatureRole, DaSubscription, DaSubscriptionFeatureUser>
    {
        public DaSubscriptionFeature() : base()
        { }
    }

    public class DaSubscriptionFeature<TKey, TNullableKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser> : DaEntityBase<TKey>, IDaSubscriptionFeature<TKey>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey, TNullableKey>
        where TSubscriptionFeatureAttribute : IDaSubscriptionFeatureAttribute<TKey>
        where TSubscriptionFeatureRole : IDaSubscriptionFeatureRole<TKey>
        where TSubscription : IDaSubscription<TKey, TNullableKey>
        where TSubscriptionFeatureUser : IDaSubscriptionFeatureUser<TKey>
    {
        public DaSubscriptionFeature()
        {
            SubscriptionFeatureAttributes = new HashSet<TSubscriptionFeatureAttribute>();
            SubscriptionFeatureRoles = new HashSet<TSubscriptionFeatureRole>();
            SubscriptionFeatureUsers = new HashSet<TSubscriptionFeatureUser>();
        }

        public TKey SubscriptionId { get; set; }

        public TKey FeatureId { get; set; }

        public bool IsEnabled { get; set; }

        public DateTime LastUpdatedDateUtc { get; set; }

        public virtual TFeature Feature { get; set; }

        public virtual ICollection<TSubscriptionFeatureAttribute> SubscriptionFeatureAttributes { get; set; }

        public virtual ICollection<TSubscriptionFeatureRole> SubscriptionFeatureRoles { get; set; }

        public virtual TSubscription Subscription { get; set; }

        public virtual ICollection<TSubscriptionFeatureUser> SubscriptionFeatureUsers { get; set; }
    }
}
