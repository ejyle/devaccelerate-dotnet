// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<int, DaSubscriptionFeature>
    {
        public DaSubscriptionFeatureAttribute()
            : base()
        { }
    }

    public class DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature> : DaEntityBase<TKey>, IDaSubscriptionFeatureAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeature : IDaSubscriptionFeature<TKey>
    {
        public TKey SubscriptionFeatureId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TSubscriptionFeature SubscriptionFeature { get; set; }
    }
}
