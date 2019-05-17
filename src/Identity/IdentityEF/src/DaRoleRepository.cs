// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Identity.EF.UserActivities;
using Ejyle.DevAccelerate.Identity.EF.UserSessions;
using Ejyle.DevAccelerate.Identity.UserSettings;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaRoleRepository : DaRoleRepository<DaRole, DaUserRole, DbContext>
    {
        public DaRoleRepository(DbContext context)
            : base(context)
        { }
    }

    public class DaRoleRepository<TRole, TUserRole, TDbContext>
        : DaRoleRepository<int, TRole, TUserRole, TDbContext>
        where TRole : DaRole<int, TUserRole>, new()
        where TUserRole : DaUserRole<int>, new()
        where TDbContext : DbContext
    {
        public DaRoleRepository(TDbContext context)
            : base(context)
        { }
    }

    public class DaRoleRepository<TKey, TRole, TUserRole,TDbContext>
        : RoleStore<TRole, TKey, TUserRole>,
        IDaRoleRepository<TKey, TRole>
        where TKey : IEquatable<TKey>
        where TRole : DaRole<TKey, TUserRole>, new()
        where TUserRole : DaUserRole<TKey>, new()
        where TDbContext : DbContext
    {
        public DaRoleRepository(TDbContext context)
            : base(context)
        { }

        protected TDbContext DaContext
        {
            get
            {
                return Context as TDbContext;
            }
        }
    }
}
