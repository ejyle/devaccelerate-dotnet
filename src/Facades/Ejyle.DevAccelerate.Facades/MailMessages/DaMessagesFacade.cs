// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Mail;
using Ejyle.DevAccelerate.Mail.SendGrid;
using Ejyle.DevAccelerate.Messages;
using Ejyle.DevAccelerate.Messages.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Facades.MailMessages
{
    public class DaMessagesFacade : DaMessagesFacade<string, DaMessageManager, DaMessage, DaMessageVariable, DaMessageRecipient, DaMessageRecipientVariable, DaMessageTemplateManager, DaMessageTemplate>
    {
        public DaMessagesFacade(DaMessageManager messageManager, DaMessageTemplateManager messageTemplateManager)
            : base(messageManager, messageTemplateManager)
        {
        }
    }

    public class DaMessagesFacade<TKey, TMessageManager, TMessage, TMessageVariable, TMessageRecipient, TMessageRecipientVariable, TMessageTemplateManager, TMessageTemplate>
        where TKey : IEquatable<TKey>
        where TMessageManager : DaMessageManager<TKey, TMessage>
        where TMessage : DaMessage<TKey, TMessageVariable, TMessageRecipient>, new ()
        where TMessageVariable : DaMessageVariable<TKey, TMessage>, new()
        where TMessageRecipientVariable : DaMessageRecipientVariable<TKey, TMessageRecipient>, new()
        where TMessageRecipient : DaMessageRecipient<TKey, TMessage, TMessageRecipientVariable>, new ()
        where TMessageTemplateManager : DaMessageTemplateManager<TKey, TMessageTemplate>
        where TMessageTemplate : DaMessageTemplate<TKey>
    {
        private TMessageManager _messageManager;
        private TMessageTemplateManager _messageTemplateManager;

        public DaMessagesFacade(TMessageManager messageManager, TMessageTemplateManager messageTemplateManager)
        {
            if (messageManager == null)
            {
                throw new ArgumentNullException(nameof(messageManager));
            }

            if (messageTemplateManager == null)
            {
                throw new ArgumentNullException(nameof(messageTemplateManager));
            }

            _messageManager = messageManager;
            _messageTemplateManager = messageTemplateManager;
        }

        public virtual async Task CreateMessageAsync(string messageTemplateKey, TKey userId, List<DaMessageRecipientInfo> recipients, List<DaMessageVariableInfo> messageVariables)
        {
            if(string.IsNullOrEmpty(messageTemplateKey))
            {
                throw new ArgumentNullException(nameof(messageTemplateKey));
            }

            if(recipients == null)
            {
                throw new ArgumentNullException(nameof(recipients));
            }

            var messageTemplate = await _messageTemplateManager.FindByKeyAsync(messageTemplateKey);

            if(messageTemplate == null)
            {
                throw new DaNotFoundException($"Message template key {messageTemplateKey} not found.");
            }

            var message = new TMessage()
            {
                Category = messageTemplate.Category,
                Format = messageTemplate.Format,
                Message = messageTemplate.Message,
                MessageTemplateId = messageTemplate.Id,
                Status = DaMessageStatus.New,
                Subject = messageTemplate.Subject,
                FailureMessage = null,
                CreatedBy = userId,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = userId,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            if (messageVariables != null)
            {
                message.Variables = new List<TMessageVariable>();

                foreach (var variable in messageVariables)
                {
                    message.Variables.Add(new TMessageVariable()
                    {
                        ForMessage = variable.ForMessage,
                        Name = variable.Name,
                        Value = variable.Value,
                        Message = message,
                        ForSubject = variable.ForSubject
                    });
                }
            }

            message.Recipients = new List<TMessageRecipient>();

            foreach (var recipientInfo in recipients)
            {
                var recipient = new TMessageRecipient()
                {
                    Message = message,
                    RecipientAddress = recipientInfo.To,
                    RecipientName = recipientInfo.DisplayName,
                    Status = DaMessageStatus.New,
                    Variables = new List<TMessageRecipientVariable>()
                };

                if (recipientInfo.Variables != null)
                {
                    foreach (var variable in recipientInfo.Variables)
                    {
                        recipient.Variables.Add(new TMessageRecipientVariable()
                        {
                            ForMessage = variable.ForMessage,
                            Name = variable.Name,
                            ForSubject = variable.ForSubject,
                            Value = variable.Value,
                            MessageRecipient = recipient
                        });
                    }
                }

                message.Recipients.Add(recipient);
            }

            await _messageManager.CreateAsync(message);
        }

        public virtual void CreateMessage(string key, TKey userId, List<DaMessageRecipientInfo> recipients, List<DaMessageVariableInfo> variables)
        {
            DaAsyncHelper.RunSync(() => CreateMessageAsync(key, userId, recipients, variables));
        }

        public DaMessageProcessingResult ProcessMessages(DaMailSettings settings, int processCount = 100, DaProcessMessagesFlag flag = DaProcessMessagesFlag.New)
        {
            return DaAsyncHelper.RunSync(() => ProcessMessagesAsync(settings, processCount, flag));
        }

        public async Task<DaMessageProcessingResult> ProcessMessagesAsync(DaMailSettings settings, int processCount = 100, DaProcessMessagesFlag flag = DaProcessMessagesFlag.New)
        {
            if(processCount > 1000)
            {
                throw new InvalidOperationException("Process count cannot exceed 10000.");
            }

            if(processCount < 1)
            {
                throw new InvalidOperationException("Process count cannot be less than 1.");
            }

            DaMessageStatus? status = null;
            
            if(flag == DaProcessMessagesFlag.New)
            {
                status = DaMessageStatus.New;
            }
            else if(flag == DaProcessMessagesFlag.Failed)
            {
                status = DaMessageStatus.Failed;
            }

            List<TMessage> messages = null;

            var result = new DaMessageProcessingResult();

            if (status != null)
            {
                messages = await _messageManager.Messages
                    .Include(m => m.Variables)
                    .Include(m => m.Recipients)
                    .ThenInclude(m => m.Variables)
                    .Where(m => m.Status == DaMessageStatus.New && m.RecipientsCount < m.RecipientsProcessedCount)
                    .Take(processCount)
                    .ToListAsync();
            }
            else
            {
                messages = await _messageManager.Messages
                    .Include(m => m.Variables)
                    .Include(m => m.Recipients)
                    .ThenInclude(m => m.Variables)
                    .Take(processCount)
                    .Where(m => (m.Status == DaMessageStatus.New || m.Status == DaMessageStatus.Failed) && m.RecipientsCount < m.RecipientsProcessedCount).ToListAsync();
            }

            if (messages == null)
            {
                return result;
            }

            var messageTemplates = await _messageTemplateManager.FindAllAsync();
            var mailSender = new DaSendGridMailProvider(settings);
           
            foreach (var message in messages)
            {
                TMessageTemplate messageTemplate = null;
                result.ProcessingCount = result.ProcessingCount + 1;

                if (message.MessageTemplateId != null)
                {
                    messageTemplate = messageTemplates.Where(m => m.Id.Equals(message.MessageTemplateId)).SingleOrDefault();

                    if(messageTemplate == null)
                    {
                        message.FailureMessage = "Invalid message template.";
                        message.Status= DaMessageStatus.Failed;
                        message.RecipientsCount = message.RecipientsCount + 1;
                        result.MessageFailureCount = result.MessageFailureCount + 1;
                        await _messageManager.UpdateAsync(message);
                        continue;
                    }
                }

                var from = mailSender.Settings.DefaultSenderEmail;

                if(messageTemplate != null)
                {
                    if (!string.IsNullOrEmpty(messageTemplate.FromAddress))
                    {
                        from = messageTemplate.FromAddress;
                    }
                }

                foreach(var recipient in message.Recipients)
                {
                    message.RecipientsProcessedCount = message.RecipientsProcessedCount + 1;

                    await mailSender.SendAsync(recipient.RecipientAddress, from, message.Subject, message.Message);
                    recipient.Status = DaMessageStatus.Completed;
                }
            }

            return result;
        }
    }

    public class DaMessageProcessingResult
    {
        public long ProcessingCount { get; set; }
        public long SentCount { get; set; }
        public int RecipientCount { get; set; }
        public long MessageFailureCount { get; set; }
        public long RecipientFailureCount { get; set; }
    }

    public class DaMessageRecipientInfo
    {
        public string DisplayName { get; set; }
        public string To { get; set; }
        public List<DaMessageVariableInfo> Variables { get; set; }
    }

    public class DaMessageVariableInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForMessage { get; set; }
    }

    public enum DaProcessMessagesFlag
    {
        New = 0,
        Failed = 1,
        All = 10
    }
}
