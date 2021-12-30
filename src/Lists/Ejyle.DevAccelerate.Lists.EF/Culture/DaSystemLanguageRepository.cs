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
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Lists.Culture;
using Ejyle.DevAccelerate.Lists.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Lists.EF.Culture
{
    public class DaSystemLanguageRepository : DaSystemLanguageRepository<int, int?, DaCountrySystemLanguage, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaGenericList, DaGenericListItem, DaListsDbContext>
    {
        public DaSystemLanguageRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaSystemLanguageRepository<TKey, TNullableKey, TCountrySystemLanguage, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TGenericList, TGenericListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TSystemLanguage, TDbContext>, IDaSystemLanguageRepository<TKey, TSystemLanguage>
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
            return DbContext.SystemLanguages.Where(m => m.CountrySystemLanguages.Any(x => x.CountryId.Equals(countryId))).ToListAsync();
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

        public Task<TSystemLanguage> FindByNameAsync(string name)
        {
            return DbContext.SystemLanguages.Where(m => m.Name == name).SingleOrDefaultAsync();
        }

        public Task<TSystemLanguage> FindFirstAsync()
        {
            return DbContext.SystemLanguages.FirstOrDefaultAsync();
        }
    }
}