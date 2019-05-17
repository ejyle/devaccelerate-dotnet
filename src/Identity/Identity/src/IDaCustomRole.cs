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

namespace Ejyle.DevAccelerate.Identity
{
    public interface IDaCustomRole<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        TNullableKey RoleId { get; set; }
        TKey TenantId { get; set; }
        TKey CreatedBy { get; set; }
        DateTime CreatedDateUtc { get; set; }
        TKey LastUpdatedBy { get; set; }
        DateTime LastUpdatedDateUtc { get; set; }
    }
}
