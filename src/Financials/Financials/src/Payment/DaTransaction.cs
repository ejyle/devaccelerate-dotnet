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

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public class DaTransaction : DaTransaction<int, int?, DaAccount, DaPaymentMethod>
    {
        public DaTransaction() : base()
        { }
    }

    public class DaTransaction<TKey, TnullableKey, TAccount, TPaymentMethod>
        : DaEntityBase<TKey>, IDaTransaction<TKey, TnullableKey>
        where TKey : IEquatable<TKey>
        where TAccount : IDaAccount<TKey>
    {
        public DaTransaction()
            : base()
        { }

        public TKey AccountId { get; set; }
        public TnullableKey PaymentMethodId { get; set; }
        public TKey OwnerUserId { get; set; }
        public TnullableKey InvoiceId { get; set; }
        public TKey CurrencyId { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public virtual TAccount Account { get; set; }
        public virtual TPaymentMethod PaymentMethod { get; set; }
        public DaTransactionType TransactionType { get; set;  }
        public DaTransactionStatus Status { get; set;  }
    }
}
