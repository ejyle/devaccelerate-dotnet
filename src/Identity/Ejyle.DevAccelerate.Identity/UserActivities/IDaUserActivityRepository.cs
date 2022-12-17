// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.Identity.UserActivities
{
    public interface IDaUserActivityRepository<TKey, TUserActivity> : IDaEntityRepository<TKey, TUserActivity>
        where TKey : IEquatable<TKey>
        where TUserActivity : IDaUserActivity<TKey>
    {
        Task CreateAsync(TUserActivity userActivity);
        Task<TUserActivity> FindByIdAsync(TKey id);
        Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAsync(DaDataPaginationCriteria paginationCriteria, TKey userId);
        Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAndUserActivityTypeAsync(DaDataPaginationCriteria paginationCriteria, TKey userId, DaUserActivityType userActivityType);
    }
}
