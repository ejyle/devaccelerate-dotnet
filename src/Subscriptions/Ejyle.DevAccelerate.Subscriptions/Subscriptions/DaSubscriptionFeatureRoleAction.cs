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
    public class DaSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<string, DaSubscriptionFeatureRole>
    {
        public DaSubscriptionFeatureRoleAction() : base()
        { }
    }

    public class DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole> : DaEntityBase<TKey>, IDaSubscriptionFeatureRoleAction<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeatureRole : IDaSubscriptionFeatureRole<TKey>
    {
        public TKey SubscriptionFeatureRoleId { get; set; }
        public string ActionName { get; set; }
        public bool? Allowed { get; set; }
        public virtual TSubscriptionFeatureRole SubscriptionFeatureRole { get; set; }
    }
}
