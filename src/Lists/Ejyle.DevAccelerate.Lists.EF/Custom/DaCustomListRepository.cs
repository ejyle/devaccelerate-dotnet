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
    public class DaCustomListRepository : DaCustomListRepository<string, DaCustomList, DaCustomListItem, DaCountry, DaCountryRegion, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaListsDbContext>
    {
        public DaCustomListRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaCustomListRepository<TKey, TCustomList, TCustomListItem, TCountry, TCountryRegion, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TDbContext>
        : DaEntityRepositoryBase<TKey, TCountry, TDbContext>, IDaCustomListRepository<TKey, TCustomList, TCustomListItem>
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TCountryTimeZone>
        where TDateFormat : DaDateFormat<TKey, TCountryDateFormat>
        where TSystemLanguage : DaSystemLanguage<TKey, TCountrySystemLanguage>
        where TCurrency : DaCurrency<TKey, TCountry>
        where TCountry : DaCountry<TKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat>
        where TCountryRegion : DaCountryRegion<TKey, TCountryRegion, TCountry>
        where TCountryTimeZone : DaCountryTimeZone<TKey, TCountry, TTimeZone>
        where TCountryDateFormat : DaCountryDateFormat<TKey, TCountry, TDateFormat>
        where TCountrySystemLanguage : DaCountrySystemLanguage<TKey, TCountry, TSystemLanguage>
        where TCustomList : DaCustomList<TKey, TCustomListItem>
        where TCustomListItem : DaCustomListItem<TKey, TCustomList, TCustomListItem>
        where TDbContext : DaListsDbContext<TKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem>
    {
        public DaCustomListRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TCustomList>> FindWithoutTenantIdAsync()
        {
            return DbContext.CustomLists
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithoutTenantIdAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await DbContext.CustomLists.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = DbContext.CustomLists
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
            return DbContext.CustomLists
                .Where(m => m.Id.Equals(id))
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .SingleOrDefaultAsync();
        }

        public Task<TCustomList> FindByKeyAsync(string key)
        {
            return DbContext.CustomLists
                .Where(m => m.Key == key)
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TCustomList list)
        {
            DbContext.CustomLists.Add(list);
            return DbContext.SaveChangesAsync();
        }

        public Task CreateAsync(TCustomList[] lists)
        {
            DbContext.CustomLists.AddRange(lists);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TCustomList list)
        {
            DbContext.Entry(list).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TCustomList list)
        {
            DbContext.CustomLists.Remove(list);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<TCustomList>> FindWithTenantIdAsync(TKey tenantId)
        {
            return DbContext.CustomLists
                .Where(m => m.TenantId.Equals(tenantId))
                .Include(m => m.ListItems)
                .ThenInclude(m => m.Children)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithTenantIdAsync(TKey tenantId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await DbContext.CustomLists.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = DbContext.CustomLists
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
            return DbContext.CustomListItems
                .Where(m => m.Id.Equals(listItemId))
                .Include(m => m.List)
                .Include(m => m.Children)
                .Include(m => m.Parent)
                .SingleOrDefaultAsync();
        }

        public Task DeleteListItemAsync(TCustomListItem customListItem)
        {
            customListItem.List.ListItems.Remove(customListItem);
            DbContext.CustomListItems.Remove(customListItem);
            return DbContext.SaveChangesAsync();
        }
    }
}
