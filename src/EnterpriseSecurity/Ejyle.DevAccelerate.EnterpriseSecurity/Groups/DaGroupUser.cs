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
    public class DaGroupUser : DaGroupUser<int, int?, DaGroup>
    {
        public DaGroupUser() : base()
        { }
    }

    public class DaGroupUser<TKey, TNullableKey, TGroup> : DaEntityBase<TKey>, IDaGroupUser<TKey>
        where TKey : IEquatable<TKey>
        where TGroup : IDaGroup<TKey, TNullableKey>
    {
        public TKey GroupId { get; set; }
        public TKey UserId { get; set; }
        public virtual TGroup Group { get; set; }
    }
}
