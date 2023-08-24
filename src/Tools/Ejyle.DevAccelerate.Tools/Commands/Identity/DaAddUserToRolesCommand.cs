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

namespace Ejyle.DevAccelerate.Tools.Commands.Identity
{
    [Verb("addusertoroles", HelpText = "Adds a DevAccelerate user to one or more roles.")]
    public class DaAddUserToRolesCommand : DaDatabaseCommand
    {
        [Option('u', "username", Required = true, HelpText = "Username of the user.")]
        public string Username
        {
            get;
            set;
        }

        [Option('r', "role", Required = true, HelpText = "Comma-separated list of roles")]
        public string Role
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            var services = new DaIdentityServiceConfiguration().CreateAndConfigureIdentity(GetConnectionString());
            services.AddScoped<IDaRoleService, DaRoleService>();
            
            var provider = services.BuildServiceProvider();

            var userService = provider.GetService<IDaRoleService>();

            string[] roles = Role.Split(",");

            for(int i = 0; i < roles.Length; i++)
            {
                roles[i] = roles[i].Trim();
            }

            var result = userService.AddToRoles(Username, roles);

            if (result.Succeeded)
            {
                Console.WriteLine($"User {Username} added to the roles.");
            }
            else
            {
                var errorMessage = String.Empty;

                if (result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var err in result.Errors)
                    {
                        errorMessage = errorMessage + err.Description + "\n";
                    }
                }

                throw new Exception(errorMessage);
            }
        }
    }
}
