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
using Ejyle.DevAccelerate.Lists.Links;
using Ejyle.DevAccelerate.Lists.SystemLanguages;
using Ejyle.DevAccelerate.Lists.TimeZones;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Lists.EF.Links
{
    public class DaLinkRepository : DaLinkRepository<string, DaLink, DbContext>
    {
        public DaLinkRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaLinkRepository<TKey, TLink, TDbContext>
        : DaEntityRepositoryBase<TKey, TLink, TDbContext>, IDaLinkRepository<TKey, TLink>
        where TKey : IEquatable<TKey>
        where TLink : DaLink<TKey>
        where TDbContext : DbContext
    {
        public DaLinkRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TLink> LinksSet { get { return DbContext.Set<TLink>(); } }

        public Task<List<TLink>> FindAsync(string userId, string category)
        {
            return LinksSet
                .Where(m => m.UserId == userId && m.Category == category)
                .ToListAsync();
        }

        public Task<TLink> FindByIdAsync(TKey id)
        {
            return LinksSet
                .Where(m => m.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public Task CreateAsync(TLink link)
        {
            LinksSet.Add(link);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TLink link)
        {
            DbContext.Update(link);
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TLink link)
        {
            LinksSet.Remove(link);
            return DbContext.SaveChangesAsync();
        }
    }
}