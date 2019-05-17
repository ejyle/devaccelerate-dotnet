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

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaCustomRole<TKey, TNullableKey>
        : DaEntityBase<TKey>, IDaCustomRole<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public TNullableKey RoleId { get; set; }
        public TKey TenantId { get; set; }
        public TKey CreatedBy { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public TKey LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
