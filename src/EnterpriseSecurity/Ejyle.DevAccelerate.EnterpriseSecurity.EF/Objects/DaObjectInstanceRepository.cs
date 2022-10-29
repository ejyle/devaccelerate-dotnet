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
using Ejyle.DevAccelerate.EnterpriseSecurity.Objects;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Objects
{
    public class DaObjectInstanceRepository : DaObjectInstanceRepository<int, DaObjectType, DaObjectInstance, DaObjectHistoryItem, DbContext>
    {
        public DaObjectInstanceRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaObjectInstanceRepository<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TObjectInstance, TDbContext>, IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem>
        where TKey : IEquatable<TKey>
        where TObjectType : DaObjectType<TKey, TObjectInstance>
        where TObjectInstance : DaObjectInstance<TKey, TObjectType, TObjectHistoryItem>
        where TObjectHistoryItem : DaObjectHistoryItem<TKey, TObjectInstance>
        where TDbContext : DbContext
    {
        public DaObjectInstanceRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TObjectInstance> ObjectInstances { get { return DbContext.Set<TObjectInstance>(); } }
        private DbSet<TObjectHistoryItem> ObjectHistoryItems { get { return DbContext.Set<TObjectHistoryItem>(); } }

        public Task CreateAsync(TObjectInstance objectInstance)
        {
            ObjectInstances.Add(objectInstance);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TObjectInstance objectInstance)
        {
            ObjectInstances.Remove(objectInstance);
            return SaveChangesAsync();
        }

        public Task<TObjectInstance> FindByIdAsync(TKey id)
        {
            return ObjectInstances.Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task CreateObjectHistoryItemAsync(TKey id, TObjectHistoryItem objectHistoryItem)
        {
            objectHistoryItem.ObjectInstanceId = id;
            ObjectHistoryItems.Add(objectHistoryItem);
            return SaveChangesAsync();
        }
    }
}
