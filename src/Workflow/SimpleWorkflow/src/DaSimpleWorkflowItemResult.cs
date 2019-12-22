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
    public class DaSimpleWorkflowItemResult
    {
        public DaSimpleWorkflowItemResult(bool boolResult)
        {
            Data = null;
            IsSuccess = boolResult;
            ResultType = DaSimpleWorkflowItemActionResultType.None;
            Errors = null;
            DataDictionary = null;
            WorkflowItemType = DaSimpleWorkflowItemType.Condition;
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
            DataDictionary = null;
            ResultType = DaSimpleWorkflowItemActionResultType.Data;
        }

        public DaSimpleWorkflowItemResult(Dictionary<string, object> dataDictionary)
        {
            if (dataDictionary == null)
            {
                throw new ArgumentNullException(nameof(dataDictionary));
            }

            Data = null;
            IsSuccess = true;
            Errors = null;
            DataDictionary = dataDictionary;
            ResultType = DaSimpleWorkflowItemActionResultType.DataDictionary;
        }

        public DaSimpleWorkflowItemResult(string[] errors)
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
            DataDictionary = null;
            ResultType = DaSimpleWorkflowItemActionResultType.None;
        }

        public bool IsSuccess { get; private set; }
        public Dictionary<string, object> DataDictionary { get; private set; }
        public string[] Errors { get; private set; }
        public string Name { get; internal set; }
        public object Data { get; private set; }
        public DaSimpleWorkflowItemType WorkflowItemType { get; internal set; }
        public DaSimpleWorkflowItemActionResultType ResultType { get; internal set; }
    }
}
