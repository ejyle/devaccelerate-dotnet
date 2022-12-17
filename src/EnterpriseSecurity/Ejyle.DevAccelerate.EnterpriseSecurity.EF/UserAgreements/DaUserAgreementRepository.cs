// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.UserAgreements
{
    public class DaUserAgreementRepository : DaUserAgreementRepository<string, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaApp, DaAppAttribute, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DbContext>
    {
        public DaUserAgreementRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TDbContext>
        : DaEntityRepositoryBase<TKey, TSubscriptionPlan, TDbContext>, IDaUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TFeature>
        where TFeature : DaFeature<TKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
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
        where TDbContext : DbContext
    {
        public DaUserAgreementRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TUserAgreement> UserAgreements { get { return DbContext.Set<TUserAgreement>(); } }
        private DbSet<TUserAgreementVersion> UserAgreementVersions { get { return DbContext.Set<TUserAgreementVersion>(); } }
        private DbSet<TUserAgreementVersionAction> UserAgreementVersionActions { get { return DbContext.Set<TUserAgreementVersionAction>(); } }

        public Task CreateAsync(TUserAgreement userAgreement)
        {
            UserAgreements.Add(userAgreement);
            return SaveChangesAsync();
        }

        public Task CreateAsync(TUserAgreementVersionAction userAgreementVersionAction)
        {
            UserAgreementVersionActions.Add(userAgreementVersionAction);
            return SaveChangesAsync();
        }

        public Task<TUserAgreement> FindByIdAsync(TKey id)
        {
            return UserAgreements
                .Where(m => m.Id.Equals(id))
                .Include(m => m.UserAgreementVersions)
                .SingleOrDefaultAsync();
        }

        public Task<TUserAgreement> FindByKeyAsync(string key)
        {
            return UserAgreements
                .Where(m => m.Key == key)
                .Include(m => m.UserAgreementVersions)
                .SingleOrDefaultAsync();
        }

        public Task<TUserAgreement> FindByVersionIdAsync(TKey userAgreementVersionId)
        {
            return UserAgreements
                .Where(m => m.UserAgreementVersions
                .Any(n => n.Id.Equals(userAgreementVersionId)))
                .Include(m => m.UserAgreementVersions)
                .SingleOrDefaultAsync();
        }

        public Task<TUserAgreementVersion> FindCurrentUserAgreementVersionAsync(string key)
        {
            return UserAgreementVersions
                .Where(m => m.UserAgreement.Key == key && m.IsCurrent == true)
                .Include(m => m.UserAgreement)
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TUserAgreement userAgreement)
        {
            DbContext.Entry<TUserAgreement>(userAgreement).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
