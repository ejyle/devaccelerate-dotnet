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
    public class DaCurrencyRepository : DaCurrencyRepository<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaListsDbContext>
    {
        public DaCurrencyRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaCurrencyRepository<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        : DaEntityRepositoryBase<TKey, TCurrency, TDbContext>, IDaCurrencyRepository<TKey, TCurrency>
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TDateFormat : DaDateFormat<TKey, TNullableKey>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>, new()
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
    {
        public DaCurrencyRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task CreateAsync(TCurrency currency)
        {
            DbContext.Currencies.Add(currency);
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TCurrency currency)
        {
            DbContext.Currencies.Remove(currency);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<TCurrency>> FindAllAsync()
        {
            return DbContext.Currencies.ToListAsync();
        }

        public Task<TCurrency> FindByIdAsync(TKey id)
        {
            return DbContext.Currencies.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TCurrency> FindByNameAsync(string name)
        {
            return DbContext.Currencies.Where(m => m.Name == name).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TCurrency currency)
        {
            DbContext.Entry(currency).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }
    }
}
