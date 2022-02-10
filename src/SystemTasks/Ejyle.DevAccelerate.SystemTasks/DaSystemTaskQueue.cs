// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SystemTasks
{
    public class DaSystemTaskQueue<TKey, TSystemTaskDefinition, TSystemTaskManager>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : IDaSystemTaskDefinition<TKey>
        where TSystemTaskManager : DaSystemTaskDefinitionManager<TKey, TSystemTaskDefinition>
    {
        private TSystemTaskManager _taskManager;
        private Queue<DaSystemTaskQueueItem<TKey, TSystemTaskDefinition>> _queue;

        public DaSystemTaskQueue(TSystemTaskManager taskManager)
        {
            if(taskManager == null)
            {
                throw new ArgumentNullException(nameof(taskManager));
            }

            _taskManager = taskManager;
            _queue = new Queue<DaSystemTaskQueueItem<TKey, TSystemTaskDefinition>>();
        }

        public async Task QueueAsync()
        {
            var systemTaskDefinitions = await _taskManager.FindNewAsync(100);

            foreach(var systemTaskDefinition in systemTaskDefinitions)
            {
                systemTaskDefinition.Status = DaSystemTaskStatus.InProgress;
                systemTaskDefinition.LastUpdatedDateUtc = DateTime.UtcNow;

                try
                {
                    var systemTask = Activator.CreateInstance(Type.GetType(systemTaskDefinition.SystemTaskType)) as IDaSystemTask<TKey, TSystemTaskDefinition>;

                    if (systemTask != null)
                    {
                        _queue.Enqueue(new DaSystemTaskQueueItem<TKey, TSystemTaskDefinition>()
                        {
                            SystemTaskDefinitionId = systemTaskDefinition.Id,
                            SystemTask = systemTask
                        });
                    }
                    else
                    {
                        var errors = new List<DaOperationError>(){
                            new DaOperationError("NULL_INSTANCE", "Activator.CreateInstance() returned null.")};

                        systemTaskDefinition.Status = DaSystemTaskStatus.TypeError;
                        systemTaskDefinition.ErrorData = JObject.FromObject(errors).ToString(Formatting.None);
                        systemTaskDefinition.ErrorDataType = errors.GetType().FullName;
                    }
                }
                catch(Exception ex)
                {
                    var errors = new List<DaOperationError>(){
                            new DaOperationError(ex.GetType().FullName, ex.Message)};

                    systemTaskDefinition.Status = DaSystemTaskStatus.TypeError;
                    systemTaskDefinition.ErrorData = JObject.FromObject(errors).ToString(Formatting.None);
                    systemTaskDefinition.ErrorDataType = errors.GetType().FullName;
                }

                await _taskManager.UpdateAsync(systemTaskDefinition);
            }
        }

        public async Task ExecuteAsync()
        {
            while(_queue.Count > 0)
            {
                var systemTaskQueueItem = _queue.Dequeue();

                var systemTaskDefinition = await _taskManager.FindByIdAsync(systemTaskQueueItem.SystemTaskDefinitionId);
                systemTaskDefinition.LastUpdatedDateUtc = DateTime.UtcNow;

                DaOperationResult result = null;

                try
                {
                    result = await systemTaskQueueItem.SystemTask.ExecuteAsync(systemTaskDefinition);

                    if (result.IsSuccess)
                    {
                        systemTaskDefinition.Status = DaSystemTaskStatus.ExecutedWithSuccess;
                        await _taskManager.UpdateAsync(systemTaskDefinition);
                    }
                    else
                    {
                        systemTaskDefinition.Status = DaSystemTaskStatus.ExecutedWithErrors;
                        systemTaskDefinition.ErrorData = JObject.FromObject(result.Errors).ToString(Formatting.None);
                        systemTaskDefinition.ErrorDataType = result.Errors.GetType().FullName;
                    }
                }
                catch (Exception ex)
                {
                    var errors = new List<DaOperationError>(){
                            new DaOperationError(ex.GetType().FullName, ex.Message)};

                    systemTaskDefinition.Status = DaSystemTaskStatus.ExecutedWithErrors;
                    systemTaskDefinition.ErrorData = JObject.FromObject(errors).ToString(Formatting.None);
                    systemTaskDefinition.ErrorDataType = errors.GetType().FullName;
                }
            }
        }
    }

    public class DaSystemTaskQueueItem<TKey, TSystemTaskDefinition>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : IDaSystemTaskDefinition<TKey>
    {
        public TKey SystemTaskDefinitionId { get; set; }
        public IDaSystemTask<TKey, TSystemTaskDefinition> SystemTask { get; set;}
    }
}