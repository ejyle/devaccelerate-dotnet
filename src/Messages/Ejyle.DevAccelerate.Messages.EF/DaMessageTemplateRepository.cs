// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Messages;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Messages.EF
{
    public class DaMessageTemplateRepository : DaMessageTemplateRepository<int, DaMessageTemplate, DbContext>
    {
        public DaMessageTemplateRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaMessageTemplateRepository<TKey, TMessageTemplate, TDbContext>
        : DaEntityRepositoryBase<TKey, TMessageTemplate, TDbContext>, IDaMessageTemplateRepository<TKey, TMessageTemplate>
        where TKey : IEquatable<TKey>
        where TMessageTemplate : DaMessageTemplate<TKey>
        where TDbContext : DbContext
    {
        public DaMessageTemplateRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TMessageTemplate> MessageTemplates { get { return DbContext.Set<TMessageTemplate>(); } }

        public Task CreateAsync(TMessageTemplate messageTemplate)
        {
            MessageTemplates.Add(messageTemplate);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TMessageTemplate messageTemplate)
        {
            MessageTemplates.Remove(messageTemplate);
            return SaveChangesAsync();
        }

        public Task<TMessageTemplate> FindByIdAsync(TKey id)
        {
            return MessageTemplates.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TMessageTemplate messageTemplate)
        {
            DbContext.Entry<TMessageTemplate>(messageTemplate).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
