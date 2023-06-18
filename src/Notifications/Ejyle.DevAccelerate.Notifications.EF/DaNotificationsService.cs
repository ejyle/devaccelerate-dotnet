// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Notifications.Delivery;
using Ejyle.DevAccelerate.Notifications.EventDefinitions;
using Ejyle.DevAccelerate.Notifications.Events;
using Ejyle.DevAccelerate.Notifications.Subscriptions;
using Ejyle.DevAccelerate.Notifications.EF.Delivery;
using Ejyle.DevAccelerate.Notifications.EF.EventDefinitions;
using Ejyle.DevAccelerate.Notifications.EF.Events;
using Ejyle.DevAccelerate.Notifications.EF.Subscriptions;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationsService : DaNotificationsService<string, DaNotificationManager, DaNotification, DaNotificationEventManager, DaNotificationEvent, DaNotificationEventChannel, DaNotificationEventVariable, DaNotificationEventSubscriber, DaNotificationEventSubscriberVariable, DaNotificationEventDefinitionManager, DaNotificationEventDefinition, DaNotificationEventDefinitionChannel, DaNotificationSubscriptionManager, DaNotificationSubscription>
    {
        public DaNotificationsService(DaNotificationsDbContext dbContext)
            : base(new DaNotificationEventManager(new DaNotificationEventRepository(dbContext)),
                  new DaNotificationEventDefinitionManager(new DaNotificationEventDefinitionRepository(dbContext)),
                  new DaNotificationSubscriptionManager(new DaNotificationSubscriptionRepository(dbContext)),
                  new DaNotificationManager(new DaNotificationRepository(dbContext)))
        { }

        public DaNotificationsService(DaNotificationEventManager notificationEventManager, DaNotificationEventDefinitionManager notificationEventDefinitionManager, DaNotificationSubscriptionManager notificationSubscriptionManager, DaNotificationManager notificationManager)
            : base(notificationEventManager, notificationEventDefinitionManager, notificationSubscriptionManager, notificationManager)
        { }
    }
}
