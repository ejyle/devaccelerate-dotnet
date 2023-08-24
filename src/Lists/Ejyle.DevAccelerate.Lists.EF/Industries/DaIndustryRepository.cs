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
using Ejyle.DevAccelerate.Lists.Countries;
using Ejyle.DevAccelerate.Lists.Currencies;
using Ejyle.DevAccelerate.Lists.Custom;
using Ejyle.DevAccelerate.Lists.DateFormats;
using Ejyle.DevAccelerate.Lists.SystemLanguages;
using Ejyle.DevAccelerate.Lists.Industries;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Lists.TimeZones;

namespace Ejyle.DevAccelerate.Lists.EF.Industries
{
    public class DaIndustryRepository : DaIndustryRepository<string, DaIndustry, DbContext>
    {
        public DaIndustryRepository(DaListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaIndustryRepository<TKey, TIndustry, TDbContext>
        : DaEntityRepositoryBase<TKey, TIndustry, TDbContext>, IDaIndustryRepository<TKey, TIndustry>
       where TKey : IEquatable<TKey>
        where TIndustry : DaIndustry<TKey>
        where TDbContext : DbContext
    {
        public DaIndustryRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TIndustry> IndustriesSet { get { return DbContext.Set<TIndustry>(); } }


        public Task<List<TIndustry>> FindAllAsync()
        {
            return IndustriesSet.ToListAsync();
        }

        public Task<TIndustry> FindByIdAsync(TKey id)
        {
            return IndustriesSet
                .Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TIndustry industry)
        {
            IndustriesSet.Add(industry);
            return DbContext.SaveChangesAsync();
        }

        public Task CreateAsync(IEnumerable<TIndustry> industries)
        {
            IndustriesSet.AddRange(industries);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TIndustry industry)
        {
            DbContext.Entry(industry).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TIndustry industry)
        {
            IndustriesSet.Remove(industry);
            return DbContext.SaveChangesAsync();
        }

        public Task<TIndustry> FindByNameAsync(string name)
        {
            return IndustriesSet
                .Where(m => m.Name == name)
                .SingleOrDefaultAsync();
        }
    }
}