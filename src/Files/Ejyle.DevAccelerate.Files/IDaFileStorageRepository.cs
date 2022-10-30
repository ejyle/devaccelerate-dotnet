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

namespace Ejyle.DevAccelerate.Files
{
    public interface IDaFileStorageRepository<TKey, TFileStorage> : IDaEntityRepository<TKey, TFileStorage>
        where TKey : IEquatable<TKey>
        where TFileStorage : IDaFileStorage<TKey>
    {
        Task CreateAsync(TFileStorage fileStorage);
        Task<TFileStorage> FindByIdAsync(TKey id);
        Task<TFileStorage> FindByNameAsync(string name);
        Task UpdateAsync(TFileStorage fileStorage);
        Task DeleteAsync(TFileStorage fileStorage);
    }
}
