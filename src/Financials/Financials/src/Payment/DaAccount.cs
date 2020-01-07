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
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public class DaAccount : DaAccount<int, int?, DaTransaction>
    {
        public DaAccount() : base()
        { }
    }

    public class DaAccount<TKey, TNullableKey, TTransaction> : DaEntityBase<TKey>, IDaAccount<TKey>
        where TKey : IEquatable<TKey>
        where TTransaction : IDaTransaction<TKey, TNullableKey>
    {
        public DaAccount()
        {
            Transactions = new HashSet<TTransaction>();
        }

        public virtual ICollection<TTransaction> Transactions { get; set; }
        public TKey TenantId { get; set; }
        public TKey OwnerUserId { get; set; }
        public double Balance { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
