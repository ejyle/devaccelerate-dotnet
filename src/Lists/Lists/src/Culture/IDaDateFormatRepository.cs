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
    public interface IDaDateFormatRepository<TKey, TDateFormat> : IDaEntityRepository<TKey, TDateFormat>
        where TKey : IEquatable<TKey>
        where TDateFormat : IDaDateFormat<TKey>
    {
        Task CreateAsync(TDateFormat dateFormat);
        Task UpdateAsync(TDateFormat dateFormat);
        Task DeleteAsync(TDateFormat dateFormat);

        Task<TDateFormat> FindByIdAsync(TKey id);
        Task<List<TDateFormat>> FindAllAsync();
        Task<TDateFormat> FindByDateFormatExpressionAsync(string expr);
    }
}