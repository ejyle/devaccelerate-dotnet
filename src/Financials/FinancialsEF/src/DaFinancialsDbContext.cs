// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Financials.Payment;

namespace Ejyle.DevAccelerate.Financials.EF
{
    public class DaFinancialsDbContext : DaFinancialsDbContext<int, int?, DaPaymentMethod, DaPaymentMethodAttribute, DaAccount, DaTransaction>
    {
        public DaFinancialsDbContext() : base()
        { }

        public static DaFinancialsDbContext Create()
        {
            return new DaFinancialsDbContext();
        }
    }

    public class DaFinancialsDbContext<TKey, TNullableKey, TPaymentMethod, TPaymentMethodAttribute, TAccount, TTransaction> : DbContext
        where TKey : IEquatable<TKey>
        where TPaymentMethod : DaPaymentMethod<TKey, TNullableKey, TPaymentMethodAttribute, TTransaction>
        where TPaymentMethodAttribute : DaPaymentMethodAttribute<TKey, TPaymentMethod>
        where TAccount : DaAccount<TKey, TNullableKey, TTransaction>
        where TTransaction : DaTransaction<TKey, TNullableKey, TAccount, TPaymentMethod>
    {
        private const string SCHEMA_NAME = "Financials";

        public DaFinancialsDbContext()
            : base(DaDbConnectionHelper.GetConnectionString())
        {
        }

        public DaFinancialsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public virtual DbSet<TAccount> Accounts { get; set; }
        public virtual DbSet<TTransaction> Transactions { get; set; }
        public virtual DbSet<TPaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<TPaymentMethodAttribute> PaymentMethodAttributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Payment

            var paymentMethods = modelBuilder.Entity<TPaymentMethod>()
                .ToTable("PaymentMethods", SCHEMA_NAME);

            paymentMethods.HasMany(e => e.Attributes)
                .WithRequired(e => e.PaymentMethod)
                .WillCascadeOnDelete(false);

            paymentMethods.HasMany(e => e.Transactions)
                .WithRequired(e => e.PaymentMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TPaymentMethodAttribute>()
                .ToTable("PaymentMethodAttributes", SCHEMA_NAME);

            modelBuilder.Entity<TTransaction>()
                .ToTable("Transactions", SCHEMA_NAME);

            var accounts = modelBuilder.Entity<TAccount>()
                .ToTable("Accounts", SCHEMA_NAME);

            accounts.HasMany(e => e.Transactions)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            #endregion Payment
        }
    }
}
