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
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.Currencies
{
    public interface IDaCurrencyRepository<TKey, TCurrency> : IDaEntityRepository<TKey, TCurrency>
        where TKey : IEquatable<TKey>
        where TCurrency : IDaCurrency<TKey>
    {
        Task CreateAsync(TCurrency currency);
        Task UpdateAsync(TCurrency currency);
        Task DeleteAsync(TCurrency currency);

        Task<TCurrency> FindByIdAsync(TKey id);
        Task<List<TCurrency>> FindAllAsync();
        Task<DaPaginatedEntityList<TKey, TCurrency>> FindAllAsync(DaDataPaginationCriteria paginationCriteria);
        Task<TCurrency> FindByNameAsync(string name);
        Task<TCurrency> FindFirstAsync();
        Task<TCurrency> FindByAlphabeticCodeAsync(string alphabeticCode);
        Task<TCurrency> FindByNameOrCodeAsync(string nameOrCode);
    }
}
