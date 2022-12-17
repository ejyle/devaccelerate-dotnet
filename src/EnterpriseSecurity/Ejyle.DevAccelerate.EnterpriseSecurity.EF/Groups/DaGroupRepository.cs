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
using Ejyle.DevAccelerate.EnterpriseSecurity.Groups;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Groups
{
    public class DaGroupRepository : DaGroupRepository<string, DaGroup, DaGroupRole, DaGroupUser, DbContext>
    {
        public DaGroupRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaGroupRepository<TKey, TGroup, TGroupRole, TGroupUser, TDbContext>
        : DaEntityRepositoryBase<TKey, TGroup, TDbContext>, IDaGroupRepository<TKey, TGroup>
        where TKey : IEquatable<TKey>
        where TGroup : DaGroup<TKey, TGroupRole, TGroupUser>
        where TGroupRole : DaGroupRole<TKey, TGroup>
        where TGroupUser : DaGroupUser<TKey, TGroup>
        where TDbContext : DbContext
    {
        public DaGroupRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TGroup> Groups { get { return DbContext.Set<TGroup>(); } }

        public Task AddUserAsync(TKey id, TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TGroup objectType)
        {
            Groups.Add(objectType);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TGroup objectType)
        {
            Groups.Remove(objectType);
            return SaveChangesAsync();
        }

        public Task<TGroup> FindByIdAsync(TKey id)
        {
            return Groups.Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task<List<TKey>> FindUserRolesByUserIdAsync(TKey tenantId, TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserInRoleAsync(TKey tenantId, TKey roleId, TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserAsync(TKey id, TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TGroup objectType)
        {
            DbContext.Entry<TGroup>(objectType).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
