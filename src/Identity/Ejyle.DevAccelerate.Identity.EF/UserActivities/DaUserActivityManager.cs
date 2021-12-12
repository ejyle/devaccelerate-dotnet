// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.UserActivities;

namespace Ejyle.DevAccelerate.Identity.EF.UserActivities
{
    public class DaUserActivityManager : DaUserActivityManager<DaUserActivity>
    {
        public DaUserActivityManager(DaUserActivityRepository repository)
            : base(repository)
        { }
    }
}
