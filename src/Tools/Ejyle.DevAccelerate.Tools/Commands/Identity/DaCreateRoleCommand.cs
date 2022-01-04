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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Tools.Commands.Identity
{
    [Verb("createrole", HelpText = "Creates a DevAccelerate role.")]
    public class DaCreateRoleCommand : DaDatabaseCommand
    {
        [Option('r', "role", Required = true, HelpText = "Name of the new role to be created.")]
        public string Role
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            var services = new DaIdentityServiceConfiguration().CreateAndConfigureIdentity(ConnectionString);
            services.AddScoped<IDaRoleService, RoleCreationService>();

            var provider = services.BuildServiceProvider();
            var roleService = provider.GetService<IDaRoleService>();
            var result = roleService.Create(Role);

            if (result.Succeeded)
            {
                Console.WriteLine($"Created the {Role} role.");
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
            IdentityResult Create(string roleName);
        }

        private class RoleCreationService : IDaRoleService
        {
            private readonly RoleManager<DaRole> roleManager;

            public RoleCreationService(RoleManager<DaRole> roleManager)
            {
                this.roleManager = roleManager;
            }

            public IdentityResult Create(string roleName)
            {
                var role = DaAsyncHelper.RunSync<DaRole>(() => roleManager.FindByNameAsync(roleName));

                if (role != null)
                {
                    throw new Exception($"Role {roleName} already exists.");
                }

                role = new DaRole();
                role.Name = roleName;

                return DaAsyncHelper.RunSync<IdentityResult>(() => roleManager.CreateAsync(role));
            }
        }
    }
}
