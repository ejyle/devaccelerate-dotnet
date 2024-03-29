﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Subscriptions.Subscriptions
{
    public class DaSubscriptionAttribute : DaSubscriptionAttribute<string, DaSubscription>
    {
        public DaSubscriptionAttribute()
            : base()
        { }
    }

    public class DaSubscriptionAttribute<TKey, TSubscription> : DaEntityBase<TKey>, IDaSubscriptionAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TSubscription : IDaSubscription<TKey>
    {
        public TKey SubscriptionId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TSubscription Subscription { get; set; }
    }
}
