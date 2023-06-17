// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Notifications.Requests;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationRequestManager : DaNotificationRequestManager<string, DaNotificationRequest>
    {
        public DaNotificationRequestManager(DaNotificationRequestRepository repository)
            : base(repository)
        { }
    }
}
