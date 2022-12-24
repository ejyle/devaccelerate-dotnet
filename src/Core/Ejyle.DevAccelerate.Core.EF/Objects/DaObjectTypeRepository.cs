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
    public class DaObjectTypeRepository : DaObjectTypeRepository<string, DaObjectType, DaObjectInstance, DaObjectHistoryItem, DaObjectDependency, DbContext>
    {
        public DaObjectTypeRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaObjectTypeRepository<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency, TDbContext>
        : DaEntityRepositoryBase<TKey, TObjectType, TDbContext>, IDaObjectTypeRepository<TKey, TObjectType>
        where TKey : IEquatable<TKey>
        where TObjectType : DaObjectType<TKey, TObjectInstance>
        where TObjectInstance : DaObjectInstance<TKey, TObjectType, TObjectHistoryItem, TObjectDependency>
        where TObjectHistoryItem : DaObjectHistoryItem<TKey, TObjectInstance>
        where TObjectDependency : DaObjectDependency<TKey, TObjectInstance>
        where TDbContext : DbContext
    {
        public DaObjectTypeRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TObjectType> ObjectTypes { get { return DbContext.Set<TObjectType>(); } }

        public Task CreateAsync(TObjectType objectType)
        {
            ObjectTypes.Add(objectType);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TObjectType objectType)
        {
            ObjectTypes.Remove(objectType);
            return SaveChangesAsync();
        }

        public Task<TObjectType> FindByIdAsync(TKey id)
        {
            return ObjectTypes.Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TObjectType objectType)
        {
            DbContext.Entry<TObjectType>(objectType).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
