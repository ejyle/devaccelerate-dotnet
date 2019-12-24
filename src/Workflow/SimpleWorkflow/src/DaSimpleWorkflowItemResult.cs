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
    public class DaSimpleWorkflowItemResult
    {
        public DaSimpleWorkflowItemResult(bool boolResult)
        {
            Data = null;
            IsSuccess = boolResult;
            Errors = null;
            Parameters = null;
        }

        public DaSimpleWorkflowItemResult(object data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Data = data;
            IsSuccess = true;
            Errors = null;
            Parameters = null;
        }

        public DaSimpleWorkflowItemResult(Dictionary<string, object> parameters, object data)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            Data = data;
            IsSuccess = true;
            Errors = null;
            Parameters = parameters;
        }

        public DaSimpleWorkflowItemResult(Dictionary<string, object> parameters, string[] errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }

            if(errors.Length <= 0)
            {
                throw new InvalidOperationException($"{nameof(errors)} cannot be an empty array.");
            }

            Data = null;
            IsSuccess = true;
            Errors = errors;
            Parameters = parameters;
        }

        public bool IsSuccess { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }
        public string[] Errors { get; private set; }
        public object Data { get; private set; }
    }
}
