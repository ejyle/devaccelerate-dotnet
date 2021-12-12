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

namespace Ejyle.DevAccelerate.Lists.Generic
{
    public interface IDaGenericListRepository<TKey, TGenericList> : IDaEntityRepository<TKey, TGenericList>
        where TKey : IEquatable<TKey>
        where TGenericList : IDaGenericList<TKey>
    {
        Task CreateAsync(TGenericList currency);
        Task UpdateAsync(TGenericList currency);
        Task DeleteAsync(TGenericList currency);

        Task<TGenericList> FindByIdAsync(TKey id);
        Task<List<TGenericList>> FindAllAsync();
        Task<TGenericList> FindByNameAsync(string name);
    }
}
