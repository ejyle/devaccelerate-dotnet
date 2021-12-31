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

        [Option('n', "name", Required = false, HelpText = "Description of the new app to be created.")]
        public string Description
        {
            get;
            set;
        }

        public override void Execute()
        {
            using (var context = new DaEnterpriseSecurityDbContext(ConnectionString))
            {
                var appManager = new DaAppManager(new DaAppRepository(context));
                var app = appManager.FindByName(Name);

                if (app != null)
                {
                    throw new Exception($"App {Name} already exists.");
                }

                app = new DaApp()
                {
                    Name = Name,
                    Key = Guid.NewGuid().ToString(),
                    Status = DaAppStatus.Active,
                    Description = Description
                };

                appManager.Create(app);
            }
        }
    }
}
