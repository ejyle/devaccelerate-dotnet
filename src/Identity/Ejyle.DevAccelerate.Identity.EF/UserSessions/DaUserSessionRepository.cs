// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.EF;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Identity.EF.UserSessions
{
    public class DaUserSessionRepository : DaUserSessionRepository<DaUserSession, DbContext>
    {
        public DaUserSessionRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaUserSessionRepository<TUserSession, TDbContext>
        : DaUserSessionRepository<string, TUserSession, TDbContext>
        where TUserSession : DaUserSession<string>
        where TDbContext : DbContext
    {
        public DaUserSessionRepository(TDbContext context)
            : base(context)
        { }
    }

    public class DaUserSessionRepository<TKey, TUserSession, TDbContext>
         : DaEntityRepositoryBase<TKey,TUserSession, TDbContext>, IDaUserSessionRepository<TKey, TUserSession>
         where TKey : IEquatable<TKey>
         where TUserSession : DaUserSession<TKey>
         where TDbContext : DbContext
    {
        private DbSet<TUserSession> UserSessions { get { return DbContext.Set<TUserSession>(); } }

        public DaUserSessionRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public virtual Task CreateAsync(TUserSession userSession)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userSession, nameof(userSession));
            UserSessions.Add(userSession);
            return SaveChangesAsync();
        }

        public virtual Task<TUserSession> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return UserSessions.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TUserSession> FindByAccessTokenAsync(string sessionKey)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNullOrEmpty(sessionKey, nameof(sessionKey));
            return UserSessions.Where(m => m.AccessToken == sessionKey).SingleOrDefaultAsync();
        }

        public Task<List<TUserSession>> FindBySystemSessionIdAsync(string systemSessionId)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNullOrEmpty(systemSessionId, nameof(systemSessionId));
            return UserSessions.Where(m => m.SystemSessionId == systemSessionId).ToListAsync();
        }

        public virtual async Task<DaPaginatedEntityList<TKey, TUserSession>> FindByUserIdAsync(DaDataPaginationCriteria paginationCriteria, TKey userId)
        {
            ThrowIfDisposed();
            var totalCount = await UserSessions.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = UserSessions
                .Where(m => m.UserId.Equals(userId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TUserSession>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task UpdateAsync(TUserSession userSession)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userSession, nameof(userSession));

            DbContext.Entry<TUserSession>(userSession).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public Task<TUserSession> FindLatestByUserIdAsync(TKey userId)
        {
            ThrowIfDisposed();
            return UserSessions.Where(m => m.UserId.Equals(userId)).OrderByDescending(m => m.CreatedDateUtc).FirstOrDefaultAsync();
        }
    }
}
