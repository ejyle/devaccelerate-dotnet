// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright � Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public class DaBillingCycle : DaBillingCycle<int, int?, DaSubscription>
    {
        public DaBillingCycle() : base()
        { }
    }

    public class DaBillingCycle<TKey, TNullableKey, TSubscription> : DaEntityBase<TKey>, IDaBillingCycle<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TSubscription : IDaSubscription<TKey, TNullableKey>
    {
        public DaBillingCycle() : base()
        { }

        public TKey SubscriptionId { get; set; }
        public DateTime FromDateUtc { get; set; }
        public DateTime? ToDateUtc { get; set; }
        public decimal Amount { get; set; }
        public TKey CurrencyId { get; set; }
        public TNullableKey InvoiceId { get; set; }
        public bool IsPaid { get; set; }
        public TNullableKey TransactionId { get; set; }
        public virtual TSubscription Subscription { get; set; }
    }
}