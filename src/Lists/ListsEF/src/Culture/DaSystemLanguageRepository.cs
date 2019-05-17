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
    public class DaSystemLanguageRepository : DaSystemLanguageRepository<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaListsDbContext>
    {
        public DaSystemLanguageRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaSystemLanguageRepository<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        : DaEntityRepositoryBase<TKey, TSystemLanguage, TDbContext>, IDaSystemLanguageRepository<TKey, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TDateFormat : DaDateFormat<TKey, TNullableKey>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>, new()
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
    {
        public DaSystemLanguageRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TSystemLanguage>> FindAllAsync()
        {
            return DbContext.SystemLanguages.ToListAsync();
        }

        public Task<TSystemLanguage> FindByIdAsync(TKey id)
        {
            return DbContext.SystemLanguages.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<List<TSystemLanguage>> FindByCountryIdAsync(TKey countryId)
        {
            return DbContext.SystemLanguages.Where(m => m.Countries.Any(x => x.Id.Equals(countryId))).ToListAsync();
        }

        public Task CreateAsync(TSystemLanguage systemLanguage)
        {
            DbContext.SystemLanguages.Add(systemLanguage);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TSystemLanguage systemLanguage)
        {
            DbContext.Entry(systemLanguage).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TSystemLanguage systemLanguage)
        {
            DbContext.SystemLanguages.Remove(systemLanguage);
            return DbContext.SaveChangesAsync();
        }
    }
}