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
    [Verb("addusertorole", HelpText = "Add DevAccelerate user to a role.")]
    public class DaAddUserToRoleCommand : DaDatabaseCommand
    {
        [Option('u', "username", Required = true, HelpText = "Username of the user.")]
        public string Username
        {
            get;
            set;
        }

        [Option('r', "role", Required = true, HelpText = "Name of the role.")]
        public string Role
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            var services = new DaIdentityServiceConfiguration().CreateAndConfigureIdentity(ConnectionString);
            services.AddScoped<IDaRoleService, DaRoleService>();
            
            var provider = services.BuildServiceProvider();

            var userService = provider.GetService<IDaRoleService>();   
            var result = userService.AddToRole(Username, Role);

            if (result.Succeeded)
            {
                Console.WriteLine($"User {Username} added to the {Role} role.");
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

        private interface IDaRoleService
        {
            IdentityResult AddToRole(string userName, string role);
        }

        private class DaRoleService : IDaRoleService
        {
            private readonly UserManager<DaUser> userManager;

            public DaRoleService(UserManager<DaUser> userManager)
            {
                this.userManager = userManager;
            }

            public IdentityResult AddToRole(string userName, string role)
            {
                var user = DaAsyncHelper.RunSync<DaUser>(() => this.userManager.FindByNameAsync(userName));

                if (user == null)
                {
                    throw new Exception($"Username {userName} doesn't exist.");
                }

                return DaAsyncHelper.RunSync<IdentityResult>(() => this.userManager.AddToRoleAsync(user, role));
            }
        }
    }
}
