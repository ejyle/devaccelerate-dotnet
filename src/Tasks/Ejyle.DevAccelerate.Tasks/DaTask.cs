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
    public class DaTask : DaTask<int, int?>
    { }

    public class DaTask<TKey, TNullableKey> : DaAuditedEntityBase<TKey>, IDaTask<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DaTaskStatus Status { get; set; }
        public string StatusReason { get; set; }
        public TNullableKey AssignedTo { get; set; }
        public TKey OwnerUserId { get; set; }
        public TNullableKey TenantId { get; set; }
        public TNullableKey ObjectInstanceId { get; set; }
    }
}
