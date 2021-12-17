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

        public Task CreateAsync(TUserSetting setting)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TUserSetting setting)
        {
            throw new NotImplementedException();
        }

        public Task<TUserSetting> FindByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TUserSetting> FindByUserIdAndNameAsync(TKey userId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<TUserSetting>> FindByUserIdAsync(TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TUserSetting setting)
        {
            throw new NotImplementedException();
        }
    }
}
