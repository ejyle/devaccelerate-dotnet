// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Notifications.Events;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.EF.Events
{
    public class DaNotificationEventManager : DaNotificationEventManager<string, DaNotificationEvent>
    {
        public DaNotificationEventManager(DaNotificationEventRepository repository)
            : base(repository)
        { }
    }
}
