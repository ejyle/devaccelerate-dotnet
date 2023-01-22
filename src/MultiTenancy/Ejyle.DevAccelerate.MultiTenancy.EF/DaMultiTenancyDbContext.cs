// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.MultiTenancy;

namespace Ejyle.DevAccelerate.MultiTenancy.EF
{
    public class DaMultiTenancyDbContext : DaMultiTenancyDbContext<string, DaTenant, DaTenantUser, DaTenantAttribute>
    {
        public DaMultiTenancyDbContext()
            : base()
        { }

        public DaMultiTenancyDbContext(DbContextOptions<DaMultiTenancyDbContext> options)
           : base(options)
        { }

        public DaMultiTenancyDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute> : DbContext
        where TKey : IEquatable<TKey>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>
    {
        private const string SCHEMA_NAME = "Da.MultiTenancy";

        public DaMultiTenancyDbContext()
            : base()
        { }

        public DaMultiTenancyDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaMultiTenancyDbContext(DbContextOptions<DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute>> options)
            : base(options)
        { }

        public DaMultiTenancyDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute>>(), connectionString).Options;
        }

        public virtual DbSet<TTenant> Tenants { get; set; }
        public virtual DbSet<TTenantUser> TenantUsers { get; set; }
        public virtual DbSet<TTenantAttribute> TenantAttributes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Ejyle.DevAccelerate;Trusted_Connection = True;MultipleActiveResultSets=True";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TTenantAttribute>(entity =>
            {
                entity.ToTable("TenantAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<TTenantUser>(entity =>
            {
                entity.ToTable("TenantUsers", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantUsers)
                    .HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<TTenant>(entity =>
            {
                entity.ToTable("Tenants", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.BillingEmail).HasMaxLength(256);

                entity.Property(e => e.Domain).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.HasIndex(e => e.Domain)
                    .IsUnique();
            });
        }
    }
}
