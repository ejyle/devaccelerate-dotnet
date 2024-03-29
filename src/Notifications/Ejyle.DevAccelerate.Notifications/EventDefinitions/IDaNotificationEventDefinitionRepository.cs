﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.EventDefinitions
{
    public interface IDaNotificationEventDefinitionRepository<TKey, TNotificationEventDefinition> : IDaEntityRepository<TKey, TNotificationEventDefinition>
        where TKey : IEquatable<TKey>
        where TNotificationEventDefinition : IDaNotificationEventDefinition<TKey>
    {
        Task CreateAsync(TNotificationEventDefinition eventDefinition);
        Task<List<TNotificationEventDefinition>> FindAllAsync();
        Task<TNotificationEventDefinition> FindByIdAsync(TKey id);
        Task<TNotificationEventDefinition> FindByNameAsync(string name);
        Task UpdateAsync(TNotificationEventDefinition eventDefinition);
        Task DeleteAsync(TNotificationEventDefinition eventDefinition);
    }
}
