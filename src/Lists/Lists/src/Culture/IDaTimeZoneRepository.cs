// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.List.Culture
{
    public interface IDaTimeZoneRepository<TKey, TNullableKey, TTimeZone> : IDaEntityRepository<TKey, TTimeZone>
        where TKey : IEquatable<TKey>
        where TTimeZone : IDaTimeZone<TKey, TNullableKey>
    {
        Task CreateAsync(TTimeZone timeZone);
        Task UpdateAsync(TTimeZone timeZone);
        Task DeleteAsync(TTimeZone timeZone);

        Task<TTimeZone> FindByIdAsync(TKey id);
        Task<List<TTimeZone>> FindAllAsync();
        Task<List<TTimeZone>> FindByCountryIdAsync(TKey countryId);
    }
}