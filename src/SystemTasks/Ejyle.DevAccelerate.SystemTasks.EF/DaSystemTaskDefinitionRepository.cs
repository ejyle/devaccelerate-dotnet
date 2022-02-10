// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SystemTasks.EF
{
    public class DaSystemTaskDefinitionRepository : DaSystemTaskRepository<long, DaSystemTaskDefinition, DaSystemTaskDefinitionAttribute, DaSystemTasksDbContext>
    {
        public DaSystemTaskDefinitionRepository(DaSystemTasksDbContext dbContext)
            : base(dbContext)
        { }
    }
    
    public class DaSystemTaskRepository<TKey, TSystemTaskDefinition, TSystemTaskDefinitionAttribute, TDbContext>
        : DaEntityRepositoryBase<TKey, TSystemTaskDefinition, TDbContext>, IDaSystemTaskDefinitionRepository<TKey, TSystemTaskDefinition>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : DaSystemTaskDefinition<TKey, TSystemTaskDefinitionAttribute>
        where TSystemTaskDefinitionAttribute : DaSystemTaskAttribute<TKey, TSystemTaskDefinition>
        where TDbContext : DaSystemTasksDbContext<TKey, TSystemTaskDefinition, TSystemTaskDefinitionAttribute>
    {
        public DaSystemTaskRepository(TDbContext dbContext)
             : base(dbContext)
        { }

        public Task<List<TSystemTaskDefinition>> FindInProgressAsync(int top)
        {
            return DbContext.SystemTaskDefinitions
                .Where(m => m.Status == DaSystemTaskStatus.InProgress)
                .Include(m => m.Attributes)
                .Take(top)
                .ToListAsync();
        }

        public Task<List<TSystemTaskDefinition>> FindNewAsync(int top)
        {
            return DbContext.SystemTaskDefinitions
                .Where(m => m.Status == DaSystemTaskStatus.New)
                .Include(m => m.Attributes)
                .Take(top)
                .ToListAsync();
        }

        public Task<TSystemTaskDefinition> FindByIdAsync(TKey id)
        {
            return DbContext.SystemTaskDefinitions
                .Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TSystemTaskDefinition systemTask)
        {
            DbContext.SystemTaskDefinitions.Add(systemTask);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TSystemTaskDefinition systemTask)
        {
            DbContext.Entry(systemTask).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TSystemTaskDefinition systemTask)
        {
            DbContext.SystemTaskDefinitions.Remove(systemTask);
            return DbContext.SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TSystemTaskDefinition>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await DbContext.SystemTaskDefinitions.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = DbContext.SystemTaskDefinitions
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.Attributes)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TSystemTaskDefinition>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public async Task CreateAsync(List<TSystemTaskDefinition> systemTasks)
        {
            await DbContext.SystemTaskDefinitions.AddRangeAsync(systemTasks);
            await DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(List<TSystemTaskDefinition> systemTasks)
        {
            foreach(var systemTask in systemTasks)
            {
                DbContext.Entry(systemTask).State = EntityState.Modified;
            }

            return DbContext.SaveChangesAsync();
        }

        public async Task ClearAsync(int olderThanInDays, List<DaSystemTaskStatus> statusCriteria)
        {
            DateTime currentDateTime = DateTime.UtcNow;

            List<TSystemTaskDefinition> systemTasks = null;

            if (statusCriteria != null && statusCriteria.Count > 0)
            {
                systemTasks = await DbContext.SystemTaskDefinitions
                    .Where(m => (currentDateTime - m.CreatedDateUtc).TotalDays > olderThanInDays
                    && statusCriteria.Contains(m.Status))
                    .Include(m => m.Attributes)
                    .ToListAsync();
            }
            else
            {
                systemTasks = await DbContext.SystemTaskDefinitions
                    .Where(m => (currentDateTime - m.CreatedDateUtc).TotalDays > olderThanInDays)
                    .Include(m => m.Attributes)
                    .ToListAsync();
            }

            DbContext.SystemTaskDefinitions.RemoveRange(systemTasks);
            await DbContext.SaveChangesAsync();
        }
    }
}
