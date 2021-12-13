// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscriptionFeatureUser : DaSubscriptionFeatureUser<int, int?, DaSubscriptionFeature, DaSubscriptionFeatureUserAction>
    {
        public DaSubscriptionFeatureUser() : base()
        { }
    }

    public class DaSubscriptionFeatureUser<TKey, TNullableKey, TSubscriptionFeature, TSubscriptionFeatureUserAction> : DaEntityBase<TKey>, IDaSubscriptionFeatureUser<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
        where TSubscriptionFeatureUserAction : IDaSubscriptionFeatureUserAction<TKey>
    {
        public DaSubscriptionFeatureUser()
        {
            SubscriptionFeatureUserActions = new HashSet<TSubscriptionFeatureUserAction>();
        }

        [Required]
        public TKey SubscriptionFeatureId { get; set; }

        [Required]
        public TKey UserId { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        public virtual TSubscriptionFeature SubscriptionFeature { get; set; }

        public virtual ICollection<TSubscriptionFeatureUserAction> SubscriptionFeatureUserActions { get; set; }
    }
}
