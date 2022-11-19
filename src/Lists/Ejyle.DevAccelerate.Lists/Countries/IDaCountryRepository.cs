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

namespace Ejyle.DevAccelerate.Lists.Countries
{
    public interface IDaCountryRepository<TKey, TNullableKey, TCountry, TCountryRegion> : IDaEntityRepository<TKey, TCountry>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
        where TCountryRegion : IDaCountryRegion<TKey, TNullableKey>
    {
        Task CreateAsync(TCountry country);
        Task UpdateAsync(TCountry country);
        Task DeleteAsync(TCountry country);

        Task<TCountry> FindByIdAsync(TKey id);
        Task<TCountry> FindByNameAsync(string name);
        Task<TCountry> FindByNameOrCodeAsync(string nameOrCode);
        Task<TCountry> FindByTwoLetterCodeAsync(string twoLetterCode);
        Task<TCountry> FindByThreeLetterCodeAsync(string threeLetterCode);
        Task<List<TCountry>> FindAllAsync();
        Task<DaPaginatedEntityList<TKey, TCountry>> FindAllAsync(DaDataPaginationCriteria paginationCriteria);
        Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id);

        Task<TCountry> FindFirstAsync();
    }
}
