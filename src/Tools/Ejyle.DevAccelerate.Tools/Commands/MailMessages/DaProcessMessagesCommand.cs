// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.AspNetCore.Identity;
using System;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;
using Ejyle.DevAccelerate.Messages.EF;
using Ejyle.DevAccelerate.Messages;
using Ejyle.DevAccelerate.Facades.MailMessages;
using Ejyle.DevAccelerate.Mail;

namespace Ejyle.DevAccelerate.Tools.Commands.MailMessages
{
    [Verb("processmailmessages", HelpText = "Process and send mail messages.")]
    public class DaProcessMessagesCommand : DaDatabaseCommand
    {
        [Option('s', "sender", Required = false, HelpText = "Email of the sender.")]
        public string Sender
        {
            get;
            set;
        }

        [Option('k', "apikey", Required = true, HelpText = "SendGrid API key.")]
        public string ApiKey
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaMessagesDbContext(GetConnectionString()))
            {
                var settings = new DaMailSettings()
                {
                    DefaultSenderEmail = Sender,
                    SmtpSettings = new DaSmtpSettings()
                    {
                        ApiKey = ApiKey
                    }
                };

                var messagesService = new DaMessagesFacade(new DaMessageManager(new DaMessageRepository(context)), new DaMessageTemplateManager(new DaMessageTemplateRepository(context)));
                messagesService.ProcessMessages(settings, 1000, DaProcessMessagesFlag.New);

                Console.WriteLine($"{0} messages processed.");
            }
        }
    }
}
