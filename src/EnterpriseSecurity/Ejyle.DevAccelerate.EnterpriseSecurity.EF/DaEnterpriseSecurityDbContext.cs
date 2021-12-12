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
            #region Apps

            var apps = modelBuilder.Entity<TApp>()
                .ToTable("Apps", SCHEMA_NAME);

            modelBuilder.Entity<TAppAttribute>()
                .HasOne(p => p.App)
                .WithMany(b => b.Attributes)
                .HasForeignKey(p => p.AppId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TAppFeature>()
                .HasOne(p => p.App)
                .WithMany(b => b.AppFeatures)
                .HasForeignKey(p => p.AppId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionApp>()
                .HasOne(p => p.App)
                .WithMany(b => b.SubscriptionApps)
                .HasForeignKey(p => p.AppId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionPlanApp>()
                .HasOne(p => p.App)
                .WithMany(b => b.SubscriptionPlanApps)
                .HasForeignKey(p => p.AppId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TAppAttribute>()
                .ToTable("AppAttributes", SCHEMA_NAME);

            modelBuilder.Entity<TAppFeature>()
                .ToTable("AppFeatures", SCHEMA_NAME);

            modelBuilder.Entity<TFeatureAction>()
                .ToTable("FeatureActions", SCHEMA_NAME);

            var features = modelBuilder.Entity<TFeature>()
                .ToTable("Features", SCHEMA_NAME);

            modelBuilder.Entity<TAppFeature>()
                .HasOne(p => p.Feature)
                .WithMany(b => b.AppFeatures)
                .HasForeignKey(p => p.AppId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TFeatureAction>()
                .HasOne(p => p.Feature)
                .WithMany(b => b.FeatureActions)
                .HasForeignKey(p => p.FeatureId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionFeature>()
                .HasOne(p => p.Feature)
                .WithMany(b => b.SubscriptionFeatures)
                .HasForeignKey(p => p.FeatureId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionPlanFeature>()
                .HasOne(p => p.Feature)
                .WithMany(b => b.SubscriptionPlanFeatures)
                .HasForeignKey(p => p.FeatureId)
                .HasPrincipalKey(b => b.Id);

            #endregion Apps

            #region Subscription Plans

            modelBuilder.Entity<TBillingCycleOption>()
                .ToTable("BillingCycleOptions", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionPlanApp>()
                .ToTable("SubscriptionPlanApps", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionPlanAttribute>()
                .ToTable("SubscriptionPlanAttributes", SCHEMA_NAME);

            var subscriptionPlans = modelBuilder.Entity<TSubscriptionPlan>()
                .ToTable("SubscriptionPlans", SCHEMA_NAME);

            modelBuilder.Entity<TBillingCycleOption>()
                .HasOne(p => p.SubscriptionPlan)
                .WithMany(b => b.BillingCycleOptions)
                .HasForeignKey(p => p.SubscriptionPlanId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionPlanAttribute>()
                .HasOne(p => p.SubscriptionPlan)
                .WithMany(b => b.Attributes)
                .HasForeignKey(p => p.SubscriptionPlanId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionPlanApp>()
                .HasOne(p => p.SubscriptionPlan)
                .WithMany(b => b.SubscriptionPlanApps)
                .HasForeignKey(p => p.SubscriptionPlanId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionPlanFeature>()
                .HasOne(p => p.SubscriptionPlan)
                .WithMany(b => b.SubscriptionPlanFeatures)
                .HasForeignKey(p => p.SubscriptionPlanId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscription>()
                .HasOne(p => p.SubscriptionPlan)
                .WithMany(b => b.Subscriptions)
                .HasForeignKey(p => p.SubscriptionPlanId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionPlanFeatureAttribute>()
                .ToTable("SubscriptionPlanFeatureAttributes", SCHEMA_NAME);

            var subscriptionPlanFeatures = modelBuilder.Entity<TSubscriptionPlanFeature>()
                .ToTable("SubscriptionPlanFeatures", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionFeatureAttribute>()
                .HasOne(p => p.SubscriptionFeature)
                .WithMany(b => b.SubscriptionFeatureAttributes)
                .HasForeignKey(p => p.SubscriptionFeatureId)
                .HasPrincipalKey(b => b.Id);

            #endregion Subscription Plans

            #region Subscriptions

            var subscriptionApps = modelBuilder.Entity<TSubscriptionApp>()
                .ToTable("SubscriptionApps", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionAppRole>()
                .HasOne(p => p.SubscriptionApp)
                .WithMany(b => b.SubscriptionAppRoles)
                .HasForeignKey(p => p.SubscriptionAppId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionAppUser>()
                .HasOne(p => p.SubscriptionApp)
                .WithMany(b => b.SubscriptionAppUsers)
                .HasForeignKey(p => p.SubscriptionAppId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionAppRole>()
                .ToTable("SubscriptionAppRoles", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionAppUser>()
                .ToTable("SubscriptionAppUsers", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionAttribute>()
                .ToTable("SubscriptionAttributes", SCHEMA_NAME);

            var subscriptions = modelBuilder.Entity<TSubscription>()
                .ToTable("Subscriptions", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionAttribute>()
                .HasOne(p => p.Subscription)
                .WithMany(b => b.Attributes)
                .HasForeignKey(p => p.SubscriptionId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionApp>()
             .HasOne(p => p.Subscription)
             .WithMany(b => b.SubscriptionApps)
             .HasForeignKey(p => p.SubscriptionId)
             .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionFeature>()
                .HasOne(p => p.Subscription)
                .WithMany(b => b.SubscriptionFeatures)
                .HasForeignKey(p => p.SubscriptionId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TBillingCycle>()
                .HasOne(p => p.Subscription)
                .WithMany(b => b.BillingCycles)
                .HasForeignKey(p => p.SubscriptionId)
                .HasPrincipalKey(b => b.Id);

            var billingCycles = modelBuilder.Entity<TBillingCycle>()
                .ToTable("BilingCycles", SCHEMA_NAME);

            modelBuilder.Entity<TBillingCycleAttribute>()
                .HasOne(p => p.BillingCycle)
                .WithMany(b => b.Attributes)
                .HasForeignKey(p => p.BillingCycleId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TBillingCycleFeatureUsage>()
                .HasOne(p => p.BillingCycle)
                .WithMany(b => b.FeatureUsage)
                .HasForeignKey(p => p.BillingCycleId)
                .HasPrincipalKey(b => b.Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TBillingCycleAttribute>()
                .ToTable("BillingCycleAttributes", SCHEMA_NAME);

            modelBuilder.Entity<TBillingCycleFeatureUsage>()
                .ToTable("BillingCycleFeatureUsage", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionFeatureAttribute>()
                .ToTable("SubscriptionFeatureAttributes", SCHEMA_NAME);

            var subscriptionFeatures = modelBuilder.Entity<TSubscriptionFeature>()
                .ToTable("SubscriptionFeatures", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionFeatureAttribute>()
                .HasOne(p => p.SubscriptionFeature)
                .WithMany(b => b.SubscriptionFeatureAttributes)
                .HasForeignKey(p => p.SubscriptionFeatureId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionFeatureRole>()
                .HasOne(p => p.SubscriptionFeature)
                .WithMany(b => b.SubscriptionFeatureRoles)
                .HasForeignKey(p => p.SubscriptionFeatureId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionFeatureUser>()
                .HasOne(p => p.SubscriptionFeature)
                .WithMany(b => b.SubscriptionFeatureUsers)
                .HasForeignKey(p => p.SubscriptionFeatureId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TBillingCycleFeatureUsage>()
                .HasOne(p => p.SubscriptionFeature)
                .WithMany(b => b.FeatureUsage)
                .HasForeignKey(p => p.SubscriptionFeatureId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionFeatureRoleAction>()
                .ToTable("SubscriptionFeatureRoleActions", SCHEMA_NAME);

            var subscriptionFeatureRoles = modelBuilder.Entity<TSubscriptionFeatureRole>()
                .ToTable("SubscriptionFeatureRole", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionFeatureRoleAction>()
                .HasOne(p => p.SubscriptionFeatureRole)
                .WithMany(b => b.SubscriptionFeatureRoleActions)
                .HasForeignKey(p => p.SubscriptionFeatureRoleId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TSubscriptionFeatureUserAction>()
                .ToTable("SubscriptionFeatureUserActions", SCHEMA_NAME);

            var subscriptionFeatureUsers = modelBuilder.Entity<TSubscriptionFeatureUser>()
                .ToTable("SubscriptionFeatureUsers", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionFeatureUserAction>()
                .HasOne(p => p.SubscriptionFeatureUser)
                .WithMany(b => b.SubscriptionFeatureUserActions)
                .HasForeignKey(p => p.SubscriptionFeatureUserId)
                .HasPrincipalKey(b => b.Id);

            #endregion Subscriptions

            #region Tenants

            var tenants = modelBuilder.Entity<TTenant>()
                .ToTable("Tenants", SCHEMA_NAME);

            modelBuilder.Entity<TTenantUser>()
                .HasOne(p => p.Tenant)
                .WithMany(b => b.TenantUsers)
                .HasForeignKey(p => p.TenantId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TTenantAttribute>()
                .HasOne(p => p.Tenant)
                .WithMany(b => b.Attributes)
                .HasForeignKey(p => p.TenantId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TTenantUser>()
                .ToTable("TenantUsers", SCHEMA_NAME);

            modelBuilder.Entity<TTenantAttribute>()
                .ToTable("TenantAttributes", SCHEMA_NAME);

            #endregion Tenants

            #region User Agreements

            var userAgreements = modelBuilder.Entity<TUserAgreement>()
                .ToTable("UserAgreements", SCHEMA_NAME);

            modelBuilder.Entity<TUserAgreementVersion>()
                .HasOne(p => p.UserAgreement)
                .WithMany(b => b.UserAgreementVersions)
                .HasForeignKey(p => p.UserAgreementId)
                .HasPrincipalKey(b => b.Id);

            var userAgreementVersions = modelBuilder.Entity<TUserAgreementVersion>()
                .ToTable("UserAgreementVersions", SCHEMA_NAME);

            modelBuilder.Entity<TUserAgreementVersionAction>()
                .HasOne(p => p.UserAgreementVersion)
                .WithMany(b => b.Actions)
                .HasForeignKey(p => p.UserAgreementVersionId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TUserAgreementVersionAction>()
                .ToTable("UserAgreementVersionActions", SCHEMA_NAME);

            #endregion User Agreements
        }
    }
}
