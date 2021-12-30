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
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Subscriptions
{
    public class DaSubscriptionRepository : DaSubscriptionRepository<int, int?, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaApp, DaAppAttribute, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DbContext>
    {
        public DaSubscriptionRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaSubscriptionRepository<TKey, TNullableKey, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TDbContext>
        : DaEntityRepositoryBase<TKey, TSubscriptionPlan, TDbContext>, IDaSubscriptionRepository<TKey, TNullableKey, TSubscription>
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
