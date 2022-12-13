// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Groups
{
    public class DaGroup : DaGroup<int, int?, DaGroupRole, DaGroupUser>
    {
        public DaGroup() : base()
        { }
    }

    public class DaGroup<TKey, TNullableKey, TGroupRole, TGroupUser> : DaAuditedEntityBase<TKey>, IDaGroup<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TGroupRole : IDaGroupRole<TKey>
        where TGroupUser : IDaGroupUser<TKey>
    {
        public DaGroup()
        {
            GroupRoles = new HashSet<TGroupRole>();
            GroupUsers= new HashSet<TGroupUser>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public TNullableKey TenantId { get; set; }
        public virtual ICollection<TGroupRole> GroupRoles { get; set; }
        public virtual ICollection<TGroupUser> GroupUsers { get; set; }
    }
}
