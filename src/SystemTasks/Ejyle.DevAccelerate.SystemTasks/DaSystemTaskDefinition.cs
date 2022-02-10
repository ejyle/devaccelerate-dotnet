// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SystemTasks
{
    public class DaSystemTaskDefinition : DaSystemTaskDefinition<long, DaSystemTaskDefinitionAttribute>
    {
        public DaSystemTaskDefinition() : base()
        { }
    }

    public class DaSystemTaskDefinition<TKey, TSystemTaskDefinitionAttribute> : DaEntityBase<TKey>, IDaSystemTaskDefinition<TKey>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinitionAttribute : IDaSystemTaskDefinitionAttribute<TKey>
    {
        public DaSystemTaskDefinition()
        {
            Attributes = new HashSet<TSystemTaskDefinitionAttribute>();
        }

        public DaSystemTaskStatus Status { get; set; }
        public string SystemTaskType { get; set; }
        public string SystemTaskData { get; set; }
        public string ErrorData { get; set; }
        public string SystemTaskDataType { get; set; }
        public string ErrorDataType { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }

        public virtual ICollection<TSystemTaskDefinitionAttribute> Attributes { get; set; }
    }
}
