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
using Ejyle.DevAccelerate.Core.Posts;

namespace Ejyle.DevAccelerate.Core.EF.Posts
{
    public class DaPostRepository : DaPostRepository<string, DaPost, DaPostRole, DaPostOrganizationGroup, DbContext>
    {
        public DaPostRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaPostRepository<TKey, TPost, TPostRole, TPostOrganizationGroup, TDbContext>
        : DaEntityRepositoryBase<TKey, TPost, TDbContext>, IDaPostRepository<TKey, TPost>
        where TKey : IEquatable<TKey>
        where TPost : DaPost<TKey, TPostRole, TPostOrganizationGroup>
        where TPostRole : DaPostRole<TKey, TPost>
        where TPostOrganizationGroup : DaPostOrganizationGroup<TKey, TPost>
        where TDbContext : DbContext
    {
        public DaPostRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TPost> PostSet { get { return DbContext.Set<TPost>(); } }

        public IQueryable<TPost> Posts { get { return PostSet.AsQueryable(); } }

        public Task CreateAsync(TPost post)
        {
            PostSet.Add(post);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TPost post)
        {
            PostSet.Remove(post);
            return SaveChangesAsync();
        }

        public Task<TPost> FindByIdAsync(TKey id)
        {
            return PostSet.Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TPost post)
        {
            DbContext.Entry<TPost>(post).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TPost>> FindAsync(DaDataPaginationCriteria paginationCriteria, string tenantId, string userId, string[] roleIds, string[] organizationGroupIds)
        {
            var totalCount = await PostSet.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = PostSet.AsQueryable();

            if(!string.IsNullOrEmpty(tenantId))
            {
                query = query.Where(m => m.TenantId.Equals(tenantId));
            }

            if (!string.IsNullOrEmpty(userId))
            {
                query = query.Where(m => m.UserId.Equals(userId));
            }

            if (roleIds != null && roleIds.Length > 0)
            {
                query = query.Where(m => m.Roles.Any(n => roleIds.Contains(n.RoleId)));
            }

            if (organizationGroupIds != null && organizationGroupIds.Length > 0)
            {
                query = query.Where(m => m.OrganizationGroups.Any(n => organizationGroupIds.Contains(n.OrganizationGroupId)));
            }

            query = query
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.Roles)
                .Include(m => m.OrganizationGroups)
                .OrderBy(m => m.CreatedDateUtc);

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TPost>(result, new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
