// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Tasks
{
    public interface IDaTask<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string Summary { get; set; }
        string Description { get; set; }
        DaTaskStatus Status { get; set; }
        string StatusReason { get; set; }
        TKey AssignedTo { get; set; }
        TKey OwnerUserId { get; set; }
        TKey TenantId { get; set; }
        string Category { get; set; }
        TKey ObjectInstanceId { get; set; }
    }
}
