// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscriptionFeatureRole : DaSubscriptionFeatureRole<string, DaSubscriptionFeatureRoleAction, DaSubscriptionFeature>
    {
        public DaSubscriptionFeatureRole() : base()
        { }
    }

    public class DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature> : DaEntityBase<TKey>, IDaSubscriptionFeatureRole<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeatureRoleAction : IDaSubscriptionFeatureRoleAction<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
    {
        public DaSubscriptionFeatureRole()
        {
            SubscriptionFeatureRoleActions = new HashSet<TSubscriptionFeatureRoleAction>();
        }

        public TKey SubscriptionFeatureId { get; set; }
        public TKey RoleId { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<TSubscriptionFeatureRoleAction> SubscriptionFeatureRoleActions { get; set; }
        public virtual TSubscriptionFeature SubscriptionFeature { get; set; }
    }
}
