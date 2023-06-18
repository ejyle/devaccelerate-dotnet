// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Lists.Countries;
using Ejyle.DevAccelerate.Lists.Currencies;
using Ejyle.DevAccelerate.Lists.Custom;
using Ejyle.DevAccelerate.Lists.DateFormats;
using Ejyle.DevAccelerate.Lists.SystemLanguages;
using Ejyle.DevAccelerate.Lists.TimeZones;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Lists.EF.Custom
{
    public class DaCustomListRepository : DaCustomListRepository<string, DaCustomList, DaCustomListItem, DbContext>
    {
        public DaCustomListRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaCustomListRepository<TKey, TCustomList, TCustomListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TCustomList, TDbContext>, IDaCustomListRepository<TKey, TCustomList, TCustomListItem>
        where TKey : IEquatable<TKey>
        where TCustomList : DaCustomList<TKey, TCustomListItem>
        where TCustomListItem : DaCustomListItem<TKey, TCustomList, TCustomListItem>
        where TDbContext : DbContext
    {
        public DaCustomListRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TCustomList> CustomListsSet { get { return DbContext.Set<TCustomList>(); } }
        private DbSet<TCustomListItem> CustomListItemsSet { get { return DbContext.Set<TCustomListItem>(); } }


        public Task<List<TCustomList>> FindWithoutTenantIdAsync()
        {
            return CustomListsSet
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithoutTenantIdAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await CustomListsSet.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = CustomListsSet
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .OrderBy(m => m.Name)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TCustomList>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<TCustomList> FindByIdAsync(TKey id)
        {
            return CustomListsSet
                .Where(m => m.Id.Equals(id))
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .SingleOrDefaultAsync();
        }

        public Task<TCustomList> FindByKeyAsync(string key)
        {
            return CustomListsSet
                .Where(m => m.Key == key)
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TCustomList list)
        {
            CustomListsSet.Add(list);
            return DbContext.SaveChangesAsync();
        }

        public Task CreateAsync(TCustomList[] lists)
        {
            CustomListsSet.AddRange(lists);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TCustomList list)
        {
            DbContext.Entry(list).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TCustomList list)
        {
            CustomListsSet.Remove(list);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<TCustomList>> FindWithTenantIdAsync(string tenantId)
        {
            return CustomListsSet
                .Where(m => m.TenantId.Equals(tenantId))
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithTenantIdAsync(string tenantId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await CustomListsSet.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = CustomListsSet
                .Where(m => m.TenantId.Equals(m.TenantId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .OrderBy(m => m.Name)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TCustomList>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<TCustomListItem> FindListItemByIdAsync(TKey listItemId)
        {
            return CustomListItemsSet
                .Where(m => m.Id.Equals(listItemId))
                .Include(m => m.List)
                .Include(m => m.Children)
                .Include(m => m.Parent)
                .SingleOrDefaultAsync();
        }

        public Task DeleteListItemAsync(TCustomListItem customListItem)
        {
            customListItem.List.ListItems.Remove(customListItem);
            CustomListItemsSet.Remove(customListItem);
            return DbContext.SaveChangesAsync();
        }
    }
}
