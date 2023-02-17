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
using Ejyle.DevAccelerate.Facades.Messages;

namespace Ejyle.DevAccelerate.Tools.Commands.Messages
{
    [Verb("processmessages", HelpText = "Process messages and send them if required.")]
    public class DaProcessMessagesCommand : DaDatabaseCommand
    {
        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaMessagesDbContext(GetConnectionString()))
            {
                var messagesService = new DaMessagesFacade(new DaMessageManager(new DaMessageRepository(context)), new DaMessageTemplateManager(new DaMessageTemplateRepository(context)));
                messagesService.ProcessMessagesAsync(null, 1000, DaProcessMessagesFlag.New);

                Console.WriteLine($"{0} messages processed.");
            }
        }
    }
}
