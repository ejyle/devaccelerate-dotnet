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

namespace Ejyle.DevAccelerate.Lists.SystemLanguages
{
    public interface IDaSystemLanguageRepository<TKey, TSystemLanguage> : IDaEntityRepository<TKey, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TSystemLanguage : IDaSystemLanguage<TKey>
    {
        Task CreateAsync(TSystemLanguage systemLanguage);
        Task CreateAsync(IEnumerable<TSystemLanguage> systemLanguages);
        Task UpdateAsync(TSystemLanguage systemLanguage);
        Task DeleteAsync(TSystemLanguage systemLanguage);

        Task<TSystemLanguage> FindByIdAsync(TKey id);
        Task<List<TSystemLanguage>> FindAllAsync();
        Task<DaPaginatedEntityList<TKey, TSystemLanguage>> FindAllAsync(DaDataPaginationCriteria paginationCriteria);
        Task<List<TSystemLanguage>> FindByCountryIdAsync(TKey countryId);
        Task<TSystemLanguage> FindByNameAsync(string name);
        Task<TSystemLanguage> FindFirstAsync();
    }
}