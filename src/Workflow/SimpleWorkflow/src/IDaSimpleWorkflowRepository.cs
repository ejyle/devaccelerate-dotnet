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

namespace Ejyle.DevAccelerate.Workflow.SimpleWorkflow
{
    public interface IDaSimpleWorkflowRepository<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowParameterDefinition>
        where TSimpleWorkflow : IDaSimpleWorkflow<TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowParameterDefinition>
        where TSimpleWorkflowItem : IDaSimpleWorkflowItem<TSimpleWorkflowItemSetting, TSimpleWorkflowParameterDefinition>
        where TSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
        where TSimpleWorkflowParameterDefinition : IDaSimpleWorkflowParameterDefinition
    {
        TSimpleWorkflow GetWorkflow(string name);
        void SetLocation(string location);
    }
}
