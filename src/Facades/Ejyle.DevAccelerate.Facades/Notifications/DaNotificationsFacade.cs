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
using Ejyle.DevAccelerate.Notifications.Requests;
using Ejyle.DevAccelerate.Notifications.Templates;
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
    public class DaNotificationsFacade : DaNotificationsFacade<string, DaNotificationManager, DaNotification, DaNotificationRequestManager, DaNotificationRequest, DaNotificationRequestChannel, DaNotificationRequestVariable, DaNotificationRequestRecipient, DaNotificationRequestRecipientVariable, DaNotificationTemplateManager, DaNotificationTemplate, DaNotificationChannelTemplate>
    {
        public DaNotificationsFacade(DaNotificationRequestManager notificationManager, DaNotificationTemplateManager notificationTemplateManager)
            : base(notificationManager, notificationTemplateManager)
        {
        }
    }

    public class DaNotificationsFacade<TKey, TNotificationManager, TNotification, TNotificationRequestManager, TNotificationRequest, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient, TNotificationRequestRecipientVariable, TNotificationTemplateManager, TNotificationTemplate, TNotificationChannelTemplate>
        where TKey : IEquatable<TKey>
        where TNotificationManager : DaNotificationManager<TKey, TNotification>
        where TNotification : DaNotification<TKey>
        where TNotificationRequestManager : DaNotificationRequestManager<TKey, TNotificationRequest>
        where TNotificationRequest : DaNotificationRequest<TKey, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient>, new ()
        where TNotificationRequestChannel : DaNotificationRequestChannel<TKey, TNotificationRequest>
        where TNotificationRequestVariable : DaNotificationRequestVariable<TKey, TNotificationRequest>, new()
        where TNotificationRequestRecipientVariable : DaNotificationRequestRecipientVariable<TKey, TNotificationRequestRecipient>, new()
        where TNotificationRequestRecipient : DaNotificationRequestRecipient<TKey, TNotificationRequest, TNotificationRequestRecipientVariable>, new ()
        where TNotificationTemplateManager : DaNotificationTemplateManager<TKey, TNotificationTemplate>
        where TNotificationTemplate : DaNotificationTemplate<TKey, TNotificationChannelTemplate>
        where TNotificationChannelTemplate : DaNotificationChannelTemplate<TKey, TNotificationTemplate>
    {
        private TNotificationRequestManager _notificationManager;
        private TNotificationTemplateManager _notificationTemplateManager;

        public DaNotificationsFacade(TNotificationRequestManager notificationManager, TNotificationTemplateManager notificationTemplateManager)
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

        public virtual async Task CreateNotificationAsync(string notificationTemplateKey, TKey userId, List<DaNotificationRecipientInfo> recipients, List<DaNotificationVariableInfo> notificationVariables)
        {
            if(string.IsNullOrEmpty(notificationTemplateKey))
            {
                throw new ArgumentNullException(nameof(notificationTemplateKey));
            }

            if(recipients == null)
            {
                throw new ArgumentNullException(nameof(recipients));
            }

            var notificationTemplate = await _notificationTemplateManager.FindByKeyAsync(notificationTemplateKey);

            if(notificationTemplate == null)
            {
                throw new DaNotFoundException($"Notification template key {notificationTemplateKey} not found.");
            }

            var notification = new TNotificationRequest()
            {
                NotificationTemplateId = notificationTemplate.Id,
                IsProcessingComplete = false,
                FailureMessage = null,
                CreatedBy = userId,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = userId,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            if (notificationVariables != null)
            {
                notification.Variables = new List<TNotificationRequestVariable>();

                foreach (var variable in notificationVariables)
                {
                    notification.Variables.Add(new TNotificationRequestVariable()
                    {
                        ForNotification = variable.ForNotification,
                        Name = variable.Name,
                        Value = variable.Value,
                        NotificationRequest = notification,
                        ForSubject = variable.ForSubject
                    });
                }
            }

            notification.Recipients = new List<TNotificationRequestRecipient>();

            foreach (var recipientInfo in recipients)
            {
                var recipient = new TNotificationRequestRecipient()
                {
                    NotificationRequest = notification,
                    RecipientAddress = recipientInfo.To,
                    RecipientName = recipientInfo.DisplayName,
                    Status = DaNotificationStatus.New,
                    Variables = new List<TNotificationRequestRecipientVariable>()
                };

                if (recipientInfo.Variables != null)
                {
                    foreach (var variable in recipientInfo.Variables)
                    {
                        recipient.Variables.Add(new TNotificationRequestRecipientVariable()
                        {
                            ForNotification = variable.ForNotification,
                            Name = variable.Name,
                            ForSubject = variable.ForSubject,
                            Value = variable.Value,
                            NotificationRequestRecipient = recipient
                        });
                    }
                }

                notification.Recipients.Add(recipient);
            }

            await _notificationManager.CreateAsync(notification);
        }

        public virtual void CreateNotification(string key, TKey userId, List<DaNotificationRecipientInfo> recipients, List<DaNotificationVariableInfo> variables)
        {
            DaAsyncHelper.RunSync(() => CreateNotificationAsync(key, userId, recipients, variables));
        }

        public DaNotificationProcessingResult ProcessNotifications(DaMailSettings settings, int processCount = 100, DaProcessNotificationsFlag flag = DaProcessNotificationsFlag.New)
        {
            return DaAsyncHelper.RunSync(() => ProcessNotificationsAsync(settings, processCount, flag));
        }

        public async Task<DaNotificationProcessingResult> ProcessNotificationsAsync(DaMailSettings settings, int processCount = 100, DaProcessNotificationsFlag flag = DaProcessNotificationsFlag.New)
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

            List<TNotificationRequest> notifications = null;

            var result = new DaNotificationProcessingResult();

            if (status != null)
            {
                notifications = await _notificationManager.NotificationRequests
                    .Include(m => m.Channels)
                    .Include(m => m.Variables)
                    .Include(m => m.Recipients)
                    .ThenInclude(m => m.Variables)
                    .Where(m => m.IsProcessingComplete == false && m.RecipientsCount < m.RecipientsProcessedCount)
                    .Take(processCount)
                    .ToListAsync();
            }
            else
            {
                notifications = await _notificationManager.NotificationRequests
                    .Include(m => m.Channels)
                    .Include(m => m.Variables)
                    .Include(m => m.Recipients)
                    .ThenInclude(m => m.Variables)
                    .Take(processCount)
                    .Where(m => (m.IsProcessingComplete == false) && m.RecipientsCount < m.RecipientsProcessedCount).ToListAsync();
            }

            if (notifications == null)
            {
                return result;
            }

            var notificationTemplates = await _notificationTemplateManager.FindAllAsync();
            var mailSender = new DaSendGridMailProvider(settings);
           
            foreach (var notification in notifications)
            {
                TNotificationTemplate notificationTemplate = null;
                result.ProcessingCount = result.ProcessingCount + 1;

                if (notification.NotificationTemplateId != null)
                {
                    notificationTemplate = notificationTemplates.Where(m => m.Id.Equals(notification.NotificationTemplateId)).SingleOrDefault();

                    if(notificationTemplate == null)
                    {
                        notification.FailureMessage = "Invalid notification template.";
                        
                        notification.RecipientsCount = notification.RecipientsCount + 1;
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

                foreach(var recipient in notification.Recipients)
                {
                    notification.RecipientsProcessedCount = notification.RecipientsProcessedCount + 1;

                    // await mailSender.SendAsync(recipient.RecipientAddress, from, notification.Subject, notification.Body);
                    recipient.Status = DaNotificationStatus.Delivered;
                }
            }

            return result;
        }
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
