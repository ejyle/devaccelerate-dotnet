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
    public class DaDateFormatRepository : DaDateFormatRepository<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaListsDbContext>
    {
        public DaDateFormatRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaDateFormatRepository<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        : DaEntityRepositoryBase<TKey, TDateFormat, TDbContext>, IDaDateFormatRepository<TKey, TDateFormat>
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TDateFormat : DaDateFormat<TKey, TNullableKey>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>, new()
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
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
    }
}