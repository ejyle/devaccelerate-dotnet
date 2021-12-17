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

namespace Ejyle.DevAccelerate.Identity.UserSettings
{
    public interface IDaUserSettingRepository<TKey, TUserSetting> : IDaEntityRepository<TKey, TUserSetting>
        where TKey : IEquatable<TKey>
        where TUserSetting : IDaUserSetting<TKey>
    {
        Task CreateAsync(TUserSetting setting);
        Task UpdateAsync(TUserSetting setting);
        Task DeleteAsync(TUserSetting setting);
        Task<TUserSetting> FindByIdAsync(TKey id);
        Task<List<TUserSetting>> FindByUserIdAsync(TKey userId);
        Task<TUserSetting> FindByUserIdAndNameAsync(TKey userId, string name);
    }
}
