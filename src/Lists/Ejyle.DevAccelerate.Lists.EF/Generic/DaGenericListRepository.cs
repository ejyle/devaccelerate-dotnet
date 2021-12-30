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

namespace Ejyle.DevAccelerate.Lists.EF.Generic
{
    public class DaGenericListRepository : DaGenericListRepository<int, int?, DaGenericList, DaGenericListItem, DaCountry, DaCountryRegion, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaListsDbContext>
    {
        public DaGenericListRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaGenericListRepository<TKey, TNullableKey, TGenericList, TGenericListItem, TCountry, TCountryRegion, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TDbContext>
        : DaEntityRepositoryBase<TKey, TCountry, TDbContext>, IDaGenericListRepository<TKey, TGenericList>
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
        public DaGenericListRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task<List<TGenericList>> FindAllAsync()
        {
            return DbContext.GenericLists
                .Include(m => m.ListItems)
                .ToListAsync();
        }

        public Task<TGenericList> FindByIdAsync(TKey id)
        {
            return DbContext.GenericLists
                .Where(m => m.Id.Equals(id))
                .Include(m => m.ListItems)
                .SingleOrDefaultAsync();
        }

        public Task<TGenericList> FindByNameAsync(string name)
        {
            return DbContext.GenericLists
                .Where(m => m.Name == name)
                .Include(m => m.ListItems)
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TGenericList list)
        {
            DbContext.GenericLists.Add(list);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TGenericList list)
        {
            DbContext.Entry(list).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TGenericList list)
        {
            DbContext.GenericLists.Remove(list);
            return DbContext.SaveChangesAsync();
        }
    }
}
