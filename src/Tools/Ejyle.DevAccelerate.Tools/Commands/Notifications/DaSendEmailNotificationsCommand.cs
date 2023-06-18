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
using Ejyle.DevAccelerate.Notifications.SendGrid;
using Ejyle.DevAccelerate.Mail;
using Ejyle.DevAccelerate.Notifications.EF.Events;
using Ejyle.DevAccelerate.Notifications.EF.EventDefinitions;

namespace Ejyle.DevAccelerate.Tools.Commands.Notifications
{
    [Verb("sendemailnotifications", HelpText = "Send email notifications.")]
    public class DaSendEmailNotificationsCommand : DaDatabaseCommand
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

        public override async void Execute()
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

                var notificationsService = new DaNotificationsService(context);
                var count =  await notificationsService.SendEmailsAsync(settings);

                Console.WriteLine($"{count} email notifications processed and sent.");
            }
        }
    }
}
