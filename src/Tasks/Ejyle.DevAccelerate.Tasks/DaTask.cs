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
    public class DaTask : DaTask<string>
    { }

    public class DaTask<TKey> : DaAuditedEntityBase<TKey>, IDaTask<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DaTaskStatus Status { get; set; }
        public string StatusReason { get; set; }
        public TKey AssignedTo { get; set; }
        public TKey OwnerUserId { get; set; }
        public TKey TenantId { get; set; }
        public string Category { get; set; }
        public string ApiUrl { get; set; }
        public string PageUrl { get; set; }
        public DaTaskPriority? Priority { get; set; }
        public TKey ObjectInstanceId { get; set; }
        public bool IsSystemTask { get; set; }
        public bool LastStatusUpdatedBySystem { get; set; }
        public string Rating { get; set; }
    }
}
