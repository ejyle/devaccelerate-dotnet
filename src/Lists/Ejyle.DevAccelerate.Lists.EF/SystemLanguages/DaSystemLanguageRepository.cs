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

namespace Ejyle.DevAccelerate.Lists.EF.SystemLanguages
{
    public class DaSystemLanguageRepository : DaSystemLanguageRepository<string, DaCountrySystemLanguage, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DbContext>
    {
        public DaSystemLanguageRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaSystemLanguageRepository<TKey, TCountrySystemLanguage, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TDbContext>
        : DaEntityRepositoryBase<TKey, TSystemLanguage, TDbContext>, IDaSystemLanguageRepository<TKey, TSystemLanguage>
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
        where TDbContext : DbContext
    {
        public DaSystemLanguageRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TSystemLanguage> SystemLanguagesSet { get { return DbContext.Set<TSystemLanguage>(); } }


        public Task<List<TSystemLanguage>> FindAllAsync()
        {
            return SystemLanguagesSet
                .Include(m => m.CountrySystemLanguages)
                .ThenInclude(m => m.Country)
                .ToListAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TSystemLanguage>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await SystemLanguagesSet.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = SystemLanguagesSet
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.CountrySystemLanguages)
                .ThenInclude(m => m.Country)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TSystemLanguage>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<TSystemLanguage> FindByIdAsync(TKey id)
        {
            return SystemLanguagesSet
                .Where(m => m.Id.Equals(id))
                .Include(m => m.CountrySystemLanguages)
                .ThenInclude(m => m.Country)
                .SingleOrDefaultAsync();
        }

        public Task<List<TSystemLanguage>> FindByCountryIdAsync(TKey countryId)
        {
            return SystemLanguagesSet
                .Where(m => m.CountrySystemLanguages.Any(x => x.CountryId.Equals(countryId)))
                .Include(m => m.CountrySystemLanguages)
                .ThenInclude(m => m.Country)
                .ToListAsync();
        }

        public Task CreateAsync(TSystemLanguage systemLanguage)
        {
            SystemLanguagesSet.Add(systemLanguage);
            return DbContext.SaveChangesAsync();
        }

        public Task CreateAsync(IEnumerable<TSystemLanguage> systemLanguages)
        {
            SystemLanguagesSet.AddRange(systemLanguages);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TSystemLanguage systemLanguage)
        {
            DbContext.Entry(systemLanguage).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TSystemLanguage systemLanguage)
        {
            SystemLanguagesSet.Remove(systemLanguage);
            return DbContext.SaveChangesAsync();
        }

        public Task<TSystemLanguage> FindByNameAsync(string name)
        {
            return SystemLanguagesSet.Where(m => m.Name == name)
                .Include(m => m.CountrySystemLanguages)
                .ThenInclude(m => m.Country)
                .SingleOrDefaultAsync();
        }

        public Task<TSystemLanguage> FindFirstAsync()
        {
            return SystemLanguagesSet
                .Include(m => m.CountrySystemLanguages)
                .ThenInclude(m => m.Country)
                .FirstOrDefaultAsync();
        }
    }
}