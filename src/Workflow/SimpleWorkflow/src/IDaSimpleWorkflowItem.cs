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
    public interface IDaSimpleWorkflowItem<TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition>
        where TSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
        where TSimpleWorkflowItemParameterDefinition : IDaSimpleWorkflowParameterDefinition
    {
        DaSimpleWorkflowItemType WorkflowItemType
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        string Type
        {
            get;
            set;
        }

        TSimpleWorkflowItemSetting[] Settings
        {
            get;
            set;
        }

        TSimpleWorkflowItemParameterDefinition[] ExpectedParameters
        {
            get;
            set;
        }
    }
}
