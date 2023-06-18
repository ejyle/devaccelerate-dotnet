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

namespace Ejyle.DevAccelerate.Lists.Links
{
    public interface IDaLinkRepository<TKey, TLink> : IDaEntityRepository<TKey, TLink>
        where TKey : IEquatable<TKey>
        where TLink : IDaLink<TKey>
    {
        Task CreateAsync(TLink dateFormat);
        Task UpdateAsync(TLink dateFormat);
        Task DeleteAsync(TLink dateFormat);

        Task<TLink> FindByIdAsync(TKey id);
        Task<List<TLink>> FindAsync(string userId, string category);
    }
}