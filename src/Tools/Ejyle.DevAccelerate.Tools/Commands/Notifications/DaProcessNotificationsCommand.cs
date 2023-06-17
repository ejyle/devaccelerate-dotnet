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
using Ejyle.DevAccelerate.Notifications.EF;
using Ejyle.DevAccelerate.Notifications;
using Ejyle.DevAccelerate.Facades.Notifications;
using Ejyle.DevAccelerate.Mail;
using Ejyle.DevAccelerate.Notifications.EF.Events;
using Ejyle.DevAccelerate.Notifications.EF.EventDefinitions;

namespace Ejyle.DevAccelerate.Tools.Commands.Notifications
{
    [Verb("processnotifications", HelpText = "Process and send notificaitons.")]
    public class DaProcessNotificationsCommand : DaDatabaseCommand
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

            using (var context = new DaNotificationsDbContext(GetConnectionString()))
            {
                var settings = new DaMailSettings()
                {
                    DefaultSenderEmail = Sender,
                    SmtpSettings = new DaSmtpSettings()
                    {
                        ApiKey = ApiKey
                    }
                };

                var messagesService = new DaNotificationsFacade(new DaNotificationEventManager(new DaNotificationEventRepository(context)), new DaNotificationEventDefinitionManager(new DaNotificationEventDefinitionRepository(context)));
                // messagesService.ProcessNotifications(settings, 1000, DaProcessNotificationsFlag.New);

                Console.WriteLine($"{0} notifications processed.");
            }
        }
    }
}
