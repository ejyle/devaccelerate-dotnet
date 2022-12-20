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

namespace Ejyle.DevAccelerate.Lists.EF.Currencies
{
    public class DaCurrencyRepository : DaCurrencyRepository<string, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaCustomList, DaCustomListItem, DaListsDbContext>
    {
        public DaCurrencyRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaCurrencyRepository<TKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TCurrency, TDbContext>, IDaCurrencyRepository<TKey, TCurrency>
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
        public DaCurrencyRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task CreateAsync(TCurrency currency)
        {
            DbContext.Currencies.Add(currency);
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TCurrency currency)
        {
            DbContext.Currencies.Remove(currency);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<TCurrency>> FindAllAsync()
        {
            return DbContext.Currencies
                .Include(m => m.Countries)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCurrency>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await DbContext.Currencies.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = DbContext.Currencies
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.Countries)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TCurrency>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<TCurrency> FindByIdAsync(TKey id)
        {
            return DbContext.Currencies
                .Where(m => m.Id.Equals(id))
                .Include(m => m.Countries)
                .SingleOrDefaultAsync();
        }

        public Task<TCurrency> FindByNameAsync(string name)
        {
            return DbContext.Currencies
                .Where(m => m.Name == name)
                .Include(m => m.Countries)
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TCurrency currency)
        {
            DbContext.Entry(currency).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task<TCurrency> FindFirstAsync()
        {
            return DbContext.Currencies
                .Include(m => m.Countries)
                .FirstOrDefaultAsync();
        }

        public Task<TCurrency> FindByAlphabeticCodeAsync(string alphabeticCode)
        {
            return DbContext.Currencies
                .Where(m => m.AlphabeticCode == alphabeticCode)
                .Include(m => m.Countries)
                .SingleOrDefaultAsync();
        }

        public Task<TCurrency> FindByNameOrCodeAsync(string nameOrCode)
        {
            return DbContext.Currencies
                .Where(m => m.Name == nameOrCode || m.AlphabeticCode == nameOrCode)
                .Include(m => m.Countries)
                .SingleOrDefaultAsync();
        }
    }
}
