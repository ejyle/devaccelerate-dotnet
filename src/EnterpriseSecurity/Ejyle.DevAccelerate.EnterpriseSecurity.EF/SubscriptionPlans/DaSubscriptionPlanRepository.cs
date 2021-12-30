// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.SubscriptionPlans
{
    public class DaSubscriptionPlanRepository : DaSubscriptionPlanRepository<int, int?, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaApp, DaAppAttribute, DaFeature, DaAppFeature, DaFeatureAction, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DbContext>
    {
        public DaSubscriptionPlanRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaSubscriptionPlanRepository<TKey, TNullableKey, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction,  TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TDbContext>
        : DaEntityRepositoryBase<TKey, TSubscriptionPlan, TDbContext>, IDaSubscriptionPlanRepository<TKey, TNullableKey, TSubscriptionPlan>
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TNullableKey, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TNullableKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TNullableKey, TFeature>
        where TFeature : DaFeature<TKey, TNullableKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
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
        where TDbContext : DbContext
    {
        public DaSubscriptionPlanRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TSubscriptionPlan> SubscriptionPlans { get { return DbContext.Set<TSubscriptionPlan>(); } }

        public Task CreateAsync(TSubscriptionPlan subscriptionPlan)
        {
            SubscriptionPlans.Add(subscriptionPlan);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TSubscriptionPlan subscriptionPlan)
        {
            SubscriptionPlans.Remove(subscriptionPlan);
            return SaveChangesAsync();
        }

        public Task<List<TSubscriptionPlan>> FindAllAsync()
        {
            return SubscriptionPlans.Include(m => m.Attributes)
                .Include(m => m.BillingCycleOptions)
                .Include(m => m.SubscriptionPlanApps)
                .ThenInclude(m => m.App)
                .Include(m => m.SubscriptionPlanFeatures)
                .ThenInclude(m => m.Feature)
                .ToListAsync();
        }

        public Task<TSubscriptionPlan> FindByCodeAsync(string code)
        {
            return SubscriptionPlans.Where(m => m.Code == code)
                .Include(m => m.Attributes)
                .Include(m => m.BillingCycleOptions)
                .Include(m => m.SubscriptionPlanApps)
                .ThenInclude(m => m.App)
                .Include(m => m.SubscriptionPlanFeatures)
                .ThenInclude(m => m.Feature)
                .SingleOrDefaultAsync();
        }

        public Task<TSubscriptionPlan> FindByIdAsync(TKey id)
        {
            return SubscriptionPlans.Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes)
                .Include(m => m.BillingCycleOptions)
                .Include(m => m.SubscriptionPlanApps)
                .ThenInclude(m => m.App)
                .Include(m => m.SubscriptionPlanFeatures)
                .ThenInclude(m => m.Feature)
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TSubscriptionPlan subscriptionPlan)
        {
            DbContext.Entry<TSubscriptionPlan>(subscriptionPlan).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
