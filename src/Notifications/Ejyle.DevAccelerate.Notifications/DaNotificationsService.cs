// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications;
using Ejyle.DevAccelerate.Notifications.Delivery;
using Ejyle.DevAccelerate.Notifications.Events;
using Ejyle.DevAccelerate.Notifications.EventDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Notifications.Subscriptions;

namespace Ejyle.DevAccelerate.Notifications
{
    public class DaNotificationsService<TKey, TNotificationManager, TNotification, TNotificationEventManager, TNotificationEvent, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber, TNotificationEventSubscriberVariable, TNotificationEventDefinitionManager, TNotificationEventDefinition, TNotificationEventDefinitionChannel, TNotificationSubscriptionManager, TNotificationSubscription>
        where TKey : IEquatable<TKey>
        where TNotificationManager : DaNotificationManager<TKey, TNotification>
        where TNotification : DaNotification<TKey>, new()
        where TNotificationEventManager : DaNotificationEventManager<TKey, TNotificationEvent>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber>, new()
        where TNotificationEventChannel : DaNotificationEventChannel<TKey, TNotificationEvent>, new()
        where TNotificationEventVariable : DaNotificationEventVariable<TKey, TNotificationEvent>, new()
        where TNotificationEventSubscriberVariable : DaNotificationEventSubscriberVariable<TKey, TNotificationEventSubscriber>, new()
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationEventSubscriberVariable>, new()
        where TNotificationEventDefinitionManager : DaNotificationEventDefinitionManager<TKey, TNotificationEventDefinition>
        where TNotificationEventDefinition : DaNotificationEventDefinition<TKey, TNotificationEventDefinitionChannel>
        where TNotificationEventDefinitionChannel : DaNotificationEventDefinitionChannel<TKey, TNotificationEventDefinition>
        where TNotificationSubscriptionManager : DaNotificationSubscriptionManager<TKey, TNotificationSubscription>
        where TNotificationSubscription : DaNotificationSubscription<TKey>
    {
        private TNotificationEventManager _notificationEventManager;
        private TNotificationEventDefinitionManager _notificationEventDefinitionManager;
        private TNotificationSubscriptionManager _notificationSubscriptionManager;
        private TNotificationManager _notificationManager;
        public DaNotificationsService(TNotificationEventManager notificationEventManager, TNotificationEventDefinitionManager notificationEventDefinitionManager, TNotificationSubscriptionManager notificationSubscriptionManager, TNotificationManager notificationManager)
        {
            if (notificationEventManager == null)
            {
                throw new ArgumentNullException(nameof(notificationEventManager));
            }

            if (notificationEventDefinitionManager == null)
            {
                throw new ArgumentNullException(nameof(notificationEventDefinitionManager));
            }

            if (notificationSubscriptionManager == null)
            {
                throw new ArgumentNullException(nameof(notificationSubscriptionManager));
            }

            if (notificationEventManager == null)
            {
                throw new ArgumentNullException(nameof(notificationEventManager));
            }

            _notificationEventManager = notificationEventManager;
            _notificationEventDefinitionManager = notificationEventDefinitionManager;
            _notificationManager = notificationManager;
            _notificationSubscriptionManager = notificationSubscriptionManager;
        }

        public virtual async Task CreateEventAsync(string eventName, string userId, DaNotificationSubscriberInfo subscriber, List<DaNotificationVariableInfo> variables)
        {
            await CreateEventAsync(eventName, userId, new List<DaNotificationSubscriberInfo>() { subscriber }, variables);
        }

        public virtual async Task CreateEventAsync(string eventName, string userId, List<DaNotificationSubscriberInfo> subscribers, List<DaNotificationVariableInfo> variables)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (subscribers == null)
            {
                throw new ArgumentNullException(nameof(subscribers));
            }

            var evenDefinition = await _notificationEventDefinitionManager.FindByNameAsync(eventName);

            if (evenDefinition == null)
            {
                throw new DaNotFoundException($"Notification event definition {eventName} not found.");
            }

            var notificationEvent = new TNotificationEvent()
            {
                NotificationEventDefinitionId = evenDefinition.Id,
                Level = DaNotificationLevel.Info,
                ObjectInstanceId = null,
                SubscribersProcessedCount = 0,
                VariableDelimiter = evenDefinition.VariableDelimiter,
                IsProcessingComplete = false,
                CreatedBy = userId,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = userId,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            notificationEvent.Channels = new List<TNotificationEventChannel>();

            foreach (var channel in evenDefinition.Channels)
            {
                notificationEvent.Channels.Add(new TNotificationEventChannel()
                {
                    Body = channel.Body,
                    Channel = channel.Channel,
                    Format = channel.Format,
                    NotificationEventDefinitionChannelId = channel.Id,
                    Subject = channel.Subject,
                    NotificationEvent = notificationEvent
                });
            }

            if (variables != null)
            {
                notificationEvent.Variables = new List<TNotificationEventVariable>();

                foreach (var variable in variables)
                {
                    notificationEvent.Variables.Add(new TNotificationEventVariable()
                    {
                        ForNotification = variable.ForNotification,
                        Name = variable.Name,
                        Value = variable.Value,
                        NotificationEvent = notificationEvent,
                        ForSubject = variable.ForSubject
                    });
                }
            }

            notificationEvent.Subscribers = new List<TNotificationEventSubscriber>();

            foreach (var subscriberInfo in subscribers)
            {
                var subscriber = new TNotificationEventSubscriber()
                {
                    NotificationEvent = notificationEvent,
                    SubscriberAddress = subscriberInfo.To,
                    SubscriberName = subscriberInfo.DisplayName,
                    IsNotificationCreated = false,
                    Variables = new List<TNotificationEventSubscriberVariable>()
                };

                if (subscriberInfo.Variables != null)
                {
                    foreach (var variable in subscriberInfo.Variables)
                    {
                        subscriber.Variables.Add(new TNotificationEventSubscriberVariable()
                        {
                            ForNotification = variable.ForNotification,
                            Name = variable.Name,
                            ForSubject = variable.ForSubject,
                            Value = variable.Value,
                            NotificationEventSubscriber = subscriber
                        });
                    }
                }

                notificationEvent.Subscribers.Add(subscriber);
            }

            await _notificationEventManager.CreateAsync(notificationEvent);
        }

        public async Task<DaNotificationProcessingResult> CreateNotificationsAsync(int processCount = 1000)
        {
            if (processCount > 10000)
            {
                throw new InvalidOperationException("Process count cannot exceed 10000.");
            }

            if (processCount < 1)
            {
                throw new InvalidOperationException("Process count cannot be less than 1.");
            }

            var result = new DaNotificationProcessingResult();        
            var events = await _notificationEventManager.FindUnprocessedAsync(processCount);

            if (events == null || events.Count < 1)
            {
                return result;
            }

            var notifications = new List<TNotification>();

            foreach (var notificationEvent in events)
            {
                if(notificationEvent.Subscribers == null || notificationEvent.Subscribers.Count < 1)
                {
                    notificationEvent.IsProcessingComplete = true;
                    await  _notificationEventManager.UpdateAsync(notificationEvent);
                    continue;
                }

                var eventDefinition = await _notificationEventDefinitionManager.FindByIdAsync(notificationEvent.NotificationEventDefinitionId);

                if (eventDefinition == null)
                {
                    throw new InvalidOperationException("Notification event definition not found.");
                }

                foreach (var channel in notificationEvent.Channels)
                {
                    foreach (var subscriber in notificationEvent.Subscribers)
                    {
                        var notification = new TNotification()
                        {
                            FromAddress = eventDefinition.FromAddress,
                            FromName = eventDefinition.FromName,
                            RecipientAddress = subscriber.SubscriberAddress,
                            RecipientName = subscriber.SubscriberName,
                            Status = DaNotificationStatus.New,
                            Body = channel.Body,
                            Channel = channel.Channel,
                            CreatedDateUtc = DateTime.UtcNow,
                            DeliveryDateUtc = null,
                            FailureMessage = null,
                            Format = channel.Format,
                            LastUpdatedDateUtc = DateTime.UtcNow,
                            Level = notificationEvent.Level,
                            NotificationEventId = notificationEvent.Id,
                            Subject = channel.Subject
                        };

                        notifications.Add(notification);

                        notificationEvent.SubscribersProcessedCount = notificationEvent.SubscribersProcessedCount + 1;
                        subscriber.IsNotificationCreated = true;
                    }
                }

                if (notifications.Count > 0)
                {
                    await _notificationManager.CreateAsync(notifications);
                    await _notificationEventManager.UpdateAsync(events);
                }
            }

            return result;
        }

        public TNotificationManager NotificationManager
        {
            get
            {
                return _notificationManager;
            }
        }
    }

    public class DaNotificationProcessingResult
    {
        public long ProcessingCount { get; set; }
        public long SentCount { get; set; }
        public int SubscribersCount { get; set; }
        public long NotificationFailureCount { get; set; }
        public long SubscriberFailureCount { get; set; }
    }

    public class DaNotificationSubscriberInfo
    {
        public string DisplayName { get; set; }
        public string To { get; set; }
        public List<DaNotificationVariableInfo> Variables { get; set; }
    }

    public class DaNotificationVariableInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForNotification { get; set; }
    }
}
