// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Objects;

namespace Ejyle.DevAccelerate.Core.EF.Objects
{
    public class DaObjectInstanceManager : DaObjectInstanceManager<string, DaObjectInstance, DaObjectHistoryItem, DaObjectDependency>
    {
        public DaObjectInstanceManager(DaObjectInstanceRepository repository)
            : base(repository)
        { }
    }
}
