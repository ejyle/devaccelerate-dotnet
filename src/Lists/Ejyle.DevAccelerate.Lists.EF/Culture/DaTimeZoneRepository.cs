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
using Ejyle.DevAccelerate.Lists.Culture;
using Ejyle.DevAccelerate.Lists.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Lists.EF.Culture
{
    public class DaTimeZoneRepository : DaTimeZoneRepository<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaGenericList, DaGenericListItem, DaListsDbContext>
    {
        public DaTimeZoneRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaTimeZoneRepository<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TGenericList, TGenericListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TTimeZone, TDbContext>, IDaTimeZoneRepository<TKey, TTimeZone>
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
        where TGenericList : DaGenericList<TKey, TGenericListItem>
        where TGenericListItem : DaGenericListItem<TKey, TGenericList>
        where TDbContext : DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TGenericList, TGenericListItem>
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