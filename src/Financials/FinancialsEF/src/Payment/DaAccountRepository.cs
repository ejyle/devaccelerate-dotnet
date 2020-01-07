// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Financials.Payment;

namespace Ejyle.DevAccelerate.Financials.EF.Payment
{
    public class DaAccountRepository : DaAccountRepository<int, int?, DaPaymentMethod, DaPaymentMethodAttribute, DaAccount, DaTransaction, DbContext>
    {
        public DaAccountRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaAccountRepository<TKey, TNullableKey, TPaymentMethod, TPaymentMethodAttribute, TAccount, TTransaction, TDbContext>
        : DaEntityRepositoryBase<TKey, TAccount, TDbContext>, IDaAccountRepository<TKey, TNullableKey, TAccount, TTransaction>
        where TKey : IEquatable<TKey>
        where TPaymentMethod : DaPaymentMethod<TKey, TNullableKey, TPaymentMethodAttribute, TTransaction>
        where TPaymentMethodAttribute : DaPaymentMethodAttribute<TKey, TPaymentMethod>
        where TAccount : DaAccount<TKey, TNullableKey, TTransaction>
        where TTransaction : DaTransaction<TKey, TNullableKey, TAccount, TPaymentMethod>
        where TDbContext : DbContext
    {
        public DaAccountRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TAccount> Accounts { get { return DbContext.Set<TAccount>(); } }
        private DbSet<TTransaction> Transactions { get { return DbContext.Set<TTransaction>(); } }

        public Task CreateAsync(TAccount account)
        {
            Accounts.Add(account);
            return DbContext.SaveChangesAsync();
        }

        public Task CreateAsync(TTransaction transaction)
        {
            Transactions.Add(transaction);
            return DbContext.SaveChangesAsync();
        }

        public Task<TAccount> FindByIdAsync(TKey id)
        {
            return Accounts.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<List<TAccount>> FindByOwnerUserIdAsync(TKey ownerUserId)
        {
            return Accounts.Where(m => m.OwnerUserId.Equals(ownerUserId)).ToListAsync();
        }

        public Task<List<TAccount>> FindByTenantIdAsync(TKey tenantId)
        {
            return Accounts.Where(m => m.TenantId.Equals(tenantId)).ToListAsync();
        }

        public async Task UpdateTransactionStatusAsync(TKey transactionId, DaTransactionStatus status)
        {
            var transaction = await Transactions.Where(m => m.Equals(transactionId)).SingleOrDefaultAsync();

            if(transaction == null)
            {
                throw new InvalidOperationException("Invalid transaction ID.");
            }

            transaction.Status = status;
       
            DbContext.Entry<TTransaction>(transaction).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}
