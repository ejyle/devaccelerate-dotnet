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

namespace Ejyle.DevAccelerate.SystemTasks
{
    public interface IDaSystemTaskDefinition<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string SystemTaskType { get; set; }
        DaSystemTaskStatus Status { get; set; }
        string SystemTaskData { get; set; }
        string SystemTaskDataType { get; set; }
        string ErrorData { get; set; }
        string ErrorDataType { get; set; }
        DateTime CreatedDateUtc { get; set; }
        DateTime LastUpdatedDateUtc { get; set; }
    }
}