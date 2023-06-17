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
using Ejyle.DevAccelerate.Notifications.EventDefinitions;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;

/* Unmerged change from project 'Ejyle.DevAccelerate.Notifications.EF (netcoreapp3.1)'
Before:
using System.Xml.Linq;
After:
using System.Xml.Linq;
using Ejyle;
using Ejyle.DevAccelerate;
using Ejyle.DevAccelerate.Notifications;
using Ejyle.DevAccelerate.Notifications.EF;
using Ejyle.DevAccelerate.Notifications.EF.EventDefinitions;
*/
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.EF.EventDefinitions
{
    public class DaNotificationEventDefinitionRepository : DaNotificationEventDefinitionRepository<string, DaNotificationEventDefinition, DaNotificationEventDefinitionChannel, DbContext>
    {
        public DaNotificationEventDefinitionRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaNotificationEventDefinitionRepository<TKey, TNotificationEventDefinition, TNotificationEventDefinitionChannel, TDbContext>
        : DaEntityRepositoryBase<TKey, TNotificationEventDefinition, TDbContext>, IDaNotificationEventDefinitionRepository<TKey, TNotificationEventDefinition>
        where TKey : IEquatable<TKey>
        where TNotificationEventDefinition : DaNotificationEventDefinition<TKey, TNotificationEventDefinitionChannel>
        where TNotificationEventDefinitionChannel : DaNotificationEventDefinitionChannel<TKey, TNotificationEventDefinition>
        where TDbContext : DbContext
    {
        public DaNotificationEventDefinitionRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TNotificationEventDefinition> NotificationEventDefinitions { get { return DbContext.Set<TNotificationEventDefinition>(); } }

        public Task CreateAsync(TNotificationEventDefinition notificationEventDefinition)
        {
            NotificationEventDefinitions.Add(notificationEventDefinition);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TNotificationEventDefinition notificationEventDefinition)
        {
            NotificationEventDefinitions.Remove(notificationEventDefinition);
            return SaveChangesAsync();
        }

        public Task<List<TNotificationEventDefinition>> FindAllAsync()
        {
            return NotificationEventDefinitions.ToListAsync();
        }

        public Task<TNotificationEventDefinition> FindByIdAsync(TKey id)
        {
            return NotificationEventDefinitions.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TNotificationEventDefinition> FindByNameAsync(string name)
        {
            return NotificationEventDefinitions.Where(m => m.Name == name).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TNotificationEventDefinition notificationEventDefinition)
        {
            DbContext.Entry(notificationEventDefinition).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
