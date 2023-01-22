// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Subscriptions.Subscriptions
{
    public class DaSubscriptionFeatureUser : DaSubscriptionFeatureUser<string, DaSubscriptionFeature, DaSubscriptionFeatureUserAction>
    {
        public DaSubscriptionFeatureUser() : base()
        { }
    }

    public class DaSubscriptionFeatureUser<TKey, TSubscriptionFeature, TSubscriptionFeatureUserAction> : DaEntityBase<TKey>, IDaSubscriptionFeatureUser<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
        where TSubscriptionFeatureUserAction : IDaSubscriptionFeatureUserAction<TKey>
    {
        public DaSubscriptionFeatureUser()
        {
            SubscriptionFeatureUserActions = new HashSet<TSubscriptionFeatureUserAction>();
        }

        public TKey SubscriptionFeatureId { get; set; }
        public TKey UserId { get; set; }
        public bool IsEnabled { get; set; }
        public virtual TSubscriptionFeature SubscriptionFeature { get; set; }
        public virtual ICollection<TSubscriptionFeatureUserAction> SubscriptionFeatureUserActions { get; set; }
    }
}
