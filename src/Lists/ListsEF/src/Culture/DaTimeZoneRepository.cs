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
    public class DaTimeZoneRepository : DaTimeZoneRepository<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaListsDbContext>
    {
        public DaTimeZoneRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaTimeZoneRepository<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        : DaEntityRepositoryBase<TKey, TTimeZone, TDbContext>, IDaTimeZoneRepository<TKey, TNullableKey, TTimeZone>
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TDateFormat : DaDateFormat<TKey, TNullableKey>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>, new()
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
    {
        public DaTimeZoneRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TTimeZone>> FindAllAsync()
        {
            return DbContext.TimeZones.ToListAsync();
        }

        public Task<TTimeZone> FindByIdAsync(TKey id)
        {
            return DbContext.TimeZones.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<List<TTimeZone>> FindByCountryIdAsync(TKey countryId)
        {
            return DbContext.TimeZones.Where(m => m.Countries.Any(x => x.Id.Equals(countryId))).ToListAsync();
        }

        public Task CreateAsync(TTimeZone timeZone)
        {
            DbContext.TimeZones.Add(timeZone);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TTimeZone timeZone)
        {
            DbContext.Entry(timeZone).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TTimeZone timeZone)
        {
            DbContext.TimeZones.Remove(timeZone);
            return DbContext.SaveChangesAsync();
        }

        public Task<TTimeZone> FindByNameAsync(string name)
        {
            return DbContext.TimeZones.Where(m => m.Name == name).SingleOrDefaultAsync();
        }
    }
}