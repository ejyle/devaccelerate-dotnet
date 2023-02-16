// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Messages.EF
{
    public class DaMessagesService : DaMessagesService<string, DaMessageManager, DaMessage, DaMessageVariable, DaMessageRecipient, DaMessageRecipientVariable, DaMessageTemplateManager, DaMessageTemplate>
    {
        public DaMessagesService(DaMessageManager messageManager, DaMessageTemplateManager messageTemplateManager)
            : base(messageManager, messageTemplateManager) { 
        }
    }
}
