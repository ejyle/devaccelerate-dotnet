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
    public interface IDaFileRepository<TKey, TNullableKey, TFile> : IDaEntityRepository<TKey, TFile>
        where TKey : IEquatable<TKey>
        where TFile : IDaFile<TKey, TNullableKey>
    {
        Task CreateAsync(TFile file);
        Task<TFile> FindByIdAsync(TKey id);
        Task RenameAsync(TKey id, string newName);
        Task DeleteAsync(TFile file);
        Task<DaPaginatedEntityList<TKey, TFile>> FindByFileCollectionIdAsync(TKey fileCollectionId, DaDataPaginationCriteria paginationCriteria);
        Task<DaPaginatedEntityList<TKey, TFile>> FindByObjectInstanceIdAsync(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria);
    }
}
