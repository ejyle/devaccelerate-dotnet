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

namespace Ejyle.DevAccelerate.SystemTasks
{
    public enum DaSystemTaskStatus
    {
        New = 0,
        InProgress = 1,
        ExecutedWithSuccess = 2,
        ExecutedWithErrors = 3,
        Abandoned = 4,
        TimedOut = 5,
        TypeError = 100
    }
}
