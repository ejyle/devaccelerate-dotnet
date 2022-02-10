// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.SystemTasks.EF
{
    public class DaSystemTaskDefinitionManager : DaSystemTaskDefinitionManager<long, DaSystemTaskDefinition>
    {
        public DaSystemTaskDefinitionManager(DaSystemTaskDefinitionRepository repository)
            : base(repository)
        { }
    }
}
