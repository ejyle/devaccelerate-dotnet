// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.Identity.UserSettings
{
    public class DaUserSettingManager<TUserSetting> : DaUserSettingManager<int, TUserSetting>
        where TUserSetting : IDaUserSetting<int>
    {
        public DaUserSettingManager(IDaUserSettingRepository<int, TUserSetting> repository)
            : base(repository)
        { }
    }

    public class DaUserSettingManager<TKey, TUserSetting>
        : DaEntityManagerBase<TKey, TUserSetting>
        where TKey : IEquatable<TKey>
        where TUserSetting : IDaUserSetting<TKey>
    {
        public DaUserSettingManager(IDaUserSettingRepository<TKey, TUserSetting> repository)
            : base(repository)
        { }

        private IDaUserSettingRepository<TKey, TUserSetting> GetRepository()
        {
            return GetRepository<IDaUserSettingRepository<TKey, TUserSetting>>();
        }

        public Task CreateAsync(TUserSetting userSetting)
        {
            return GetRepository().CreateAsync(userSetting);
        }

        public void Create(TUserSetting userSetting)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(userSetting));
        }

        public Task UpdateAsync(TUserSetting userSetting)
        {
            return GetRepository().UpdateAsync(userSetting);
        }

        public void Update(TUserSetting userSetting)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(userSetting));
        }

        public Task DeleteAsync(TUserSetting userSetting)
        {
            return GetRepository().DeleteAsync(userSetting);
        }

        public void Delete(TUserSetting userSetting)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(userSetting));
        }

        public TUserSetting FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public Task<TUserSetting> FindByIdAsync(TKey id)
        {
            return GetRepository().FindByIdAsync(id);
        }

        public Task<TUserSetting> FindByUserIdAndNameAsync(TKey userId, string name)
        {
            return GetRepository().FindByUserIdAndNameAsync(userId, name);
        }

        public TUserSetting FindByUserIdAndName(TKey userId, string name)
        {
            return DaAsyncHelper.RunSync<TUserSetting>(() => FindByUserIdAndNameAsync(userId, name));
        }

        public Task<List<TUserSetting>> FindByUserIdAsync(TKey userId)
        {
            return GetRepository().FindByUserIdAsync(userId);
        }

        public List<TUserSetting> FindByUserId(TKey userId)
        {
            return DaAsyncHelper.RunSync<List<TUserSetting>>(() => FindByUserIdAsync(userId));
        }
    }
}
