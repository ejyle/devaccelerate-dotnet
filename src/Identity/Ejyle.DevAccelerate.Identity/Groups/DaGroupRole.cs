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

namespace Ejyle.DevAccelerate.Identity.Groups
{
    public class DaGroupRole : DaGroupRole<string, DaGroup>
    {
        public DaGroupRole() : base()
        { }
    }

    public class DaGroupRole<TKey, TGroup> : DaEntityBase<TKey>, IDaGroupRole<TKey>
        where TKey : IEquatable<TKey>
        where TGroup : IDaGroup<TKey>
    {
        public TKey GroupId { get; set; }
        public TKey RoleId { get; set; }
        public virtual TGroup Group { get; set; }
    }
}