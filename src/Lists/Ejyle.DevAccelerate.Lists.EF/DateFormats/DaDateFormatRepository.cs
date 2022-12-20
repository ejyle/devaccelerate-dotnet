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
using Ejyle.DevAccelerate.Lists.Countries;
using Ejyle.DevAccelerate.Lists.Currencies;
using Ejyle.DevAccelerate.Lists.Custom;
using Ejyle.DevAccelerate.Lists.DateFormats;
using Ejyle.DevAccelerate.Lists.SystemLanguages;
using Ejyle.DevAccelerate.Lists.TimeZones;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Lists.EF.DateFormats
{
    public class DaDateFormatRepository : DaDateFormatRepository<string, DaDateFormat, DaTimeZone, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaCustomList, DaCustomListItem, DaListsDbContext>
    {
        public DaDateFormatRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaDateFormatRepository<TKey, TDateFormat, TTimeZone, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TDateFormat, TDbContext>, IDaDateFormatRepository<TKey, TDateFormat>
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
        public DaDateFormatRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TDateFormat>> FindAllAsync()
        {
            return DbContext.DateFormats
                .Include(m => m.CountryDateFormats)
                .ThenInclude(m => m.Country)
                .ToListAsync();
        }

        public Task<TDateFormat> FindByIdAsync(TKey id)
        {
            return DbContext.DateFormats
                .Where(m => m.Id.Equals(id))
                .Include(m => m.CountryDateFormats)
                .ThenInclude(m => m.Country)
                .SingleOrDefaultAsync();
        }

        public Task<TDateFormat> FindByDateFormatExpressionAsync(string expr)
        {
            return DbContext.DateFormats
                .Where(m => m.DateFormatExpression == expr)
                .Include(m => m.CountryDateFormats)
                .ThenInclude(m => m.Country)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TDateFormat dateFormat)
        {
            DbContext.DateFormats.Add(dateFormat);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TDateFormat dateFormat)
        {
            DbContext.Entry(dateFormat).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TDateFormat dateFormat)
        {
            DbContext.DateFormats.Remove(dateFormat);
            return DbContext.SaveChangesAsync();
        }

        public Task<TDateFormat> FindFirstAsync()
        {
            return DbContext.DateFormats
                .Include(m => m.CountryDateFormats)
                .ThenInclude(m => m.Country)
                .FirstOrDefaultAsync();
        }
    }
}