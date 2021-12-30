// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EF;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Identity.UserSettings;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ejyle.DevAccelerate.Identity.EF.UserSettings
{
    public class DaUserSettingRepository : DaUserSettingRepository<DaUserSetting, DbContext>
    {
        public DaUserSettingRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaUserSettingRepository<TUserSetting, TDbContext>
        : DaUserSettingRepository<int, TUserSetting, TDbContext>
        where TUserSetting : DaUserSetting<int>
        where TDbContext : DbContext
    {
        public DaUserSettingRepository(TDbContext context)
            : base(context)
        { }
    }

    public class DaUserSettingRepository<TKey, TUserSetting, TDbContext>
         : DaEntityRepositoryBase<TKey, TUserSetting, TDbContext>, IDaUserSettingRepository<TKey, TUserSetting>
         where TKey : IEquatable<TKey>
         where TUserSetting : DaUserSetting<TKey>
         where TDbContext : DbContext
    {
        public DaUserSettingRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TUserSetting> UserSettings { get { return DbContext.Set<TUserSetting>(); } }


        public Task CreateAsync(TUserSetting setting)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(setting, nameof(setting));
            UserSettings.Add(setting);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TUserSetting setting)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(setting, nameof(setting));

            UserSettings.Remove(setting);
            return SaveChangesAsync();
        }

        public Task<TUserSetting> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return UserSettings.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TUserSetting> FindByUserIdAndNameAsync(TKey userId, string name)
        {
            ThrowIfDisposed();
            return UserSettings.Where(m => m.UserId.Equals(userId) && m.Name == name).SingleOrDefaultAsync();
        }

        public Task<List<TUserSetting>> FindByUserIdAsync(TKey userId)
        {
            ThrowIfDisposed();
            return UserSettings.Where(m => m.UserId.Equals(userId)).ToListAsync();
        }

        public Task UpdateAsync(TUserSetting setting)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(setting, nameof(setting));

            DbContext.Entry<TUserSetting>(setting).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
