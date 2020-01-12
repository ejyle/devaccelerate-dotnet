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
    public class DaPaymentMethodRepository : DaPaymentMethodRepository<int, int?, DaPaymentMethod, DaPaymentMethodAttribute, DaAccount, DaTransaction,  DbContext>
    {
        public DaPaymentMethodRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaPaymentMethodRepository<TKey, TNullableKey, TPaymentMethod, TPaymentMethodAttribute, TAccount, TTransaction, TDbContext>
        : DaEntityRepositoryBase<TKey, TPaymentMethod, TDbContext>, IDaPaymentMethodRepository<TKey, TPaymentMethod>
        where TKey : IEquatable<TKey>
        where TPaymentMethod : DaPaymentMethod<TKey, TNullableKey, TPaymentMethodAttribute, TTransaction>
        where TPaymentMethodAttribute : DaPaymentMethodAttribute<TKey, TPaymentMethod>
        where TAccount : DaAccount<TKey, TNullableKey, TTransaction>
        where TTransaction : DaTransaction<TKey, TNullableKey, TAccount, TPaymentMethod>
        where TDbContext : DbContext
    {
        public DaPaymentMethodRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TPaymentMethod> PaymentMethods { get { return DbContext.Set<TPaymentMethod>(); } }

        public async Task ActivateAsync(TKey paymentMethodId)
        {
            var paymentMethod = await PaymentMethods.Where(m => m.Equals(paymentMethodId)).SingleOrDefaultAsync();

            if (paymentMethod == null)
            {
                throw new InvalidOperationException("Invalid payment method ID.");
            }

            paymentMethod.IsActive = true;

            DbContext.Entry<TPaymentMethod>(paymentMethod).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public Task CreateAsync(TPaymentMethod paymentMethod)
        {
            PaymentMethods.Add(paymentMethod);
            return DbContext.SaveChangesAsync();
        }

        public async Task DeactivateAsync(TKey paymentMethodId)
        {
            var paymentMethod = await PaymentMethods.Where(m => m.Equals(paymentMethodId)).SingleOrDefaultAsync();

            if (paymentMethod == null)
            {
                throw new InvalidOperationException("Invalid payment method ID.");
            }

            paymentMethod.IsActive = false;

            DbContext.Entry<TPaymentMethod>(paymentMethod).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public Task<TPaymentMethod> FindByIdAsync(TKey id)
        {
            return PaymentMethods.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TPaymentMethod> FindByNativeIdAsync(string nativePaymentMethodId)
        {
            return PaymentMethods.Where(m => m.NativePaymentMethodId == nativePaymentMethodId).SingleOrDefaultAsync();
        }

        public Task<List<TPaymentMethod>> FindByOwnerUserIdAsync(TKey ownerUserId)
        {
            return PaymentMethods.Where(m => m.OwnerUserId.Equals(ownerUserId)).ToListAsync();
        }
    }
}
