// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public interface IDaAccountRepository<TKey, TNullableKey, TAccount, TTransaction> : IDaEntityRepository<TKey, TAccount>
        where TKey : IEquatable<TKey>
        where TAccount : IDaAccount<TKey>
        where TTransaction : IDaTransaction<TKey, TNullableKey>
    {
        Task CreateAsync(TAccount account);
        Task<TAccount> FindByIdAsync(TKey id);
        Task<List<TAccount>> FindByTenantIdAsync(TKey tenantId);
        Task<List<TAccount>> FindByOwnerUserIdAsync(TKey ownerUserId);
        Task CreateAsync(TTransaction transaction);
        Task UpdateTransactionStatusAsync(TKey transactionId, DaTransactionStatus status);
    }
}
