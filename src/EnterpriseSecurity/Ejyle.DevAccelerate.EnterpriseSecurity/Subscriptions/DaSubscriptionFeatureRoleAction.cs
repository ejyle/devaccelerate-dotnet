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
    public class DaSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<int, DaSubscriptionFeatureRole>
    {
        public DaSubscriptionFeatureRoleAction() : base()
        { }
    }

    public class DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole> : DaAuditedEntityBase<TKey>, IDaSubscriptionFeatureRoleAction<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeatureRole : IDaSubscriptionFeatureRole<TKey>
    {
        [Required]
        public TKey SubscriptionFeatureRoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionName { get; set; }

        public bool? Allowed { get; set; }

        public virtual TSubscriptionFeatureRole SubscriptionFeatureRole { get; set; }
    }
}
