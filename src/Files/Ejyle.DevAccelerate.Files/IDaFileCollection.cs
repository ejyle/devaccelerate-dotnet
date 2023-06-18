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

namespace Ejyle.DevAccelerate.Files
{
    public interface IDaFileCollection<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string ObjectIdentifier { get; set; }
        string OwnerUserId { get; set; }
        TKey ParentId { get; set; }
        string TenantId { get; set; }
        bool IsUserDefined { get; set; }
        TKey FileStorageLocationId { get; set; }
    }
}
