// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Mail;
using Ejyle.DevAccelerate.Mail.SendGrid;
using Ejyle.DevAccelerate.Notifications;
using Ejyle.DevAccelerate.Notifications.Delivery;
using Ejyle.DevAccelerate.Notifications.EF;
using Ejyle.DevAccelerate.Notifications.Events;
using Ejyle.DevAccelerate.Notifications.EventDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Facades.Notifications
{
    public class DaNotificationsFacade : DaNotificationsFacade<string, DaNotificationManager, DaNotification, DaNotificationRequestManager, DaNotificationEvent, DaNotificationEventChannel, DaNotificationEventVariable, DaNotificationEventSubscriber, DaNotificationEventSubscriberVariable, DaNotificationEventDefinitionManager, DaNotificationEventDefinition, DaNotificationEventDefinitionChannel>
    {
        public DaNotificationsFacade(DaNotificationRequestManager notificationManager, DaNotificationEventDefinitionManager notificationTemplateManager)
            : base(notificationManager, notificationTemplateManager)
        {
        }
    }

    public class DaNotificationsFacade<TKey, TNotificationManager, TNotification, TNotificationEventManager, TNotificationEvent, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber, TNotificationEventSubscriberVariable, TNotificationEventDefinitionManager, TNotificationEventDefinition, TNotificationEventDefinitionChannel>
        where TKey : IEquatable<TKey>
        where TNotificationManager : DaNotificationManager<TKey, TNotification>
        where TNotification : DaNotification<TKey>, new()
        where TNotificationEventManager : DaNotificationEventManager<TKey, TNotificationEvent>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber>, new ()
        where TNotificationEventChannel : DaNotificationEventChannel<TKey, TNotificationEvent>, new()
        where TNotificationEventVariable : DaNotificationEventVariable<TKey, TNotificationEvent>, new()
        where TNotificationEventSubscriberVariable : DaNotificationEventSubscriberVariable<TKey, TNotificationEventSubscriber>, new()
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationEventSubscriberVariable>, new ()
        where TNotificationEventDefinitionManager : DaNotificationEventDefinitionManager<TKey, TNotificationEventDefinition>
        where TNotificationEventDefinition : DaNotificationEventDefinition<TKey, TNotificationEventDefinitionChannel>
        where TNotificationEventDefinitionChannel : DaNotificationEventDefinitionChannel<TKey, TNotificationEventDefinition>
    {
        private TNotificationEventManager _notificationManager;
        private TNotificationEventDefinitionManager _notificationTemplateManager;

        public DaNotificationsFacade(TNotificationEventManager notificationManager, TNotificationEventDefinitionManager notificationTemplateManager)
        {
            if (notificationManager == null)
            {
                throw new ArgumentNullException(nameof(notificationManager));
            }

            if (notificationTemplateManager == null)
            {
                throw new ArgumentNullException(nameof(notificationTemplateManager));
            }

            _notificationManager = notificationManager;
            _notificationTemplateManager = notificationTemplateManager;
        }

        /*
        public virtual async Task CreateNotificationRequestAsync(string notificationTemplateKey, TKey userId, DaNotificationRecipientInfo recipient, List<DaNotificationVariableInfo> notificationVariables)
        {
            await CreateNotificationRequestAsync(notificationTemplateKey, userId, new List<DaNotificationRecipientInfo>() { recipient }, notificationVariables);
        }

        public virtual async Task CreateNotificationRequestAsync(string notificationTemplateKey, TKey userId, List<DaNotificationRecipientInfo> recipients, List<DaNotificationVariableInfo> notificationVariables)
        {
            if(string.IsNullOrEmpty(notificationTemplateKey))
            {
                throw new ArgumentNullException(nameof(notificationTemplateKey));
            }

            if(recipients == null)
            {
                throw new ArgumentNullException(nameof(recipients));
            }

            var notificationTemplate = await _notificationTemplateManager.FindByNameAsync(notificationTemplateKey);

            if(notificationTemplate == null)
            {
                throw new DaNotFoundException($"Notification template key {notificationTemplateKey} not found.");
            }

            var notificationRequest = new TNotificationEvent()
            {
                NotificationEventDefinitionId = notificationTemplate.Id,
                 Level = DaNotificationLevel.Info,
                IsProcessingComplete = false,
                FailureMessage = null,
                CreatedBy = userId,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = userId,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            notificationRequest.Channels = new List<TNotificationEventChannel>();

            foreach(var notificationChannelTemplate in notificationTemplate.Channels)
            {
                notificationRequest.Channels.Add(new TNotificationEventChannel()
                {
                    Body = notificationChannelTemplate.Body,
                    Channel = notificationChannelTemplate.Channel,
                    Format = notificationChannelTemplate.Format,
                    NotificationEventDefinitionChannelId = notificationChannelTemplate.Id,
                    Subject = notificationChannelTemplate.Subject,
                    NotificationEvent = notificationRequest,
                    CreatedBy = userId,
                    CreatedDateUtc = DateTime.UtcNow,
                    LastUpdatedBy = userId,
                    LastUpdatedDateUtc = DateTime.UtcNow
                });
            }

            if (notificationVariables != null)
            {
                notificationRequest.Variables = new List<TNotificationEventVariable>();

                foreach (var variable in notificationVariables)
                {
                    notificationRequest.Variables.Add(new TNotificationEventVariable()
                    {
                        ForNotification = variable.ForNotification,
                        Title = variable.Title,
                        Value = variable.Value,
                        NotificationEvent = notificationRequest,
                        ForSubject = variable.ForSubject
                    });
                }
            }

            notificationRequest.Subscribers = new List<TNotificationEvent>();

            foreach (var recipientInfo in recipients)
            {
                var recipient = new TNotificationEvent()
                {
                    NotificationEvent = notificationRequest,
                    SubscriberAddress = recipientInfo.To,
                    SubscriberName = recipientInfo.DisplayName,
                    IsNotificationCreated = DaNotificationStatus.New,
                    Variables = new List<TNotificationEventSubscriberVariable>()
                };

                if (recipientInfo.Variables != null)
                {
                    foreach (var variable in recipientInfo.Variables)
                    {
                        recipient.Variables.Add(new TNotificationEventSubscriberVariable()
                        {
                            ForNotification = variable.ForNotification,
                            Title = variable.Title,
                            ForSubject = variable.ForSubject,
                            Value = variable.Value,
                            NotificationEventSubscriber = recipient
                        });
                    }
                }

                notificationRequest.Subscribers.Add(recipient);
            }

            await _notificationManager.CreateAsync(notificationRequest);
        }

        public virtual void CreateNotificationRequest(string key, TKey userId, DaNotificationRecipientInfo recipient, List<DaNotificationVariableInfo> variables)
        {
            DaAsyncHelper.RunSync(() => CreateNotificationRequestAsync(key, userId, recipient, variables));
        }

        public virtual void CreateNotificationRequest(string key, TKey userId, List<DaNotificationRecipientInfo> recipients, List<DaNotificationVariableInfo> variables)
        {
            DaAsyncHelper.RunSync(() => CreateNotificationRequestAsync(key, userId, recipients, variables));
        }

        public async Task<DaNotificationProcessingResult> CreateNotificationsAsync(int processCount = 100)
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

            var  notificationRequests = await _notificationManager.NotificationEvents
                    .Include(m => m.Channels)
                    .Include(m => m.Variables)
                    .Include(m => m.Subscribers)
                    .ThenInclude(m => m.Variables)
                    .Where(m => m.IsProcessingComplete == false)
                    .Take(processCount)
                    .ToListAsync();

            if (notificationRequests == null)
            {
                return result;
            }

            foreach (var notificationRequest in notificationRequests)
            {
                result.ProcessingCount = result.ProcessingCount + 1;

                foreach(var channel in notificationRequest.Channels)
                {
                    foreach (var recipient in notificationRequest.Subscribers)
                    {
                        var notification = new TNotification()
                        {
                            Body = channel.Body,
                            Channel = channel.Channel,
                            CreatedDateUtc = DateTime.UtcNow,
                            DeliveryDateUtc = null,
                            FailureMessage = null,
                            Format = channel.Format,
                            LastUpdatedDateUtc = DateTime.UtcNow,
                            Level = notificationRequest.Level,
                            NotificationEventId = notificationRequest.Id,
                            Subject = channel.Subject,
                            IsNotificationCreated = DaNotificationStatus.New
                        };
                    }
                }

                if (notificationRequest.NotificationEventDefinitionId != null)
                {
                    notificationTemplate = notificationTemplates.Where(m => m.Id.Equals(notificationRequest.NotificationEventDefinitionId)).SingleOrDefault();

                    if (notificationTemplate == null)
                    {
                        notificationRequest.FailureMessage = "Invalid notification template.";

                        notificationRequest.SubscribersCount = notificationRequest.SubscribersCount + 1;
                        result.NotificationFailureCount = result.NotificationFailureCount + 1;
                        await _notificationManager.UpdateAsync(notificationRequest);
                        continue;
                    }
                }

                var from = mailSender.Settings.DefaultSenderEmail;

                if (notificationTemplate != null)
                {
                    if (!string.IsNullOrEmpty(notificationTemplate.FromAddress))
                    {
                        from = notificationTemplate.FromAddress;
                    }
                }

                foreach (var recipient in notificationRequest.Subscribers)
                {
                    notificationRequest.SubscribersProcessedCount = notificationRequest.SubscribersProcessedCount + 1;

                    // await mailSender.SendAsync(recipient.SubscriberAddress, from, notificationRequest.Subject, notificationRequest.Body);
                    recipient.IsNotificationCreated = DaNotificationStatus.Delivered;
                }
            }

            return result;
        }

        public DaNotificationProcessingResult ProcessNotifications(DaMailSettings settings, int processCount = 100, DaProcessNotificationsFlag flag = DaProcessNotificationsFlag.New)
        {
            return DaAsyncHelper.RunSync(() => ProcessEmailNotificationsAsync(settings, processCount, flag));
        }

        public async Task<DaNotificationProcessingResult> ProcessEmailNotificationsAsync(DaMailSettings settings, int processCount = 100, DaProcessNotificationsFlag flag = DaProcessNotificationsFlag.New)
        {
            if(processCount > 1000)
            {
                throw new InvalidOperationException("Process count cannot exceed 10000.");
            }

            if(processCount < 1)
            {
                throw new InvalidOperationException("Process count cannot be less than 1.");
            }

            DaNotificationStatus? status = null;
            
            if(flag == DaProcessNotificationsFlag.New)
            {
                status = DaNotificationStatus.New;
            }
            else if(flag == DaProcessNotificationsFlag.Failed)
            {
                status = DaNotificationStatus.Failed;
            }

            List<TNotificationEvent> notifications = null;

            var result = new DaNotificationProcessingResult();

            if (status != null)
            {
                notifications = await _notificationManager.NotificationEvents
                    .Include(m => m.Channels)
                    .Include(m => m.Variables)
                    .Include(m => m.Subscribers)
                    .ThenInclude(m => m.Variables)
                    .Where(m => m.IsProcessingComplete == false && m.SubscribersCount < m.SubscribersProcessedCount)
                    .Take(processCount)
                    .ToListAsync();
            }
            else
            {
                notifications = await _notificationManager.NotificationEvents
                    .Include(m => m.Channels)
                    .Include(m => m.Variables)
                    .Include(m => m.Subscribers)
                    .ThenInclude(m => m.Variables)
                    .Take(processCount)
                    .Where(m => (m.IsProcessingComplete == false) && m.SubscribersCount < m.SubscribersProcessedCount).ToListAsync();
            }

            if (notifications == null)
            {
                return result;
            }

            var notificationTemplates = await _notificationTemplateManager.FindByUserIdAsync();
            var mailSender = new DaSendGridMailProvider(settings);
           
            foreach (var notification in notifications)
            {
                TNotificationSubscription notificationTemplate = null;
                result.ProcessingCount = result.ProcessingCount + 1;

                if (notification.NotificationEventDefinitionId != null)
                {
                    notificationTemplate = notificationTemplates.Where(m => m.Id.Equals(notification.NotificationEventDefinitionId)).SingleOrDefault();

                    if(notificationTemplate == null)
                    {
                        notification.FailureMessage = "Invalid notification template.";
                        
                        notification.SubscribersCount = notification.SubscribersCount + 1;
                        result.NotificationFailureCount = result.NotificationFailureCount + 1;
                        await _notificationManager.UpdateAsync(notification);
                        continue;
                    }
                }

                var from = mailSender.Settings.DefaultSenderEmail;

                if(notificationTemplate != null)
                {
                    if (!string.IsNullOrEmpty(notificationTemplate.FromAddress))
                    {
                        from = notificationTemplate.FromAddress;
                    }
                }

                foreach(var recipient in notification.Subscribers)
                {
                    notification.SubscribersProcessedCount = notification.SubscribersProcessedCount + 1;

                    // await mailSender.SendAsync(recipient.SubscriberAddress, from, notificationRequest.Subject, notificationRequest.Body);
                    recipient.IsNotificationCreated = DaNotificationStatus.Delivered;
                }
            }

            return result;
        }
        */
    }

    public class DaNotificationProcessingResult
    {
        public long ProcessingCount { get; set; }
        public long SentCount { get; set; }
        public int RecipientCount { get; set; }
        public long NotificationFailureCount { get; set; }
        public long RecipientFailureCount { get; set; }
    }

    public class DaNotificationRecipientInfo
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

    public enum DaProcessNotificationsFlag
    {
        New = 0,
        Failed = 1,
        All = 10
    }
}
