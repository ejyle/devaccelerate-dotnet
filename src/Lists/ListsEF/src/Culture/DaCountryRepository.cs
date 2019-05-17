// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.List.Culture;

namespace Ejyle.DevAccelerate.List.EF.Culture
{
    public class DaCountryRepository : DaCountryRepository<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaListsDbContext>
    {
        public DaCountryRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaCountryRepository<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        : DaEntityRepositoryBase<TKey, TCountry, TDbContext>, IDaCountryRepository<TKey, TNullableKey, TCountry, TCountryRegion>
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TDateFormat : DaDateFormat<TKey, TNullableKey>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>, new()
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
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
            return DbContext.Countries.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id)
        {
            return DbContext.CountryRegions.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TCountry> FindByNameAsync(string name)
        {
            return DbContext.Countries.Where(m => m.Name == name).SingleOrDefaultAsync();
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
            return DbContext.Countries.Where(m => m.TwoLetterCode == twoLetterCode).SingleOrDefaultAsync();
        }

        public Task<TCountry> FindByThreeLetterCodeAsync(string threeLetterCode)
        {
            return DbContext.Countries.Where(m => m.ThreeLetterCode == threeLetterCode).SingleOrDefaultAsync();
        }
    }
}
