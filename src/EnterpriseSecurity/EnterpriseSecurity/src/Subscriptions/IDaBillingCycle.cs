// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public interface IDaBillingCycle<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey SubscriptionId { get; set; }
        DateTime FromDateUtc { get; set; }
        DateTime? ToDateUtc { get; set; }
        decimal Amount { get; set; }
        TKey CurrencyId { get; set; }
        TNullableKey InvoiceId { get; set; }
        bool IsPaid { get; set; }
        TNullableKey TransactionId { get; set; }
    }
}
