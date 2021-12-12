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
    public class DaSubscriptionAppUser : DaSubscriptionAppUser<int, DaSubscriptionApp>
    {
        public DaSubscriptionAppUser() : base()
        { }
    }

    public class DaSubscriptionAppUser<TKey, TSubscriptionApp> : DaAuditedEntityBase<TKey>, IDaSubscriptionAppUser<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionApp : IDaSubscriptionApp<TKey>
    {
        [Required]
        public TKey SubscriptionAppId { get; set; }

        [Required]
        public TKey UserId { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        public virtual TSubscriptionApp SubscriptionApp { get; set; }
    }
}
