﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Notifications.Delivery;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.EF.Delivery
{
    public class DaNotificationManager : DaNotificationManager<string, DaNotification>
    {
        public DaNotificationManager(DaNotificationRepository repository)
            : base(repository)
        { }
    }
}
