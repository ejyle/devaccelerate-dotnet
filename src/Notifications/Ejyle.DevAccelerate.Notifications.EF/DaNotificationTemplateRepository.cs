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
using Ejyle.DevAccelerate.Notifications.Templates;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationTemplateRepository : DaNotificationTemplateRepository<string, DaNotificationTemplate, DaNotificationChannelTemplate, DbContext>
    {
        public DaNotificationTemplateRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaNotificationTemplateRepository<TKey, TNotificationTemplate, TNotificationChannelTemplate, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationTemplate, TDbContext>, IDaNotificationTemplateRepository<TKey, TNotificationTemplate>
        where TKey : IEquatable<TKey>
        where TNotificationTemplate : DaNotificationTemplate<TKey, TNotificationChannelTemplate>
        where TNotificationChannelTemplate: DaNotificationChannelTemplate<TKey, TNotificationTemplate>
        where TDbContext : DbContext
    {
        public DaNotificationTemplateRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TNotificationTemplate> NotificationTemplates { get { return DbContext.Set<TNotificationTemplate>(); } }

        public Task CreateAsync(TNotificationTemplate notificationTemplate)
        {
            NotificationTemplates.Add(notificationTemplate);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TNotificationTemplate notificationTemplate)
        {
            NotificationTemplates.Remove(notificationTemplate);
            return SaveChangesAsync();
        }

        public Task<List<TNotificationTemplate>> FindAllAsync()
        {
            return NotificationTemplates.ToListAsync();
        }

        public Task<TNotificationTemplate> FindByIdAsync(TKey id)
        {
            return NotificationTemplates.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TNotificationTemplate> FindByKeyAsync(string key)
        {
            return NotificationTemplates.Where(m => m.Key == key).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TNotificationTemplate notificationTemplate)
        {
            DbContext.Entry<TNotificationTemplate>(notificationTemplate).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
