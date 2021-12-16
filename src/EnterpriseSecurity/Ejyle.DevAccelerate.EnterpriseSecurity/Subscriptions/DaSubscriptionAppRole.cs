// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscriptionAppRole : DaSubscriptionAppRole<int, DaSubscriptionApp>
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
