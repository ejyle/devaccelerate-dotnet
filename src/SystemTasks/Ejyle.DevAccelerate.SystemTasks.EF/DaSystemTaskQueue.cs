// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SystemTasks.EF
{
    public class DaSystemTaskQueue : DaSystemTaskQueue<long, DaSystemTaskDefinition, DaSystemTaskDefinitionManager>
    {
        public DaSystemTaskQueue(DaSystemTaskDefinitionManager taskManager)
            : base(taskManager)
        { }
    }
}