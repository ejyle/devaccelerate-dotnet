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

namespace Ejyle.DevAccelerate.Lists.EF.Countries
{
    public class DaCountryRepository : DaCountryRepository<string, DaCountry, DaCountryRegion, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DbContext>
    {
        public DaCountryRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaCountryRepository<TKey, TCountry, TCountryRegion, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TDbContext>
        : DaEntityRepositoryBase<TKey, TCountry, TDbContext>, IDaCountryRepository<TKey, TCountry, TCountryRegion>
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
        public DaCountryRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TCountry> CountriesSet { get { return DbContext.Set<TCountry>(); } }
        private DbSet<TCountryRegion> CountryRegionsSet { get { return DbContext.Set<TCountryRegion>(); } }

        public Task<List<TCountry>> FindAllAsync()
        {
            return CountriesSet.ToListAsync();
        }

        public Task<TCountry> FindByIdAsync(TKey id)
        {
            return CountriesSet
                .Where(m => m.Id.Equals(id))
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id)
        {
            return CountryRegionsSet
                .Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task<TCountry> FindByNameAsync(string name)
        {
            return CountriesSet
                .Where(m => m.Name == name)
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TCountry country)
        {
            CountriesSet.Add(country);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TCountry country)
        {
            DbContext.Entry(country).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TCountry country)
        {
            CountriesSet.Remove(country);
            return DbContext.SaveChangesAsync();
        }

        public Task<TCountry> FindByTwoLetterCodeAsync(string twoLetterCode)
        {
            return CountriesSet
                .Where(m => m.TwoLetterCode == twoLetterCode)
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task<TCountry> FindByThreeLetterCodeAsync(string threeLetterCode)
        {
            return CountriesSet
                .Where(m => m.ThreeLetterCode == threeLetterCode)
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task<TCountry> FindFirstAsync()
        {
            return CountriesSet
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .FirstOrDefaultAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCountry>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await CountriesSet.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = CountriesSet
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.Currency)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TCountry>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<TCountry> FindByNameOrCodeAsync(string nameOrCode)
        {
            return CountriesSet
                .Where(m => m.Name == nameOrCode || m.TwoLetterCode == nameOrCode || m.ThreeLetterCode == nameOrCode)
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }
    }
}
