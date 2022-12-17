// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.EnterpriseSecurity.Objects;
using Ejyle.DevAccelerate.EnterpriseSecurity.Groups;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF
{
    public class DaEnterpriseSecurityDbContext : DaEnterpriseSecurityDbContext<string, DaApp, DaAppAttribute, DaFeature, DaAppFeature, DaFeatureAction, DaTenant, DaTenantUser, DaTenantAttribute, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaObjectType, DaObjectInstance, DaObjectHistoryItem, DaGroup, DaGroupRole, DaGroupUser>
    {
        public DaEnterpriseSecurityDbContext()
            : base()
        { }

        public DaEnterpriseSecurityDbContext(DbContextOptions<DaEnterpriseSecurityDbContext> options)
           : base(options)
        { }

        public DaEnterpriseSecurityDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaEnterpriseSecurityDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TTenant, TTenantUser, TTenantAttribute, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TObjectType, TObjectInstance, TObjectHistoryItem, TGroup, TGroupRole, TGroupUser> : DbContext
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TFeature>
        where TFeature : DaFeature<TKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TApp, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>
        where TBillingCycle : DaBillingCycle<TKey, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TBillingCycle>
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<TKey, TBillingCycle, TSubscriptionFeature>
        where TSubscriptionAttribute : DaSubscriptionAttribute<TKey, TSubscription>
        where TUserAgreement : DaUserAgreement<TKey, TApp, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
        where TObjectType : DaObjectType<TKey, TObjectInstance>
        where TObjectInstance : DaObjectInstance<TKey, TObjectType, TObjectHistoryItem>
        where TObjectHistoryItem : DaObjectHistoryItem<TKey, TObjectInstance>
        where TGroup : DaGroup<TKey, TGroupRole, TGroupUser>
        where TGroupRole : DaGroupRole<TKey, TGroup>
        where TGroupUser : DaGroupUser<TKey, TGroup>
    {
        private const string SCHEMA_NAME = "EnterpriseSecurity";

        public DaEnterpriseSecurityDbContext()
            : base()
        { }

        public DaEnterpriseSecurityDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaEnterpriseSecurityDbContext(DbContextOptions<DaEnterpriseSecurityDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TTenant, TTenantUser, TTenantAttribute, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TObjectType, TObjectInstance, TObjectHistoryItem, TGroup, TGroupRole, TGroupUser>> options)
            : base(options)
        { }

        public DaEnterpriseSecurityDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaEnterpriseSecurityDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TTenant, TTenantUser, TTenantAttribute, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TObjectType, TObjectInstance, TObjectHistoryItem, TGroup, TGroupRole, TGroupUser>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaEnterpriseSecurityDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TTenant, TTenantUser, TTenantAttribute, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TObjectType, TObjectInstance, TObjectHistoryItem, TGroup, TGroupRole, TGroupUser>>(), connectionString).Options;
        }

        public virtual DbSet<TAppFeature> AppFeatures { get; set; }
        public virtual DbSet<TApp> Apps { get; set; }
        public virtual DbSet<TAppAttribute> AppAttributes { get; set; }
        public virtual DbSet<TBillingCycleOption> BillingCycleOptions { get; set; }
        public virtual DbSet<TFeatureAction> FeatureActions { get; set; }
        public virtual DbSet<TFeature> Features { get; set; }
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
        public virtual DbSet<TTenant> Tenants { get; set; }
        public virtual DbSet<TTenantUser> TenantUsers { get; set; }
        public virtual DbSet<TTenantAttribute> TenantAttributes { get; set; }
        public virtual DbSet<TUserAgreement> UserAgreements { get; set; }
        public virtual DbSet<TUserAgreementVersion> UserAgreementVersions { get; set; }
        public virtual DbSet<TUserAgreementVersionAction> UserAgreementVersionActions { get; set; }
        public virtual DbSet<DaObjectType> ObjectTypes { get; set; }
        public virtual DbSet<DaObjectInstance> ObjectInstances { get; set; }
        public virtual DbSet<DaObjectHistoryItem> ObjectHistoryItems { get; set; }
        public virtual DbSet<DaGroup> Groups { get; set; }
        public virtual DbSet<DaGroupRole> GroupRoles { get; set; }
        public virtual DbSet<DaGroupUser> GroupUsers { get; set; }

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

            modelBuilder.Entity<TAppAttribute>(entity =>
            {
                entity.ToTable("AppAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.AppId);
            });

            modelBuilder.Entity<TAppFeature>(entity =>
            {
                entity.ToTable("AppFeatures", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.App)
                    .WithMany(p => p.AppFeatures)
                    .HasForeignKey(d => d.AppId);

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.AppFeatures)
                    .HasForeignKey(d => d.AppId);
            });

            modelBuilder.Entity<TApp>(entity =>
            {
                entity.ToTable("Apps", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Key)
                    .IsUnique();
            });

            modelBuilder.Entity<TBillingCycle>(entity =>
            {
                entity.ToTable("BillingCycles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.BillingCycles)
                    .HasForeignKey(d => d.SubscriptionId);
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
            });

            modelBuilder.Entity<TFeatureAction>(entity =>
            {
                entity.ToTable("FeatureActions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.FeatureActions)
                    .HasForeignKey(d => d.FeatureId);
            });

            modelBuilder.Entity<TFeature>(entity =>
            {
                entity.ToTable("Features", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.AppId);
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

                entity.HasOne(d => d.SubscriptionApp)
                    .WithMany(p => p.SubscriptionAppUsers)
                    .HasForeignKey(d => d.SubscriptionAppId);
            });

            modelBuilder.Entity<TSubscriptionApp>(entity =>
            {
                entity.ToTable("SubscriptionApps", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.App)
                    .WithMany(p => p.SubscriptionApps)
                    .HasForeignKey(d => d.AppId);

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

                entity.HasOne(d => d.SubscriptionFeature)
                    .WithMany(p => p.SubscriptionFeatureUsers)
                    .HasForeignKey(d => d.SubscriptionFeatureId);
            });

            modelBuilder.Entity<TSubscriptionFeature>(entity =>
            {
                entity.ToTable("SubscriptionFeatures", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.SubscriptionFeatures)
                    .HasForeignKey(d => d.FeatureId);

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionFeatures)
                    .HasForeignKey(d => d.SubscriptionId);
            });

            modelBuilder.Entity<TSubscriptionPlanApp>(entity =>
            {
                entity.ToTable("SubscriptionPlanApps", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.App)
                    .WithMany(p => p.SubscriptionPlanApps)
                    .HasForeignKey(d => d.AppId);

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

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.SubscriptionPlanFeatures)
                    .HasForeignKey(d => d.FeatureId);

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
            });

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

            modelBuilder.Entity<TUserAgreementVersionAction>(entity =>
            {
                entity.ToTable("UserAgreementVersionActions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.UserAgreementVersion)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.UserAgreementVersionId);
            });

            modelBuilder.Entity<TUserAgreementVersion>(entity =>
            {
                entity.ToTable("UserAgreementVersions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.UserAgreement)
                    .WithMany(p => p.UserAgreementVersions)
                    .HasForeignKey(d => d.UserAgreementId);
            });

            modelBuilder.Entity<TUserAgreement>(entity =>
            {
                entity.ToTable("UserAgreements", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.UserAgreements)
                    .HasForeignKey(d => d.AppId);
            });

            modelBuilder.Entity<TObjectType>(entity =>
            {
                entity.ToTable("ObjectTypes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TObjectInstance>(entity =>
            {
                entity.ToTable("ObjectInstances", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ObjectType)
                    .WithMany(p => p.ObjectInstances)
                    .HasForeignKey(d => d.ObjectTypeId);
            });

            modelBuilder.Entity<TObjectHistoryItem>(entity =>
            {
                entity.ToTable("ObjectHistoryItems", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ObjectInstance)
                    .WithMany(p => p.ObjectHistoryItems)
                    .HasForeignKey(d => d.ObjectInstanceId);
            });

            modelBuilder.Entity<TGroup>(entity =>
            {
                entity.ToTable("Groups", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TGroupRole>(entity =>
            {
                entity.ToTable("GroupRoles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupRoles)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<TGroupUser>(entity =>
            {
                entity.ToTable("GroupUsers", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.GroupId);
            });
        }
    }
}
