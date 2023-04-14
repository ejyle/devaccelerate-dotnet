// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Social
{
    public class DaPostRole : DaPostRole<string, DaPost>
    { }

    public class DaPostRole<TKey, TPost> : DaEntityBase<TKey>, IDaPostRole<TKey>
        where TKey : IEquatable<TKey>
        where TPost : IDaPost<TKey>
    {
        public string RoleId { get; set; }
        public TKey PostId { get; set; }
        public virtual TPost Post { get; set; }
    }
}