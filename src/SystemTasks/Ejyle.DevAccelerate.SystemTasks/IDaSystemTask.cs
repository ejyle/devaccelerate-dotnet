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
    public interface IDaSystemTask<TKey, TSystemTaskDefinition>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : IDaSystemTaskDefinition<TKey>
    {
        Task<DaOperationResult> ExecuteAsync(TSystemTaskDefinition systemTaskDefinition);
    }
}
