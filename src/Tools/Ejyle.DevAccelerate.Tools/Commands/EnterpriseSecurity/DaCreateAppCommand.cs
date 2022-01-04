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
using Ejyle.DevAccelerate.EnterpriseSecurity.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;

namespace Ejyle.DevAccelerate.Tools.Commands.EnterpriseSecurity
{
    [Verb("createapp", HelpText = "Creates a DevAccelerate app.")]
    public class DaCreateAppCommand : DaDatabaseCommand
    {
        [Option('n', "name", Required = true, HelpText = "Name of the new app to be created.")]
        public string Name
        {
            get;
            set;
        }

        [Option('d', "desc", Required = false, HelpText = "Description of the new app to be created.")]
        public string Description
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaEnterpriseSecurityDbContext(ConnectionString))
            {
                var appManager = new DaAppManager(new DaAppRepository(context));
                var app = new DaApp()
                {
                    Name = Name,
                    Status = DaAppStatus.Active,
                    Description = Description
                };

                appManager.Create(app);

                Console.WriteLine($"App created. The key is {app.Key}");
            }
        }
    }
}
