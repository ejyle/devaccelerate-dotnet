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

namespace Ejyle.DevAccelerate.Identity.UserSessions
{
    public class DaUserSessionManager<TUserSession> : DaUserSessionManager<int, TUserSession>
        where TUserSession : IDaUserSession<int>
    {
        public DaUserSessionManager(IDaUserSessionRepository<int, TUserSession> repository)
            : base(repository)
        {
        }
    }

    public class DaUserSessionManager<TKey, TUserSession>
    : DaEntityManagerBase<TKey, TUserSession>
    where TKey : IEquatable<TKey>
    where TUserSession : IDaUserSession<TKey>
    {
        public DaUserSessionManager(IDaUserSessionRepository<TKey, TUserSession> repository)
            : base(repository)
        { }

        private IDaUserSessionRepository<TKey, TUserSession> GetRepository()
        {
            return GetRepository<IDaUserSessionRepository<TKey, TUserSession>>();
        }

        public Task CreateAsync(TUserSession userSession)
        {
            return GetRepository().CreateAsync(userSession);
        }

        public void Create(TUserSession userSession)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(userSession));
        }

        public TUserSession FindById(TKey userSessionId)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(userSessionId));
        }

        public Task<TUserSession> FindByIdAsync(TKey userSessionId)
        {
            return GetRepository().FindByIdAsync(userSessionId);
        }

        public Task<TUserSession> FindBySessionKeyAsync(string sessionKey)
        {
            return GetRepository().FindBySessionKeyAsync(sessionKey);
        }

        public TUserSession FindBySessionKey(string sessionKey)
        {
            return DaAsyncHelper.RunSync<TUserSession>(() => FindBySessionKeyAsync(sessionKey));
        }

        public Task<List<TUserSession>> FindBySystemSessionIdAsync(string systemSessionId)
        {
            return GetRepository().FindBySystemSessionIdAsync(systemSessionId);
        }

        public List<TUserSession> FindBySystemSessionId(string systemSessionId)
        {
            return DaAsyncHelper.RunSync<List<TUserSession>>(() => FindBySystemSessionIdAsync(systemSessionId));
        }

        public Task<DaPaginatedEntityList<TKey, TUserSession>> FindByUserIdAsync(DaDataPaginationCriteria paginationCriteria, TKey userId)
        {
            return GetRepository().FindByUserIdAsync(paginationCriteria, userId);
        }

        public DaPaginatedEntityList<TKey, TUserSession> FindByUserId(DaDataPaginationCriteria paginationCriteria, TKey userId)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TUserSession>>(() => FindByUserIdAsync(paginationCriteria, userId));
        }
    }
}
