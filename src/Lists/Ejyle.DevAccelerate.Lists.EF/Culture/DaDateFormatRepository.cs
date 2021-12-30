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
    public class DaDateFormatRepository : DaDateFormatRepository<int, int?, DaDateFormat, DaTimeZone, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaGenericList, DaGenericListItem, DaListsDbContext>
    {
        public DaDateFormatRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaDateFormatRepository<TKey, TNullableKey, TDateFormat, TTimeZone, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TGenericList, TGenericListItem, TDbContext>
        : DaEntityRepositoryBase<TKey, TDateFormat, TDbContext>, IDaDateFormatRepository<TKey, TDateFormat>
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
        public DaDateFormatRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TDateFormat>> FindAllAsync()
        {
            return DbContext.DateFormats.ToListAsync();
        }

        public Task<TDateFormat> FindByIdAsync(TKey id)
        {
            return DbContext.DateFormats.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TDateFormat> FindByDateFormatExpressionAsync(string expr)
        {
            return DbContext.DateFormats.Where(m => m.DateFormatExpression == expr).SingleOrDefaultAsync();
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
            return DbContext.DateFormats.FirstOrDefaultAsync();
        }
    }
}