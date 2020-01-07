// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public interface IDaTransaction<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey AccountId { get; set; }
        TNullableKey PaymentMethodId { get; set; }
        TKey OwnerUserId { get; set; }
        TNullableKey InvoiceId { get; set; }
        TKey CurrencyId { get; set; }
        double Amount { get; set; }
        string Remarks { get; set; }
        DaTransactionType TransactionType { get; set; }
        DaTransactionStatus Status { get; set; }
        DateTime CreatedDateUtc { get; set; }
    }
}
