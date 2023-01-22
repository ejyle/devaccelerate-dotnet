// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Subscriptions.Subscriptions
{
    public class DaSubscriptionApp : DaSubscriptionApp<string, DaSubscriptionAppRole, DaSubscription, DaSubscriptionAppUser>
    {
        public DaSubscriptionApp() : base()
        { }
    }

    public class DaSubscriptionApp<TKey, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser> : DaEntityBase<TKey>, IDaSubscriptionApp<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionAppRole : IDaSubscriptionAppRole<TKey>
        where TSubscription : IDaSubscription<TKey>
        where TSubscriptionAppUser : IDaSubscriptionAppUser<TKey>
    {
        public DaSubscriptionApp()
        {
            SubscriptionAppRoles = new HashSet<TSubscriptionAppRole>();
            SubscriptionAppUsers = new HashSet<TSubscriptionAppUser>();
        }

        public TKey SubscriptionId { get; set; }
        public TKey AppId { get; set; }
        public virtual ICollection<TSubscriptionAppRole> SubscriptionAppRoles { get; set; }
        public virtual TSubscription Subscription { get; set; }
        public virtual ICollection<TSubscriptionAppUser> SubscriptionAppUsers { get; set; }
    }
}
