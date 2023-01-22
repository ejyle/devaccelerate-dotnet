// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Subscriptions.Subscriptions
{
    public class DaSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<string, DaSubscriptionFeatureUser>
    {
        public DaSubscriptionFeatureUserAction() : base()
        { }
    }

    public class DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser> : DaEntityBase<TKey>, IDaSubscriptionFeatureUserAction<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeatureUser : IDaSubscriptionFeatureUser<TKey>
    {
        public TKey SubscriptionFeatureUserId { get; set; }
        public string ActionName { get; set; }
        public bool? Allowed { get; set; }
        public virtual TSubscriptionFeatureUser SubscriptionFeatureUser { get; set; }
    }
}
