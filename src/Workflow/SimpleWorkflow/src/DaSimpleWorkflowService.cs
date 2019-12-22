// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.SimpleWorkflow.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SimpleWorkflow
{
    public class DaSimpleWorkflowService<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting>
        where TSimpleWorkflow : IDaSimpleWorkflow<TSimpleWorkflowItem, TSimpleWorkflowItemSetting>
        where TSimpleWorkflowItem : IDaSimpleWorkflowItem<TSimpleWorkflowItemSetting>
        where TSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
    {
        private IDaSimpleWorkflowRepository<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting> _repository;

        public DaSimpleWorkflowService()
        {
            var config = DaSimpleWorkflowConfigurationManager.GetConfiguration();
            Type type = Type.GetType(config.RepositoryType);
            
            _repository = Activator.CreateInstance(type) as IDaSimpleWorkflowRepository<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting>;
            
            if(_repository == null)
            {
                throw new InvalidOperationException("Workflow repository cannot be null.");
            }
            
            _repository.SetLocation(config.RepositoryLocation);
        }

        public DaSimpleWorkflowResult Execute(string name, Dictionary<string, object> mainInput)
        {
            return DaAsyncHelper.RunSync<DaSimpleWorkflowResult>(() => ExecuteAsync(name, mainInput));
        }

        public async Task<DaSimpleWorkflowResult> ExecuteAsync(string name, Dictionary<string, object> mainInput)
        {
            var simpleWorkflow = _repository.GetWorkflow(name);

            if(simpleWorkflow == null)
            {
                throw new InvalidOperationException($"{name} simple workflow doesn't exist.");
            }

            var result = new DaSimpleWorkflowResult()
            {
                WorkflowItemResults = new List<DaSimpleWorkflowItemResult>()
            };

            var chainedResult = new List<DaSimpleWorkflowItemResult>();

            foreach(var workflowItem in simpleWorkflow.WorkflowItems)
            {
                Type type = Type.GetType(workflowItem.Type);

                if(workflowItem.WorkflowItemType == DaSimpleWorkflowItemType.Action)
                {
                    var simpleWorkflowItemAction = Activator.CreateInstance(type) as IDaSimpleWorkflowItemAction;
                    
                    if(simpleWorkflowItemAction == null)
                    {
                        throw new InvalidOperationException("Invalid workflow item.");
                    }

                    simpleWorkflowItemAction.SetWorkflowItemSettings(workflowItem.WorkflowItemSettings as IDaSimpleWorkflowItemSetting[]);

                    var itemResult = await simpleWorkflowItemAction.ExecuteAsync(mainInput, chainedResult);
                    itemResult.Name = workflowItem.Name;
                    itemResult.ResultType = workflowItem.ActionResultType;
                    itemResult.WorkflowItemType = DaSimpleWorkflowItemType.Action;

                    result.WorkflowItemResults.Add(itemResult);

                    if (itemResult.IsSuccess)
                    {
                        chainedResult.Add(itemResult);
                    }
                }
                else if (workflowItem.WorkflowItemType == DaSimpleWorkflowItemType.Condition)
                {
                    var simpleWorkflowItemCondition = Activator.CreateInstance(type) as IDaSimpleWorkflowItemCondition;

                    if (simpleWorkflowItemCondition == null)
                    {
                        throw new InvalidOperationException("Invalid workflow item.");
                    }

                    simpleWorkflowItemCondition.SetWorkflowItemSettings(workflowItem.WorkflowItemSettings as IDaSimpleWorkflowItemSetting[]);

                    var boolResult = await simpleWorkflowItemCondition.ExecuteAsync(mainInput, chainedResult);
                    
                    var itemResult = new DaSimpleWorkflowItemResult(boolResult);
                    itemResult.Name = workflowItem.Name;
                    itemResult.ResultType = DaSimpleWorkflowItemActionResultType.None;
                    itemResult.WorkflowItemType = DaSimpleWorkflowItemType.Condition;
                    result.WorkflowItemResults.Add(itemResult);
                    chainedResult.Add(itemResult);

                    if (boolResult == false)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}
