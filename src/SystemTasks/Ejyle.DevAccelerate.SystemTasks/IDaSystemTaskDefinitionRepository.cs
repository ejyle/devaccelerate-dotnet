// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SystemTasks
{
    public interface IDaSystemTaskDefinitionRepository<TKey, TSystemTaskDefinition> : IDaEntityRepository<TKey, TSystemTaskDefinition>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : IDaSystemTaskDefinition<TKey>
    {
        Task CreateAsync(TSystemTaskDefinition systemTask);
        Task CreateAsync(List<TSystemTaskDefinition> systemTasks);

        Task UpdateAsync(TSystemTaskDefinition systemTask);
        Task UpdateAsync(List<TSystemTaskDefinition> systemTasks);

        Task DeleteAsync(TSystemTaskDefinition systemTask);
        Task ClearAsync(int olderThanInDays, List<DaSystemTaskStatus> statusCriteria);

        Task<TSystemTaskDefinition> FindByIdAsync(TKey id);
        Task<List<TSystemTaskDefinition>> FindInProgressAsync(int top);
        Task<List<TSystemTaskDefinition>> FindNewAsync(int top);
        Task<DaPaginatedEntityList<TKey, TSystemTaskDefinition>> FindAllAsync(DaDataPaginationCriteria paginationCriteria);
    }
}
