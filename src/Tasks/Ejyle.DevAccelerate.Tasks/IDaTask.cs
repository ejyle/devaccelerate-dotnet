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

namespace Ejyle.DevAccelerate.Tasks
{
    public interface IDaTask<TKey, TNullableKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string Summary { get; set; }
        string Description { get; set; }
        DaTaskStatus Status { get; set; }
        string StatusReason { get; set; }
        TNullableKey AssignedTo { get; set; }
        TKey OwnerUserId { get; set; }
        TNullableKey TenantId { get; set; }
        TNullableKey ObjectInstanceId { get; set; }
    }
}
