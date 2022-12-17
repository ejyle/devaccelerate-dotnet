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
    public class DaUserActivityManager<TUserActivity>
        : DaUserActivityManager<string, TUserActivity>
        where TUserActivity : IDaUserActivity<string>
    {
        public DaUserActivityManager(IDaUserActivityRepository<string, TUserActivity> repository)
            : base(repository)
        {
        }
    }

    public class DaUserActivityManager<TKey, TUserActivity>
    : DaEntityManagerBase<TKey, TUserActivity>
        where TKey : IEquatable<TKey>
        where TUserActivity : IDaUserActivity<TKey>
    {
        public DaUserActivityManager(IDaUserActivityRepository<TKey, TUserActivity> repository)
            : base(repository)
        { }

        private IDaUserActivityRepository<TKey, TUserActivity> GetRepository()
        {
            return GetRepository<IDaUserActivityRepository<TKey, TUserActivity>>();
        }

        public Task CreateAsync(TUserActivity userActivity)
        {
            return GetRepository().CreateAsync(userActivity);
        }

        public void Create(TUserActivity userActivity)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(userActivity));
        }

        public TUserActivity FindById(TKey userActivityId)
        {
            return DaAsyncHelper.RunSync<TUserActivity>(() => FindByIdAsync(userActivityId));
        }

        public Task<TUserActivity> FindByIdAsync(TKey userActivityId)
        {
            return GetRepository().FindByIdAsync(userActivityId);
        }

        public DaPaginatedEntityList<TKey, TUserActivity> FindByUserId(DaDataPaginationCriteria paginationCriteria, TKey userId)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TUserActivity>>(() => FindByUserIdAsync(paginationCriteria, userId));
        }

        public Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAsync(DaDataPaginationCriteria paginationCriteria, TKey userId)
        {
            return GetRepository().FindByUserIdAsync(paginationCriteria, userId);
        }

        public DaPaginatedEntityList<TKey, TUserActivity> FindByUserIdAndUserActivityType(DaDataPaginationCriteria paginationCriteria, TKey userId, DaUserActivityType userActivityType)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TUserActivity>>(() => FindByUserIdAndUserActivityTypeAsync(paginationCriteria, userId, userActivityType));
        }

        public Task<DaPaginatedEntityList<TKey, TUserActivity>> FindByUserIdAndUserActivityTypeAsync(DaDataPaginationCriteria paginationCriteria, TKey userId, DaUserActivityType userActivityType)
        {
            return GetRepository().FindByUserIdAndUserActivityTypeAsync(paginationCriteria, userId, userActivityType);
        }
    }
}
