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
using Ejyle.DevAccelerate.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF
{
    public class DaEnterpriseSecurityDbContext : DaEnterpriseSecurityDbContext<int, int?, DaApp, DaAppAttribute, DaFeature, DaAppFeature, DaFeatureAction, DaTenant, DaTenantUser, DaTenantAttribute, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction>
    {
        public DaEnterpriseSecurityDbContext()
            : base()
        { }

        public DaEnterpriseSecurityDbContext(DbContextOptions<DaEnterpriseSecurityDbContext> options)
           : base(options)
        { }
    }

    public class DaEnterpriseSecurityDbContext<TKey, TNullableKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TTenant, TTenantUser, TTenantAttribute, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction> : DbContext
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TNullableKey, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TNullableKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TNullableKey, TFeature>
        where TFeature : DaFeature<TKey, TNullableKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        where TTenant : DaTenant<TKey, TNullableKey, TTenantUser, TTenantAttribute>
        where TTenantAttribute : DaTenantAttribute<TKey, TNullableKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TNullableKey, TTenant>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TNullableKey, TApp, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TNullableKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TNullableKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TNullableKey, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TNullableKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TNullableKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TNullableKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>
        where TBillingCycle : DaBillingCycle<TKey, TNullableKey, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TNullableKey, TBillingCycle>
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<TKey, TNullableKey, TBillingCycle, TSubscriptionFeature>
        where TSubscriptionAttribute : DaSubscriptionAttribute<TKey, TNullableKey, TSubscription>
        where TUserAgreement : DaUserAgreement<TKey, TNullableKey, TApp, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TNullableKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
    {
        private const string SCHEMA_NAME = "EnterpriseSecurity";

        public DaEnterpriseSecurityDbContext()
            : base()
        { }

        public DaEnterpriseSecurityDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaEnterpriseSecurityDbContext(DbContextOptions<DaEnterpriseSecurityDbContext<TKey, TNullableKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TTenant, TTenantUser, TTenantAttribute, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>> options)
            : base(options)
        { }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TAppAttribute>(entity =>
            {
                entity.ToTable("AppAttributes", SCHEMA_NAME);

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

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Key)
                    .IsUnique(true);
            });

            modelBuilder.Entity<TBillingCycle>(entity =>
            {
                entity.ToTable("BillingCycles", SCHEMA_NAME);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.BillingCycles)
                    .HasForeignKey(d => d.SubscriptionId);
            });

            modelBuilder.Entity<TBillingCycleAttribute>(entity =>
            {
                entity.ToTable("BillingCycleAttributes", SCHEMA_NAME);

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

                entity.HasOne(d => d.SubscriptionApp)
                    .WithMany(p => p.SubscriptionAppRoles)
                    .HasForeignKey(d => d.SubscriptionAppId);
            });

            modelBuilder.Entity<TSubscriptionAppUser>(entity =>
            {
                entity.ToTable("SubscriptionAppUsers", SCHEMA_NAME);

                entity.HasOne(d => d.SubscriptionApp)
                    .WithMany(p => p.SubscriptionAppUsers)
                    .HasForeignKey(d => d.SubscriptionAppId);
            });

            modelBuilder.Entity<TSubscriptionApp>(entity =>
            {
                entity.ToTable("SubscriptionApps", SCHEMA_NAME);

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

                entity.HasOne(d => d.SubscriptionFeature)
                    .WithMany(p => p.SubscriptionFeatureRoles)
                    .HasForeignKey(d => d.SubscriptionFeatureId);
            });

            modelBuilder.Entity<TSubscriptionFeatureRoleAction>(entity =>
            {
                entity.ToTable("SubscriptionFeatureRoleActions", SCHEMA_NAME);

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

                entity.HasOne(d => d.SubscriptionFeature)
                    .WithMany(p => p.SubscriptionFeatureUsers)
                    .HasForeignKey(d => d.SubscriptionFeatureId);
            });

            modelBuilder.Entity<TSubscriptionFeature>(entity =>
            {
                entity.ToTable("SubscriptionFeatures", SCHEMA_NAME);

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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TSubscription>(entity =>
            {
                entity.ToTable("Subscriptions", SCHEMA_NAME);

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

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantUsers)
                    .HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<TTenant>(entity =>
            {
                entity.ToTable("Tenants", SCHEMA_NAME);

                entity.Property(e => e.BillingEmail).HasMaxLength(256);

                entity.Property(e => e.Domain).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique(true);

                entity.HasIndex(e => e.Domain)
                    .IsUnique(true);
            });

            modelBuilder.Entity<TUserAgreementVersionAction>(entity =>
            {
                entity.ToTable("UserAgreementVersionActions", SCHEMA_NAME);

                entity.HasOne(d => d.UserAgreementVersion)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.UserAgreementVersionId);
            });

            modelBuilder.Entity<TUserAgreementVersion>(entity =>
            {
                entity.ToTable("UserAgreementVersions", SCHEMA_NAME);

                entity.HasOne(d => d.UserAgreement)
                    .WithMany(p => p.UserAgreementVersions)
                    .HasForeignKey(d => d.UserAgreementId);
            });

            modelBuilder.Entity<TUserAgreement>(entity =>
            {
                entity.ToTable("UserAgreements", SCHEMA_NAME);

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

        }
    }
}
