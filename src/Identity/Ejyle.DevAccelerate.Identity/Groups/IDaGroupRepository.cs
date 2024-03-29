﻿// ----------------------------------------------------------------------------------------------------------------------
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

namespace Ejyle.DevAccelerate.Identity.Groups
{
    public interface IDaGroupRepository<TKey, TGroup> : IDaEntityRepository<TKey, TGroup>
        where TKey : IEquatable<TKey>
        where TGroup : IDaGroup<TKey>
    {
        Task CreateAsync(TGroup group);
        Task<TGroup> FindByIdAsync(TKey id);
        Task UpdateAsync(TGroup group);
        Task DeleteAsync(TGroup group);
        Task AddUserAsync(TKey id, TKey userId);
        Task RemoveUserAsync(TKey id, TKey userId);
        Task<List<TKey>> FindUserRolesByUserIdAsync(TKey tenantId, TKey userId);
        Task<bool> IsUserInRoleAsync(TKey tenantId, TKey roleId, TKey userId);
    }
}
