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

namespace Ejyle.DevAccelerate.Messages
{
    public interface IDaMessageRepository<TKey, TMessage> : IDaEntityRepository<TKey, TMessage>
        where TKey : IEquatable<TKey>
        where TMessage : IDaMessage<TKey>
    {
        IQueryable<TMessage> Messages { get; }
        Task CreateAsync(TMessage message);
        Task<TMessage> FindByIdAsync(TKey id);
        Task UpdateAsync(TMessage message);
        Task DeleteAsync(TMessage message);
        Task<DaPaginatedEntityList<TKey, TMessage>> FindByStatusAsync(DaMessageStatus status, DaDataPaginationCriteria paginationCriteria);
    }
}
