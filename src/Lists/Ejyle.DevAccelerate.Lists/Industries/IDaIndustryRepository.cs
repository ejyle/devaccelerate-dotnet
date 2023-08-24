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

namespace Ejyle.DevAccelerate.Lists.Industries
{
    public interface IDaIndustryRepository<TKey, TIndustry> : IDaEntityRepository<TKey, TIndustry>
        where TKey : IEquatable<TKey>
        where TIndustry : IDaIndustry<TKey>
    {
        Task CreateAsync(TIndustry industry);
        Task CreateAsync(IEnumerable<TIndustry> industries);
        Task UpdateAsync(TIndustry industry);
        Task DeleteAsync(TIndustry industry);

        Task<TIndustry> FindByIdAsync(TKey id);
        Task<List<TIndustry>> FindAllAsync();
        Task<TIndustry> FindByNameAsync(string name);
    }
}