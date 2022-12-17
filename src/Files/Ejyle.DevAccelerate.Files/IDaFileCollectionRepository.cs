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
    public interface IDaFileCollectionRepository<TKey, TFileCollection> : IDaEntityRepository<TKey, TFileCollection>
        where TKey : IEquatable<TKey>
        where TFileCollection : IDaFileCollection<TKey>
    {
        Task CreateAsync(TFileCollection fileCollection);
        Task<TFileCollection> FindByIdAsync(TKey id);
        Task RenameAsync(TKey id, string newName);
        Task DeleteAsync(TFileCollection fileCollection);
        Task<DaPaginatedEntityList<TKey, TFileCollection>> FindByParentIdAsync(TKey parentId, DaDataPaginationCriteria paginationCriteria);
        Task<DaPaginatedEntityList<TKey, TFileCollection>> FindByObjectInstanceIdAsync(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria);
    }
}
