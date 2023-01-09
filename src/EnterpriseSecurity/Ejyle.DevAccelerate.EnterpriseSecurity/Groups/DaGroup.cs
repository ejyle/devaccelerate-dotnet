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
    public class DaGroup : DaGroup<string, DaGroupRole, DaGroupUser>
    {
        public DaGroup() : base()
        { }
    }

    public class DaGroup<TKey, TGroupRole, TGroupUser> : DaAuditedEntityBase<TKey>, IDaGroup<TKey>
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
        public string? Description { get; set; }
        public TKey TenantId { get; set; }
        public virtual ICollection<TGroupRole> GroupRoles { get; set; }
        public virtual ICollection<TGroupUser> GroupUsers { get; set; }
    }
}
