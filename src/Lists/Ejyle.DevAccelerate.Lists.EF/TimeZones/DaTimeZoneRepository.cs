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

namespace Ejyle.DevAccelerate.Lists.EF.TimeZones
{
    public class DaTimeZoneRepository : DaTimeZoneRepository<string, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaCustomList, DaCustomListItem, DaListsDbContext>
    {
        public DaTimeZoneRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaTimeZoneRepository<TKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TTimeZone, TDbContext>, IDaTimeZoneRepository<TKey, TTimeZone>
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
        where TCustomListItem : DaCustomListItem<TKey, TCustomList>
        where TDbContext : DaListsDbContext<TKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem>
    {
        public DaTimeZoneRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TTimeZone>> FindAllAsync()
        {
            return DbContext.TimeZones
                .Include(m => m.CountryTimeZones)
                .ThenInclude(m => m.Country)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TTimeZone>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await DbContext.TimeZones.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = DbContext.TimeZones
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.CountryTimeZones)
                .ThenInclude(m => m.Country)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TTimeZone>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<TTimeZone> FindByIdAsync(TKey id)
        {
            return DbContext.TimeZones
                .Where(m => m.Id.Equals(id))
                .Include(m => m.CountryTimeZones)
                .ThenInclude(m => m.Country)
                .SingleOrDefaultAsync();
        }

        public Task<List<TTimeZone>> FindByCountryIdAsync(TKey countryId)
        {
            return DbContext.TimeZones
                .Where(m => m.CountryTimeZones.Any(x => x.CountryId.Equals(countryId)))
                .Include(m => m.CountryTimeZones)
                .ThenInclude(m => m.Country)
                .ToListAsync();
        }

        public Task CreateAsync(TTimeZone timeZone)
        {
            DbContext.TimeZones.Add(timeZone);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TTimeZone timeZone)
        {
            DbContext.Entry(timeZone).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TTimeZone timeZone)
        {
            DbContext.TimeZones.Remove(timeZone);
            return DbContext.SaveChangesAsync();
        }

        public Task<TTimeZone> FindByNameAsync(string name)
        {
            return DbContext.TimeZones
                .Where(m => m.Name == name)
                .Include(m => m.CountryTimeZones)
                .ThenInclude(m => m.Country)
                .SingleOrDefaultAsync();
        }

        public Task<TTimeZone> FindFirstAsync()
        {
            return DbContext.TimeZones
                .Include(m => m.CountryTimeZones)
                .ThenInclude(m => m.Country)
                .FirstOrDefaultAsync();
        }
    }
}