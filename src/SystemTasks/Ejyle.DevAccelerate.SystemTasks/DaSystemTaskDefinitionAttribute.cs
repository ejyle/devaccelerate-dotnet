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

namespace Ejyle.DevAccelerate.SystemTasks
{
    public class DaSystemTaskDefinitionAttribute : DaSystemTaskAttribute<long, DaSystemTaskDefinition>
    {
    }

    public class DaSystemTaskAttribute<TKey, TSystemTaskDefinition> : DaEntityBase<TKey>, IDaSystemTaskDefinitionAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : IDaSystemTaskDefinition<TKey>
    {
        public TKey SystemTaskId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TSystemTaskDefinition SystemTask { get; set; }
    }
}
