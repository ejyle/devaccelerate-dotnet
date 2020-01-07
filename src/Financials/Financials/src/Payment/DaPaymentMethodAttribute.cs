// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public class DaPaymentMethodAttribute : DaPaymentMethodAttribute<int, DaPaymentMethod>
    {
        public DaPaymentMethodAttribute() : base()
        { }
    }

    public class DaPaymentMethodAttribute<TKey, TPaymentMethod> : DaEntityBase<TKey>, IDaPaymentMethodAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TPaymentMethod : IDaPaymentMethod<TKey>
    {
        public TKey PaymentMethodId { get; set; }
        public virtual TPaymentMethod PaymentMethod { get; set; }
        public string AttributeName { get; set; } 
        public string AttributeValue { get; set; } 
        public DateTime CreatedDateUtc { get; set; } 
        public DateTime LastUpdatedDateUtc { get; set; } 
    }
}
