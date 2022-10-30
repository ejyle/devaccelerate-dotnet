﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.EnterpriseSecurity.Objects;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Objects
{
    public class DaObjectInstanceManager : DaObjectInstanceManager<int, DaObjectInstance, DaObjectHistoryItem>
    {
        public DaObjectInstanceManager(DaObjectInstanceRepository repository)
            : base(repository)
        { }
    }
}