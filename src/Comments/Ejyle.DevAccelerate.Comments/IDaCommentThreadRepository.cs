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

namespace Ejyle.DevAccelerate.Comments
{
    public interface IDaCommentThreadRepository<TKey, TNullableKey, TCommentThread, TComment> : IDaEntityRepository<TKey, TCommentThread>
        where TKey : IEquatable<TKey>
        where TCommentThread : IDaCommentThread<TKey>
        where TComment : IDaComment<TKey, TNullableKey>
    {
        Task CreateAsync(TCommentThread commentThread);
        Task<TCommentThread> FindByIdAsync(TKey id);
        Task CreateCommentAsync(TKey id, TComment comment);
        Task DeleteAsync(TCommentThread commentThread);
        Task<DaPaginatedEntityList<TKey, TComment>> FindCommentsAsync(TKey commentThreadId, DaDataPaginationCriteria paginationCriteria);
    }
}
