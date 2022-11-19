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
    public class DaCustomListRepository : DaGenericListRepository<int, int?, DaCustomList, DaCustomListItem, DaCountry, DaCountryRegion, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaListsDbContext>
    {
        public DaCustomListRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaGenericListRepository<TKey, TNullableKey, TCustomList, TCustomListItem, TCountry, TCountryRegion, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TDbContext>
        : DaEntityRepositoryBase<TKey, TCountry, TDbContext>, IDaCustomListRepository<TKey, TCustomList>
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TCountryTimeZone>
        where TDateFormat : DaDateFormat<TKey, TCountryDateFormat>
        where TSystemLanguage : DaSystemLanguage<TKey, TCountrySystemLanguage>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TCountryTimeZone : DaCountryTimeZone<TKey, TNullableKey, TCountry, TTimeZone>
        where TCountryDateFormat : DaCountryDateFormat<TKey, TNullableKey, TCountry, TDateFormat>
        where TCountrySystemLanguage : DaCountrySystemLanguage<TKey, TNullableKey, TCountry, TSystemLanguage>
        where TCustomList : DaCustomList<TKey, TCustomListItem>
        where TCustomListItem : DaCustomListItem<TKey, TCustomList>
        where TDbContext : DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem>
    {
        public DaGenericListRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TCustomList>> FindAllAsync()
        {
            return DbContext.CustomLists
                .Include(m => m.ListItems)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCustomList>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
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
                .SingleOrDefaultAsync();
        }

        public Task<TCustomList> FindByNameAsync(string name)
        {
            return DbContext.CustomLists
                .Where(m => m.Name == name)
                .Include(m => m.ListItems)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TCustomList list)
        {
            DbContext.CustomLists.Add(list);
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
    }
}
