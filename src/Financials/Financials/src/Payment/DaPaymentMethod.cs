// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public class DaPaymentMethod : DaPaymentMethod<int, int?, DaPaymentMethodAttribute, DaTransaction>
    {
        public DaPaymentMethod() : base()
        { }
    }

    public class DaPaymentMethod<TKey, TNullableKey, TPaymentMethodAttribute, TTransaction>
        : DaEntityBase<TKey>, IDaPaymentMethod<TKey>
        where TKey : IEquatable<TKey>
        where TPaymentMethodAttribute : IDaPaymentMethodAttribute<TKey>
        where TTransaction : IDaTransaction<TKey, TNullableKey>
    {
        public DaPaymentMethod()
        {
            Attributes = new HashSet<TPaymentMethodAttribute>();
            Transactions = new HashSet<TTransaction>();
        }

        public string PaymentGateway { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string NativePaymentMethodId { get; set; }
        public TKey OwnerUserId { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public virtual ICollection<TPaymentMethodAttribute> Attributes { get; set; }
        public virtual ICollection<TTransaction> Transactions { get; set; }
    }
}
