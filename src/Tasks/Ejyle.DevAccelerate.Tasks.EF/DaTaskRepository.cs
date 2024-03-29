﻿// ----------------------------------------------------------------------------------------------------------------------
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
using Ejyle.DevAccelerate.Tasks;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Tasks.EF
{
    public class DaTaskRepository : DaTaskRepository<string, DaTask, DbContext>
    {
        public DaTaskRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaTaskRepository<TKey, TTask, TDbContext>
        : DaEntityRepositoryBase<TKey, TTask, TDbContext>, IDaTaskRepository<TKey, TTask>
        where TKey : IEquatable<TKey>
        where TTask : DaTask<TKey>
        where TDbContext : DbContext
    {
        public DaTaskRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TTask> TasksSet { get { return DbContext.Set<TTask>(); } }

        public Task CreateAsync(TTask task)
        {
            TasksSet.Add(task);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TTask task)
        {
            TasksSet.Remove(task);
            return SaveChangesAsync();
        }

        public Task<TTask> FindByIdAsync(TKey id)
        {
            return TasksSet.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TTask task)
        {
            DbContext.Entry<TTask>(task).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TTask>> FindByAssignedToAsync(string assignedTo, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await TasksSet.Where(m => m.AssignedTo.Equals(assignedTo)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = TasksSet
                .Where(m => m.AssignedTo.Equals(assignedTo))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TTask>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public async Task<DaPaginatedEntityList<TKey, TTask>> FindByObjectInstanceIdAsync(string objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await TasksSet.Where(m => m.ObjectInstanceId.Equals(objectInstanceId)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = TasksSet
                .Where(m => m.ObjectInstanceId.Equals(objectInstanceId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TTask>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public async Task<DaPaginatedEntityList<TKey, TTask>> FindByTenantIdAsync(string tenantId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await TasksSet.Where(m => m.TenantId.Equals(tenantId)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = TasksSet
                .Where(m => m.TenantId.Equals(tenantId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TTask>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public IQueryable<TTask> Tasks => TasksSet.AsQueryable();
    }
}
