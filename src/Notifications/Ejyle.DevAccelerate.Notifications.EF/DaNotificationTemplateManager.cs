// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Notifications;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationTemplateManager : DaNotificationTemplateManager<string, DaNotificationTemplate>
    {
        public DaNotificationTemplateManager(DaNotificationTemplateRepository repository)
            : base(repository)
        { }
    }
}
