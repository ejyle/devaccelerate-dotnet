// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Posts
{
    public class DaPostOrganizationGroup : DaPostOrganizationGroup<string, DaPost>
    { }

    public class DaPostOrganizationGroup<TKey, TPost> : DaEntityBase<TKey>, IDaPostOrganizationGroup<TKey>
        where TKey : IEquatable<TKey>
        where TPost : IDaPost<TKey>
    {
        public string OrganizationGroupId { get; set; }
        public TKey PostId { get; set; }
        public virtual TPost Post { get; set; }
    }
}
