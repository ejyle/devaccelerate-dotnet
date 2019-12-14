// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Subscriptions
{
    public class DaSubscriptionRepository : DaSubscriptionRepository<int, int?, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaApp, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycle, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DbContext>
    {
        public DaSubscriptionRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaSubscriptionRepository<TKey, TNullableKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TApp, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TDbContext>
        : DaEntityRepositoryBase<TKey, TSubscriptionPlan, TDbContext>, IDaSubscriptionRepository<TKey, TNullableKey, TSubscription>
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
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TNullableKey, TSubscriptionPlanAttribute, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TNullableKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan>
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

        public Task CreateAsync(TSubscription subscription)
        {
            Subscriptions.Add(subscription);
            return SaveChangesAsync();
        }

        public Task<List<TSubscription>> FindAllAsync()
        {
            return Subscriptions.ToListAsync();
        }

        public Task<TSubscription> FindByIdAsync(TKey id)
        {
            return Subscriptions.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<List<TSubscription>> FindByTenantIdAsync(TKey tenantId)
        {
            return Subscriptions.Where(m => m.TenantId.Equals(tenantId)).ToListAsync();
        }

        public Task UpdateAsync(TSubscription subscription)
        {
            DbContext.Entry<TSubscription>(subscription).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
