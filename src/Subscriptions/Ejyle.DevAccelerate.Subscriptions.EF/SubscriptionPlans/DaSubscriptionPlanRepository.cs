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
using Ejyle.DevAccelerate.Subscriptions.Subscriptions;
using Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Subscriptions.EF.SubscriptionPlans
{
    public class DaSubscriptionPlanRepository : DaSubscriptionPlanRepository<string, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DbContext>
    {
        public DaSubscriptionPlanRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaSubscriptionPlanRepository<TKey, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TDbContext>
        : DaEntityRepositoryBase<TKey, TSubscriptionPlan, TDbContext>, IDaSubscriptionPlanRepository<TKey, TSubscriptionPlan>
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
                .Include(m => m.SubscriptionPlanFeatures)
                .ToListAsync();
        }

        public Task<TSubscriptionPlan> FindByCodeAsync(string code)
        {
            return SubscriptionPlans.Where(m => m.Code == code)
                .Include(m => m.Attributes)
                .Include(m => m.BillingCycleOptions)
                .Include(m => m.SubscriptionPlanApps)
                .Include(m => m.SubscriptionPlanFeatures)
                .SingleOrDefaultAsync();
        }

        public Task<TSubscriptionPlan> FindByIdAsync(TKey id)
        {
            return SubscriptionPlans.Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes)
                .Include(m => m.BillingCycleOptions)
                .Include(m => m.SubscriptionPlanApps)
                .Include(m => m.SubscriptionPlanFeatures)
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TSubscriptionPlan subscriptionPlan)
        {
            DbContext.Entry<TSubscriptionPlan>(subscriptionPlan).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
