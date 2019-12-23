// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.SimpleWorkflow.Configuration;
using Ejyle.DevAccelerate.SimpleWorkflow.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SimpleWorkflow
{
    public class DaSimpleWorkflowService : DaSimpleWorkflowService<DaXmlSimpleWorkflow, DaXmlSimpleWorkflowItem, DaXmlSimpleWorkflowItemSetting, DaXmlSimpleWorkflowItemParameterDefinition>
    {
        public DaSimpleWorkflowService(string repositoryLocation)
            : base(new DaXmlSimpleWorkflowRepository(), repositoryLocation)
        { }
    }

    public class DaSimpleWorkflowService<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition>
        where TSimpleWorkflow : IDaSimpleWorkflow<TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition>
        where TSimpleWorkflowItem : IDaSimpleWorkflowItem<TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition>
        where TSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
        where TSimpleWorkflowItemParameterDefinition : IDaSimpleWorkflowParameterDefinition
    {
        private IDaSimpleWorkflowRepository<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition> _repository;

        public DaSimpleWorkflowService()
        {
            var config = DaSimpleWorkflowConfigurationManager.GetConfiguration();
            Type type = Type.GetType(config.RepositoryType);
            
            _repository = Activator.CreateInstance(type) as IDaSimpleWorkflowRepository<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition>;
            
            if(_repository == null)
            {
                throw new InvalidOperationException("Workflow repository cannot be null.");
            }
            
            _repository.SetLocation(config.RepositoryLocation);
        }

        public DaSimpleWorkflowService(IDaSimpleWorkflowRepository<TSimpleWorkflow, TSimpleWorkflowItem, TSimpleWorkflowItemSetting, TSimpleWorkflowItemParameterDefinition> repository, string repositoryLocation)
        {
            if(repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            _repository = repository;
            _repository.SetLocation(repositoryLocation);
        }

        public DaSimpleWorkflowResult Execute(string name, Dictionary<string, object> parameters)
        {
            return DaAsyncHelper.RunSync<DaSimpleWorkflowResult>(() => ExecuteAsync(name, parameters));
        }

        public async Task<DaSimpleWorkflowResult> ExecuteAsync(string name, Dictionary<string, object> parameters)
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

            foreach(var workflowItem in simpleWorkflow.WorkflowItems)
            {
                var workflowItemParams = new Dictionary<string, object>();

                foreach(var expectedParameter in workflowItem.ExpectedParameters)
                {
                    var foundParameter = parameters[expectedParameter.Name];

                    if(expectedParameter.Required && foundParameter == null)
                    {
                        throw new InvalidOperationException($"{expectedParameter.Name} parameter was expected by the work flow item {workflowItem.Name} but was not found in the parameters list.");
                    }

                    if(foundParameter != null)
                    {
                        workflowItemParams.Add(expectedParameter.Name, foundParameter);
                    }
                }

                Type type = Type.GetType(workflowItem.Type);

                if(workflowItem.WorkflowItemType == DaSimpleWorkflowItemType.Action)
                {
                    var simpleWorkflowItemAction = Activator.CreateInstance(type) as IDaSimpleWorkflowItemAction;
                    
                    if(simpleWorkflowItemAction == null)
                    {
                        throw new InvalidOperationException("Invalid workflow item.");
                    }

                    simpleWorkflowItemAction.SetWorkflowItemSettings(workflowItem.Settings as IDaSimpleWorkflowItemSetting[]);

                    var itemResult = await simpleWorkflowItemAction.ExecuteAsync(workflowItemParams);

                    if (itemResult != null && itemResult.Parameters != null)
                    {
                        foreach (var parameter in itemResult.Parameters)
                        {
                            if (!parameters.ContainsKey(parameter.Key))
                            {
                                parameters.Add(parameter.Key, parameter.Value);
                            }
                            else
                            {
                                parameters[parameter.Key] = parameter.Value;
                            }
                        }
                    }

                    if (itemResult != null)
                    {
                        result.WorkflowItemResults.Add(itemResult);
                    }
                }
                else if (workflowItem.WorkflowItemType == DaSimpleWorkflowItemType.Condition)
                {
                    var simpleWorkflowItemCondition = Activator.CreateInstance(type) as IDaSimpleWorkflowItemCondition;

                    if (simpleWorkflowItemCondition == null)
                    {
                        throw new InvalidOperationException("Invalid workflow item.");
                    }

                    simpleWorkflowItemCondition.SetWorkflowItemSettings(workflowItem.Settings as IDaSimpleWorkflowItemSetting[]);

                    var boolResult = await simpleWorkflowItemCondition.ExecuteAsync(workflowItemParams);
                    
                    var itemResult = new DaSimpleWorkflowItemResult(boolResult);                                   
                    result.WorkflowItemResults.Add(itemResult);

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
