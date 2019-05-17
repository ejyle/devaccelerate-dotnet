// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF
{
    public class DaEnterpriseSecurityDbContext : DaEnterpriseSecurityDbContext<int, int?, DaTenant, DaTenantUser, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaApp, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlan, DaBillingCycle, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction>
    {
        public DaEnterpriseSecurityDbContext() : base()
        { }

        public static DaEnterpriseSecurityDbContext Create()
        {
            return new DaEnterpriseSecurityDbContext();
        }
    }

    public class DaEnterpriseSecurityDbContext<TKey, TNullableKey, TTenant, TTenantUser, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TApp, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlan, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction> : DbContext
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TNullableKey, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycle : DaBillingCycle<TKey, TNullableKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TNullableKey, TFeature>
        where TFeature : DaFeature<TKey, TNullableKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TNullableKey, TApp, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TNullableKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TNullableKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TNullableKey, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TNullableKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TNullableKey, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscription : DaSubscription<TKey, TNullableKey, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan>
        where TTenant : DaTenant<TKey, TNullableKey, TTenantUser>
        where TTenantUser : DaTenantUser<TKey, TNullableKey, TTenant>
        where TUserAgreement : DaUserAgreement<TKey, TNullableKey, TApp, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TNullableKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
    {
        private const string SCHEMA_NAME = "EnterpriseSecurity";

        public DaEnterpriseSecurityDbContext()
            : base(DaDbConnectionHelper.GetConnectionString())
        {
        }

        public DaEnterpriseSecurityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public virtual DbSet<TAppFeature> AppFeatures { get; set; }
        public virtual DbSet<TApp> Apps { get; set; }
        public virtual DbSet<TBillingCycle> BillingCycles { get; set; }
        public virtual DbSet<TFeatureAction> FeatureActions { get; set; }
        public virtual DbSet<TFeature> Features { get; set; }
        public virtual DbSet<TSubscriptionAppRole> SubscriptionAppRoles { get; set; }
        public virtual DbSet<TSubscriptionApp> SubscriptionApps { get; set; }
        public virtual DbSet<TSubscriptionAppUser> SubscriptionAppUsers { get; set; }
        public virtual DbSet<TSubscriptionFeatureAttribute> SubscriptionFeatureAttributes { get; set; }
        public virtual DbSet<TSubscriptionFeatureRoleAction> SubscriptionFeatureRoleActions { get; set; }
        public virtual DbSet<TSubscriptionFeatureRole> SubscriptionFeatureRoles { get; set; }
        public virtual DbSet<TSubscriptionFeature> SubscriptionFeatures { get; set; }
        public virtual DbSet<TSubscriptionFeatureUserAction> SubscriptionFeatureUserActions { get; set; }
        public virtual DbSet<TSubscriptionFeatureUser> SubscriptionFeatureUsers { get; set; }
        public virtual DbSet<TSubscriptionPlanApp> SubscriptionPlanApps { get; set; }
        public virtual DbSet<TSubscriptionPlanFeatureAttribute> SubscriptionPlanFeatureAttributes { get; set; }
        public virtual DbSet<TSubscriptionPlanFeature> SubscriptionPlanFeatures { get; set; }
        public virtual DbSet<TSubscriptionPlan> SubscriptionPlans { get; set; }
        public virtual DbSet<TSubscription> Subscriptions { get; set; }
        public virtual DbSet<TTenant> Tenants { get; set; }
        public virtual DbSet<TTenantUser> TenantUsers { get; set; }
        public virtual DbSet<TUserAgreement> UserAgreements { get; set; }
        public virtual DbSet<TUserAgreementVersion> UserAgreementVersions { get; set; }
        public virtual DbSet<TUserAgreementVersionAction> UserAgreementVersionActions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Apps

            var apps = modelBuilder.Entity<TApp>()
                .ToTable("Apps", SCHEMA_NAME);

            apps.HasMany(e => e.AppFeatures)
                .WithRequired(e => e.App)
                .WillCascadeOnDelete(false);

            apps.HasMany(e => e.SubscriptionApps)
                .WithRequired(e => e.App)
                .WillCascadeOnDelete(false);

            apps.HasMany(e => e.SubscriptionPlanApps)
                .WithRequired(e => e.App)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAppFeature>()
                .ToTable("AppFeatures", SCHEMA_NAME);

            modelBuilder.Entity<TFeatureAction>()
                .ToTable("FeatureActions", SCHEMA_NAME);

            var features = modelBuilder.Entity<TFeature>()
                .ToTable("Features", SCHEMA_NAME);

            features.HasMany(e => e.AppFeatures)
                .WithRequired(e => e.Feature)
                .WillCascadeOnDelete(false);

            features.HasMany(e => e.FeatureActions)
                .WithRequired(e => e.Feature)
                .WillCascadeOnDelete(false);

            features.HasMany(e => e.SubscriptionFeatures)
                .WithRequired(e => e.Feature)
                .WillCascadeOnDelete(false);

            features.HasMany(e => e.SubscriptionPlanFeatures)
                .WithRequired(e => e.Feature)
                .WillCascadeOnDelete(false);

            #endregion Apps

            #region Subscription Plans

            modelBuilder.Entity<TBillingCycle>()
                .ToTable("BillingCycles", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionPlanApp>()
                .ToTable("SubscriptionPlanApps", SCHEMA_NAME);

            var subscriptionPlans = modelBuilder.Entity<TSubscriptionPlan>()
                .ToTable("SubscriptionPlans", SCHEMA_NAME);

            subscriptionPlans.HasMany(e => e.BillingCycles)
                .WithRequired(e => e.SubscriptionPlan)
                .WillCascadeOnDelete(false);

            subscriptionPlans.HasMany(e => e.SubscriptionPlanApps)
                .WithRequired(e => e.SubscriptionPlan)
                .WillCascadeOnDelete(false);

            subscriptionPlans.HasMany(e => e.SubscriptionPlanFeatures)
                .WithRequired(e => e.SubscriptionPlan)
                .WillCascadeOnDelete(false);

            subscriptionPlans.HasMany(e => e.Subscriptions)
                .WithRequired(e => e.SubscriptionPlan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSubscriptionPlanFeatureAttribute>()
                .ToTable("SubscriptionPlanFeatureAttributes", SCHEMA_NAME);

            var subscriptionPlanFeatures = modelBuilder.Entity<TSubscriptionPlanFeature>()
                .ToTable("SubscriptionPlanFeatures", SCHEMA_NAME);

            subscriptionPlanFeatures.HasMany(e => e.SubscriptionPlanFeatureAttributes)
                .WithRequired(e => e.SubscriptionPlanFeature)
                .WillCascadeOnDelete(false);

            #endregion Subscription Plans

            #region Subscriptions

            var subscriptionApps = modelBuilder.Entity<TSubscriptionApp>()
                .ToTable("SubscriptionApps", SCHEMA_NAME);

            subscriptionApps.HasMany(e => e.SubscriptionAppRoles)
                .WithRequired(e => e.SubscriptionApp)
                .WillCascadeOnDelete(false);

            subscriptionApps.HasMany(e => e.SubscriptionAppUsers)
                .WithRequired(e => e.SubscriptionApp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSubscriptionAppRole>()
                .ToTable("SubscriptionAppRoles", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionAppUser>()
                .ToTable("SubscriptionAppUsers", SCHEMA_NAME);

            var subscriptions = modelBuilder.Entity<TSubscription>()
                .ToTable("Subscriptions", SCHEMA_NAME);

            subscriptions.HasMany(e => e.SubscriptionApps)
                .WithRequired(e => e.Subscription)
                .WillCascadeOnDelete(false);

            subscriptions.HasMany(e => e.SubscriptionFeatures)
                .WithRequired(e => e.Subscription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSubscriptionFeatureAttribute>()
                .ToTable("SubscriptionFeatureAttributes", SCHEMA_NAME);

            var subscriptionFeatures = modelBuilder.Entity<TSubscriptionFeature>()
                .ToTable("SubscriptionFeatures", SCHEMA_NAME);

            subscriptionFeatures.HasMany(e => e.SubscriptionFeatureAttributes)
                .WithRequired(e => e.SubscriptionFeature)
                .WillCascadeOnDelete(false);

            subscriptionFeatures.HasMany(e => e.SubscriptionFeatureRoles)
                .WithRequired(e => e.SubscriptionFeature)
                .WillCascadeOnDelete(false);

            subscriptionFeatures.HasMany(e => e.SubscriptionFeatureUsers)
                .WithRequired(e => e.SubscriptionFeature)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSubscriptionFeatureRoleAction>()
                .ToTable("SubscriptionFeatureRoleActions", SCHEMA_NAME);

            var subscriptionFeatureRoles = modelBuilder.Entity<TSubscriptionFeatureRole>()
                .ToTable("SubscriptionFeatureRole", SCHEMA_NAME);

            subscriptionFeatureRoles.HasMany(e => e.SubscriptionFeatureRoleActions)
                .WithRequired(e => e.SubscriptionFeatureRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSubscriptionFeatureUserAction>()
                .ToTable("SubscriptionFeatureUserActions", SCHEMA_NAME);

            var subscriptionFeatureUsers = modelBuilder.Entity<TSubscriptionFeatureUser>()
                .ToTable("SubscriptionFeatureUsers", SCHEMA_NAME);

            subscriptionFeatureUsers.HasMany(e => e.SubscriptionFeatureUserActions)
                 .WithRequired(e => e.SubscriptionFeatureUser)
                 .WillCascadeOnDelete(false);

            #endregion Subscriptions

            #region Tenants

            var tenants = modelBuilder.Entity<TTenant>()
                .ToTable("Tenants", SCHEMA_NAME);

            tenants.HasMany(e => e.TenantUsers)
                .WithRequired(e => e.Tenant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TTenantUser>()
                .ToTable("TenantUsers", SCHEMA_NAME);

            #endregion Tenants

            #region User Agreements

            var userAgreements = modelBuilder.Entity<TUserAgreement>()
                .ToTable("UserAgreements", SCHEMA_NAME);

            userAgreements.HasMany(e => e.UserAgreementVersions)
                .WithRequired(e => e.UserAgreement)
                .WillCascadeOnDelete(false);

            var userAgreementVersions = modelBuilder.Entity<TUserAgreementVersion>()
                .ToTable("UserAgreementVersions", SCHEMA_NAME);

            userAgreementVersions.HasMany(e => e.Actions)
                .WithRequired(e => e.UserAgreementVersion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TUserAgreementVersionAction>()
                .ToTable("UserAgreementVersionActions", SCHEMA_NAME);

            #endregion User Agreements
        }
    }
}
