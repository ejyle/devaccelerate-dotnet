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
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.Subscriptions.EF.Subscriptions
{
    public class DaSubscriptionRepository : DaSubscriptionRepository<string, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DbContext>
    {
        public DaSubscriptionRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaSubscriptionRepository<TKey, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TDbContext>
        : DaEntityRepositoryBase<TKey, TSubscriptionPlan, TDbContext>, IDaSubscriptionRepository<TKey, TSubscription>
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
        public DaSubscriptionRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TSubscription> Subscriptions { get { return DbContext.Set<TSubscription>(); } }
        private DbSet<TBillingCycleFeatureUsage> FeatureUsage { get { return DbContext.Set<TBillingCycleFeatureUsage>(); } }

        public Task CreateAsync(TSubscription subscription)
        {
            Subscriptions.Add(subscription);
            return SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TSubscription>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await Subscriptions.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = Subscriptions
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.Attributes)
                .Include(m => m.BillingCycles)
                .Include(m => m.SubscriptionApps)
                .Include(m => m.SubscriptionFeatures)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TSubscription>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<TSubscription> FindByIdAsync(TKey id)
        {
            return Subscriptions
                .Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes)
                .Include(m => m.BillingCycles)
                .Include(m => m.SubscriptionApps)
                .Include(m => m.SubscriptionFeatures)
                .SingleOrDefaultAsync();
        }

        public Task<List<TSubscription>> FindByTenantIdAsync(TKey tenantId)
        {
            return Subscriptions
                .Where(m => m.TenantId.Equals(tenantId))
                .Include(m => m.Attributes)
                .Include(m => m.BillingCycles)
                .Include(m => m.SubscriptionApps)
                .Include(m => m.SubscriptionFeatures)
                .ToListAsync();
        }

        public Task SetBillingCycleFeatureUsageQuantityAsync(TKey billingCycleFeatureUsageId, double value)
        {
            var billingCycleFeatureUsage = FeatureUsage.Where(m => m.Id.Equals(billingCycleFeatureUsageId)).SingleOrDefault();
            billingCycleFeatureUsage.Quantity = value;

            DbContext.Entry<TBillingCycleFeatureUsage>(billingCycleFeatureUsage).State = EntityState.Modified;

            return SaveChangesAsync();
        }

        public Task UpdateAsync(TSubscription subscription)
        {
            DbContext.Entry<TSubscription>(subscription).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
