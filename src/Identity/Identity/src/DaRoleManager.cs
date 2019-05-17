// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.Configuration;
using System;
using System.Linq;

namespace Ejyle.DevAccelerate.Identity
{
    public class DaRoleManager<TRole> : DaRoleManager<int, TRole>
        where TRole : class, IDaRole<int>
    {
        public DaRoleManager(IDaRoleRepository<int, TRole> repository)
            : base(repository)
        {
        }
    }

    public class DaRoleManager<TKey, TRole> : Microsoft.AspNet.Identity.RoleManager<TRole, TKey>
        where TKey : IEquatable<TKey>
        where TRole : class, IDaRole<TKey>
    {
        public DaRoleManager(IDaRoleRepository<TKey, TRole> repository)
            : base(repository)
        {
        }
    }
}
