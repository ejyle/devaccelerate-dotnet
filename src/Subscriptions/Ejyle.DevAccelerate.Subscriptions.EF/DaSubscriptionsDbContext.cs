// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright � Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans;
using Ejyle.DevAccelerate.Subscriptions.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Subscriptions.EF
{
    public class DaSubscriptionsDbContext : DaSubscriptionsDbContext<string, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage>
    {
        public DaSubscriptionsDbContext()
            : base()
        { }

        public DaSubscriptionsDbContext(DbContextOptions<DaSubscriptionsDbContext> options)
           : base(options)
        { }

        public DaSubscriptionsDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaSubscriptionsDbContext<TKey, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage> : DbContext
        where TKey : IEquatable<TKey>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TSubscriptionPlan>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>
        where TBillingCycle : DaBillingCycle<TKey, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TBillingCycle>
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<TKey, TBillingCycle, TSubscriptionFeature>
        where TSubscriptionAttribute : DaSubscriptionAttribute<TKey, TSubscription>
    {
        private const string SCHEMA_NAME = "Da.Subscriptions";

        public DaSubscriptionsDbContext()
            : base()
        { }

        public DaSubscriptionsDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaSubscriptionsDbContext(DbContextOptions<DaSubscriptionsDbContext<TKey, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage>> options)
            : base(options)
        { }

        public DaSubscriptionsDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaSubscriptionsDbContext<TKey, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaSubscriptionsDbContext<TKey, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage>>(), connectionString).Options;
        }

        public virtual DbSet<TBillingCycleOption> BillingCycleOptions { get; set; }
        public virtual DbSet<TSubscriptionAppRole> SubscriptionAppRoles { get; set; }
        public virtual DbSet<TSubscriptionApp> SubscriptionApps { get; set; }
        public virtual DbSet<TSubscriptionAttribute> SubscriptionAttributes { get; set; }
        public virtual DbSet<TSubscriptionAppUser> SubscriptionAppUsers { get; set; }
        public virtual DbSet<TSubscriptionFeatureAttribute> SubscriptionFeatureAttributes { get; set; }
        public virtual DbSet<TSubscriptionFeatureRoleAction> SubscriptionFeatureRoleActions { get; set; }
        public virtual DbSet<TSubscriptionFeatureRole> SubscriptionFeatureRoles { get; set; }
        public virtual DbSet<TSubscriptionFeature> SubscriptionFeatures { get; set; }
        public virtual DbSet<TSubscriptionFeatureUserAction> SubscriptionFeatureUserActions { get; set; }
        public virtual DbSet<TSubscriptionFeatureUser> SubscriptionFeatureUsers { get; set; }
        public virtual DbSet<TSubscriptionPlanApp> SubscriptionPlanApps { get; set; }
        public virtual DbSet<TSubscriptionPlanAttribute> SubscriptionPlanAttributes { get; set; }
        public virtual DbSet<TSubscriptionPlanFeatureAttribute> SubscriptionPlanFeatureAttributes { get; set; }
        public virtual DbSet<TSubscriptionPlanFeature> SubscriptionPlanFeatures { get; set; }
        public virtual DbSet<TSubscriptionPlan> SubscriptionPlans { get; set; }
        public virtual DbSet<TSubscription> Subscriptions { get; set; }
        public virtual DbSet<TBillingCycle> BillingCycles { get; set; }
        public virtual DbSet<TBillingCycleFeatureUsage> BillingCycleFeatureUsage { get; set; }
        public virtual DbSet<TBillingCycleAttribute> BillingCycleAttributes { get; set; }

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

            modelBuilder.Entity<TBillingCycle>(entity =>
            {
                entity.ToTable("BillingCycles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.BillingCycles)
                    .HasForeignKey(d => d.SubscriptionId);

                entity.Property(e => e.Currency).HasMaxLength(450);
                entity.Property(e => e.InvoiceId).HasMaxLength(450);
                entity.Property(e => e.TransactionId).HasMaxLength(450);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TBillingCycleAttribute>(entity =>
            {
                entity.ToTable("BillingCycleAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.BillingCycle)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.BillingCycleId);
            });

            modelBuilder.Entity<TBillingCycleFeatureUsage>(entity =>
            {
                entity.ToTable("BillingCycleFeatureUsage", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.BillingCycle)
                    .WithMany(p => p.FeatureUsage)
                    .HasForeignKey(d => d.BillingCycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SubscriptionFeature)
                    .WithMany(p => p.FeatureUsage)
                    .HasForeignKey(d => d.SubscriptionFeatureId);
            });

            modelBuilder.Entity<TBillingCycleOption>(entity =>
            {
                entity.ToTable("BillingCycleOptions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.SubscriptionPlan)
                    .WithMany(p => p.BillingCycleOptions)
                    .HasForeignKey(d => d.SubscriptionPlanId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TSubscriptionAppRole>(entity =>
            {
                entity.ToTable("SubscriptionAppRoles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.SubscriptionApp)
                    .WithMany(p => p.SubscriptionAppRoles)
                    .HasForeignKey(d => d.SubscriptionAppId);
            });

            modelBuilder.Entity<TSubscriptionAppUser>(entity =>
            {
                entity.ToTable("SubscriptionAppUsers", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.UserId).HasMaxLength(450).IsRequired();

                entity.HasOne(d => d.SubscriptionApp)
                    .WithMany(p => p.SubscriptionAppUsers)
                    .HasForeignKey(d => d.SubscriptionAppId);
            });

            modelBuilder.Entity<TSubscriptionApp>(entity =>
            {
                entity.ToTable("SubscriptionApps", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionApps)
                    .HasForeignKey(d => d.SubscriptionId);
            });

            modelBuilder.Entity<TSubscriptionAttribute>(entity =>
            {
                entity.ToTable("SubscriptionAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.SubscriptionId);
            });

            modelBuilder.Entity<TSubscriptionFeatureAttribute>(entity =>
            {
                entity.ToTable("SubscriptionFeatureAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.SubscriptionFeature)
                    .WithMany(p => p.SubscriptionFeatureAttributes)
                    .HasForeignKey(d => d.SubscriptionFeatureId);
            });

            modelBuilder.Entity<TSubscriptionFeatureRole>(entity =>
            {
                entity.ToTable("SubscriptionFeatureRole", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.SubscriptionFeature)
                    .WithMany(p => p.SubscriptionFeatureRoles)
                    .HasForeignKey(d => d.SubscriptionFeatureId);
            });

            modelBuilder.Entity<TSubscriptionFeatureRoleAction>(entity =>
            {
                entity.ToTable("SubscriptionFeatureRoleActions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.SubscriptionFeatureRole)
                    .WithMany(p => p.SubscriptionFeatureRoleActions)
                    .HasForeignKey(d => d.SubscriptionFeatureRoleId);
            });

            modelBuilder.Entity<TSubscriptionFeatureUserAction>(entity =>
            {
                entity.ToTable("SubscriptionFeatureUserActions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.SubscriptionFeatureUser)
                    .WithMany(p => p.SubscriptionFeatureUserActions)
                    .HasForeignKey(d => d.SubscriptionFeatureUserId);
            });

            modelBuilder.Entity<TSubscriptionFeatureUser>(entity =>
            {
                entity.ToTable("SubscriptionFeatureUsers", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasMaxLength(450).IsRequired();

                entity.HasOne(d => d.SubscriptionFeature)
                    .WithMany(p => p.SubscriptionFeatureUsers)
                    .HasForeignKey(d => d.SubscriptionFeatureId);
            });

            modelBuilder.Entity<TSubscriptionFeature>(entity =>
            {
                entity.ToTable("SubscriptionFeatures", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionFeatures)
                    .HasForeignKey(d => d.SubscriptionId);
            });

            modelBuilder.Entity<TSubscriptionPlanApp>(entity =>
            {
                entity.ToTable("SubscriptionPlanApps", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.SubscriptionPlan)
                    .WithMany(p => p.SubscriptionPlanApps)
                    .HasForeignKey(d => d.SubscriptionPlanId);
            });

            modelBuilder.Entity<TSubscriptionPlanAttribute>(entity =>
            {
                entity.ToTable("SubscriptionPlanAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.SubscriptionPlan)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.SubscriptionPlanId);
            });

            modelBuilder.Entity<TSubscriptionPlanFeatureAttribute>(entity =>
            {
                entity.ToTable("SubscriptionPlanFeatureAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.SubscriptionPlanFeature)
                    .WithMany(p => p.SubscriptionPlanFeatureAttributes)
                    .HasForeignKey(d => d.SubscriptionPlanFeatureId);
            });

            modelBuilder.Entity<TSubscriptionPlanFeature>(entity =>
            {
                entity.ToTable("SubscriptionPlanFeatures", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.SubscriptionPlan)
                    .WithMany(p => p.SubscriptionPlanFeatures)
                    .HasForeignKey(d => d.SubscriptionPlanId);
            });

            modelBuilder.Entity<TSubscriptionPlan>(entity =>
            {
                entity.ToTable("SubscriptionPlans", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(m => m.Code)
                    .IsUnique();

                entity.Property(e => e.Currency).HasMaxLength(450);
                entity.Property(e => e.UserAgreementVersionId).HasMaxLength(450);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TSubscription>(entity =>
            {
                entity.ToTable("Subscriptions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.BillingAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.SubscriptionPlan)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.SubscriptionPlanId);

                entity.Property(e => e.Currency).HasMaxLength(450);
                entity.Property(e => e.Country).HasMaxLength(450);
                entity.Property(e => e.TenantId).HasMaxLength(450).IsRequired();
                entity.Property(e => e.UserAgreementVersionId).HasMaxLength(450);
                entity.Property(e => e.OwnerUserId).HasMaxLength(450).IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });
        }
    }
}
