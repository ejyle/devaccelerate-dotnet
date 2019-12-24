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
    public class DaSimpleWorkflowResult
    {
        public bool IsSuccess
        {
            get
            {
                bool result = true;
                foreach(var itemResult in WorkflowItemResults)
                {
                    if(!itemResult.IsSuccess)
                    {
                        result = false;
                        break;
                    }
                }

                return result;
            }
        }

        public List<DaSimpleWorkflowItemResult> WorkflowItemResults
        {
            get;
            set;
        }
    }
}
