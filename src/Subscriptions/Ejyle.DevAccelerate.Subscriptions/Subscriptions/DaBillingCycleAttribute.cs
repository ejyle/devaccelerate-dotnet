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
    public class DaBillingCycleAttribute : DaBillingCycleAttribute<string, DaBillingCycle>
    {
        public DaBillingCycleAttribute()
            : base()
        { }
    }

    public class DaBillingCycleAttribute<TKey, TBillingCycle> : DaEntityBase<TKey>, IDaBillingCycleAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TBillingCycle : IDaBillingCycle<TKey>
    {
        public TKey BillingCycleId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TBillingCycle BillingCycle { get; set; }
    }
}
