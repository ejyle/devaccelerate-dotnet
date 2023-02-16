// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Messages
{
    public class DaMessagesService<TKey, TMessageManager, TMessage, TMessageVariable, TMessageRecipientVariable, TMessageRecipient, TMessageTemplateManager, TMessageTemplate>
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

        public DaMessagesService(TMessageManager messageManager, TMessageTemplateManager messageTemplateManager)
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

        public virtual async Task CreateMessageAsync(TKey messageTemplateId, TKey userId, List<DaMessageVariableInfo> messageVariables, List<DaMessageRecipientInfo> recipients)
        {
            var messageTemplate = await _messageTemplateManager.FindByIdAsync(messageTemplateId);

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

                foreach(var variable in recipientInfo.Variables)
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

                message.Recipients.Add(recipient);
            }

            await _messageManager.CreateAsync(message);
        }

        public virtual void CreateMessage(TKey messageTemplateId, TKey userId, List<DaMessageVariableInfo> variables, List<DaMessageRecipientInfo> recipients)
        {
            DaAsyncHelper.RunSync(() => CreateMessageAsync(messageTemplateId, userId, variables, recipients));
        }
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
}
