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
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.Objects;

namespace Ejyle.DevAccelerate.Core.EF.Objects
{
    public class DaObjectInstanceRepository : DaObjectInstanceRepository<string, DaObjectType, DaObjectInstance, DaObjectHistoryItem, DaObjectDependency, DbContext>
    {
        public DaObjectInstanceRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaObjectInstanceRepository<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency, TDbContext>
        : DaEntityRepositoryBase<TKey, TObjectInstance, TDbContext>, IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem, TObjectDependency>
        where TKey : IEquatable<TKey>
        where TObjectType : DaObjectType<TKey, TObjectInstance>
        where TObjectInstance : DaObjectInstance<TKey, TObjectType, TObjectHistoryItem, TObjectDependency>
        where TObjectHistoryItem : DaObjectHistoryItem<TKey, TObjectInstance>
        where TObjectDependency : DaObjectDependency<TKey, TObjectInstance>
        where TDbContext : DbContext
    {
        public DaObjectInstanceRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TObjectInstance> ObjectInstances { get { return DbContext.Set<TObjectInstance>(); } }
        private DbSet<TObjectHistoryItem> ObjectHistoryItems { get { return DbContext.Set<TObjectHistoryItem>(); } }
        private DbSet<TObjectDependency> ObjectDependencies { get { return DbContext.Set<TObjectDependency>(); } }

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
                .Include(m => m.ObjectHistoryItems)
                .SingleOrDefaultAsync();
        }

        public Task CreateHistoryAsync(TKey id, TObjectHistoryItem objHistoryItem)
        {
            objHistoryItem.ObjectInstanceId = id;
            ObjectHistoryItems.Add(objHistoryItem);
            return SaveChangesAsync();
        }

        public async Task ClearHistoryAsync(TKey id)
        {
            var objectInstnace = await ObjectInstances.Where(m => m.Id.Equals(id)).Include(m => m.ObjectHistoryItems).SingleOrDefaultAsync();

            if (objectInstnace != null && objectInstnace.ObjectHistoryItems != null)
            {
                ObjectHistoryItems.RemoveRange(objectInstnace.ObjectHistoryItems);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task ClearDependenciesAsync(TKey id)
        {
            var objectInstnace = await ObjectInstances.Where(m => m.Id.Equals(id)).Include(m => m.ObjectDependencies).SingleOrDefaultAsync();

            if (objectInstnace != null && objectInstnace.ObjectDependencies != null)
            {
                ObjectHistoryItems.RemoveRange(objectInstnace.ObjectHistoryItems);
                await DbContext.SaveChangesAsync();
            }
        }

        public Task<List<TObjectDependency>> FindDependenciesAsync(TKey id, int top = 10)
        {
            return ObjectDependencies.Where(m => m.ObjectInstanceId.Equals(id)).Take(top).ToListAsync();
        }

        public Task CreateDependencyAsync(TKey id, TObjectDependency dependency)
        {
            dependency.ObjectInstanceId = id;
            ObjectDependencies.Add(dependency);
            return DbContext.SaveChangesAsync();
        }

        public Task CreateDependencyAsync(TKey id, TObjectDependency[] dependencies)
        {
            foreach(var dependencyItem in dependencies)
            {
                dependencyItem.ObjectInstanceId = id;
            }

            ObjectDependencies.AddRange(dependencies);
            return DbContext.SaveChangesAsync();
        }

        public async Task DeleteDependenciesAsync(TKey[] objectDependencyId)
        {
            var dependencies = await ObjectDependencies.Where(m => objectDependencyId.Contains(m.Id)).ToListAsync();
            ObjectDependencies.RemoveRange(dependencies);
            await DbContext.SaveChangesAsync();
        }

        public Task<long> FindDepdencyCountAsync(TKey id)
        {
            return ObjectDependencies.Where(m => m.ObjectInstanceId.Equals(id)).LongCountAsync();
        }

        public Task<TObjectInstance> FindBySourceObjectIdAsync(string objectTypeId, string sourceObjectId)
        {
            return ObjectInstances.Where(m => m.ObjectTypeId.Equals(objectTypeId) && m.SourceObjectId.Equals(sourceObjectId)).SingleOrDefaultAsync();   
        }
    }
}