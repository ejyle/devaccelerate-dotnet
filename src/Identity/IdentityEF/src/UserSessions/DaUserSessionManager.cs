// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.UserSessions;

namespace Ejyle.DevAccelerate.Identity.EF.UserSessions
{
    public class DaUserSessionManager : DaUserSessionManager<DaUserSession>
    {
        public DaUserSessionManager(DaUserSessionRepository repository)
            : base(repository)
        { }
    }
}
