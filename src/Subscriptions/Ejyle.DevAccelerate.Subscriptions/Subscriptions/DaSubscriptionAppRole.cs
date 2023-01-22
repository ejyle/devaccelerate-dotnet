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
    public class DaSubscriptionAppRole : DaSubscriptionAppRole<string, DaSubscriptionApp>
    {
        public DaSubscriptionAppRole() : base()
        { }
    }

    public class DaSubscriptionAppRole<TKey, TSubscriptionApp> : DaEntityBase<TKey>, IDaSubscriptionAppRole<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionApp : IDaSubscriptionApp<TKey>
    {
        public TKey SubscriptionAppId { get; set; }
        public TKey RoleId { get; set; }
        public bool IsEnabled { get; set; }
        public virtual TSubscriptionApp SubscriptionApp { get; set; }
    }
}
