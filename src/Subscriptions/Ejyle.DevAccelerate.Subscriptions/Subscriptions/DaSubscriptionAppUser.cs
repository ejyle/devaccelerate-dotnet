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
    public class DaSubscriptionAppUser : DaSubscriptionAppUser<string, DaSubscriptionApp>
    {
        public DaSubscriptionAppUser() : base()
        { }
    }

    public class DaSubscriptionAppUser<TKey, TSubscriptionApp> : DaEntityBase<TKey>, IDaSubscriptionAppUser<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionApp : IDaSubscriptionApp<TKey>
    {
        public TKey SubscriptionAppId { get; set; }
        public TKey UserId { get; set; }
        public bool IsEnabled { get; set; }
        public virtual TSubscriptionApp SubscriptionApp { get; set; }
    }
}
