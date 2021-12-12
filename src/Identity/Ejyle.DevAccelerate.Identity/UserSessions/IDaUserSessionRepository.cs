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

namespace Ejyle.DevAccelerate.Identity.UserSessions
{
    public interface IDaUserSessionRepository<TKey, TUserSession> : IDaEntityRepository<TKey, TUserSession>
        where TKey : IEquatable<TKey>
        where TUserSession : IDaUserSession<TKey>
    {
        Task CreateAsync(TUserSession userSession);
        Task UpdateAsync(TUserSession userSession);
        Task<TUserSession> FindByIdAsync(TKey id);
        Task<TUserSession> FindBySessionKeyAsync(string sessionKey);
        Task<List<TUserSession>> FindBySystemSessionIdAsync(string systemSessionId);
        Task<TUserSession> FindLatestByUserIdAsync(TKey userId);
        Task<DaPaginatedEntityList<TKey, TUserSession>> FindByUserIdAsync(DaDataPaginationCriteria paginationCriteria, TKey userId);
    }
}
