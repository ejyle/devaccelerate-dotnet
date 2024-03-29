﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Tasks
{
    public interface IDaTaskRepository<TKey, TTask> : IDaEntityRepository<TKey, TTask>
        where TKey : IEquatable<TKey>
        where TTask : IDaTask<TKey>
    {
        Task CreateAsync(TTask task);
        Task<TTask> FindByIdAsync(TKey id);
        Task UpdateAsync(TTask task);
        Task DeleteAsync(TTask task);
        IQueryable<TTask> Tasks { get; }
        Task<DaPaginatedEntityList<TKey, TTask>> FindByObjectInstanceIdAsync(string objectInstanceId, DaDataPaginationCriteria paginationCriteria);
        Task<DaPaginatedEntityList<TKey, TTask>> FindByAssignedToAsync(string assignedTo, DaDataPaginationCriteria paginationCriteria);
        Task<DaPaginatedEntityList<TKey, TTask>> FindByTenantIdAsync(string tenantId, DaDataPaginationCriteria paginationCriteria);
    }
}
