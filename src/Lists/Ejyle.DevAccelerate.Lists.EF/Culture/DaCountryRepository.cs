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
    public class DaCountryRepository : DaCountryRepository<int, int?, DaCountry, DaCountryRegion, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaGenericList, DaGenericListItem, DaListsDbContext>
    {
        public DaCountryRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaCountryRepository<TKey, TNullableKey, TCountry, TCountryRegion, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TGenericList, TGenericListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TCountry, TDbContext>, IDaCountryRepository<TKey, TNullableKey, TCountry, TCountryRegion>
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
        public DaCountryRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TCountry>> FindAllAsync()
        {
            return DbContext.Countries.ToListAsync();
        }

        public Task<TCountry> FindByIdAsync(TKey id)
        {
            return DbContext.Countries
                .Where(m => m.Id.Equals(id))
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id)
        {
            return DbContext.CountryRegions
                .Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task<TCountry> FindByNameAsync(string name)
        {
            return DbContext.Countries
                .Where(m => m.Name == name)
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TCountry country)
        {
            DbContext.Countries.Add(country);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TCountry country)
        {
            DbContext.Entry(country).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TCountry country)
        {
            DbContext.Countries.Remove(country);
            return DbContext.SaveChangesAsync();
        }

        public Task<TCountry> FindByTwoLetterCodeAsync(string twoLetterCode)
        {
            return DbContext.Countries
                .Where(m => m.TwoLetterCode == twoLetterCode)
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task<TCountry> FindByThreeLetterCodeAsync(string threeLetterCode)
        {
            return DbContext.Countries
                .Where(m => m.ThreeLetterCode == threeLetterCode)
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync();
        }

        public Task<TCountry> FindFirstAsync()
        {
            return DbContext.Countries
                .Include(m => m.Regions)
                .Include(m => m.Currency)
                .FirstOrDefaultAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TCountry>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await DbContext.Countries.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = DbContext.Countries
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.Currency)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TCountry>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
