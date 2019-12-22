// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SimpleWorkflow
{
    public interface IDaSimpleWorkflowItemAction
    {
        void SetWorkflowItemSettings(IDaSimpleWorkflowItemSetting[] settings);
        Task<DaSimpleWorkflowItemResult> ExecuteAsync(Dictionary<string, object> parameters);
    }
}
