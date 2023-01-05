// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.UserProfiles
{
    public interface IDaUserProfileRepository<TKey, TUserProfile> : IDaEntityRepository<TKey, TUserProfile>
        where TKey : IEquatable<TKey>
        where TUserProfile : IDaUserProfile<TKey>
    {
        Task CreateAsync(TUserProfile userProfile);
        Task<TUserProfile> FindByIdAsync(TKey id);
        IQueryable<TUserProfile> UserProfiles { get; }
        Task<List<TUserProfile>> FindByUserIdAsync(TKey userId);
        Task UpdateAsync(TUserProfile userProfile);
        Task DeleteAsync(TUserProfile userProfile);
    }
}
