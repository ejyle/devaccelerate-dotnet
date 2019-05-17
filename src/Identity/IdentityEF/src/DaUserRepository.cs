// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Ejyle.DevAccelerate.Identity.EF.UserSessions;
using Ejyle.DevAccelerate.Identity.EF.UserActivities;

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaUserRepository : DaUserRepository<DaUser, DaRole, DaUserRole, DaUserLogin, DaUserClaim, DbContext>
    {
        public DaUserRepository(DaIdentityDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DaUserRepository<TUser, TRole, TUserRole, TUserLogin, TUserClaim, TDbContext>
        : DaUserRepository<int, int?, TUser, TRole, TUserRole, TUserLogin, TUserClaim, TDbContext>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>
        where TRole : DaRole<int, TUserRole>, new()
        where TUserLogin : DaUserLogin<int>, new()
        where TUserRole : DaUserRole<int>, new()
        where TUserClaim : DaUserClaim<int>, new()
        where TDbContext : DbContext
    {
        public DaUserRepository(TDbContext context)
            : base(context)
        { }
    }

    public class DaUserRepository<TKey, TNullableKey, TUser, TRole, TUserRole, TUserLogin, TUserClaim, TDbContext>
        : UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>, IDaUserRepository<TKey, TNullableKey, TUser>
        where TKey : IEquatable<TKey>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : DaRole<TKey, TUserRole>, new()
        where TUserLogin : DaUserLogin<TKey>, new()
        where TUserRole : DaUserRole<TKey>, new()
        where TUserClaim : DaUserClaim<TKey>, new()
        where TDbContext : DbContext
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserRepository{TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="DbContext"/> used to commit changes in the underlying data store.</param>
        public DaUserRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// Gets the instance of the repository's <see cref="DbContext"/>.
        /// </summary>
        protected TDbContext DaContext
        {
            get
            {
                return Context as TDbContext;
            }
        }

        /// <summary>
        /// Asynchronously creates a user.
        /// </summary>
        /// <param name="user">User to create.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public override Task CreateAsync(TUser user)
        {
            user.CreatedDateUtc = DateTime.UtcNow;
            user.LastUpdatedDateUtc = DateTime.UtcNow;
            return base.CreateAsync(user);
        }

        public Task<bool> IsPasswordInHistoryAsync(TKey userId, string hashedPassword)
        {
            return Task.FromResult<bool>(false);
        }

        public Task RecordPasswordHistoryAsync(TKey userId, string hashedPassword)
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Asynchronously update a user.
        /// </summary>
        /// <param name="user">User to be updated.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public override Task UpdateAsync(TUser user)
        {
            user.LastUpdatedDateUtc = DateTime.UtcNow;
            return base.UpdateAsync(user);
        }
    }
}
