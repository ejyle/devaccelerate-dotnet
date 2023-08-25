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
using Ejyle.DevAccelerate.Identity;

namespace Ejyle.DevAccelerate.Tools.Commands.Identity
{
    [Verb("createroles", HelpText = "Creates one or more DevAccelerate roles.")]
    public class DaCreateRolesCommand : DaDatabaseCommand
    {
        [Option('r', "roles", Required = true, HelpText = "Comma-separated list of roles to be created.")]
        public string Role
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            Console.WriteLine("Creating roles...");

            var services = new DaIdentityServiceConfiguration().CreateAndConfigureIdentity(GetConnectionString());
            services.AddScoped<IDaRoleService, RoleCreationService>();

            var provider = services.BuildServiceProvider();
            var roleService = provider.GetService<IDaRoleService>();

            string[] roles = Role.Split(",");

            for (int i = 0; i < roles.Length; i++)
            {
                roles[i] = roles[i].Trim();
            }

            var resultList = roleService.Create(roles);

            foreach (var result in resultList)
            {
                if (result.Succeeded)
                {
                    Console.WriteLine($"Created the roles.");
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

        private interface IDaRoleService
        {
            List<IdentityResult> Create(string[] roleNames);
        }

        private class RoleCreationService : IDaRoleService
        {
            private readonly RoleManager<DaRole> roleManager;

            public RoleCreationService(RoleManager<DaRole> roleManager)
            {
                this.roleManager = roleManager;
            }

            public List<IdentityResult> Create(string[] roleNames)
            {
                var results = new List<IdentityResult>();

                foreach (var roleName in roleNames)
                {
                    var role = DaAsyncHelper.RunSync<DaRole>(() => roleManager.FindByNameAsync(roleName));

                    if (role != null)
                    {
                        throw new Exception($"Role {roleName} already exists.");
                    }

                    role = new DaRole();
                    role.Name = roleName;
                    role.FriendlyName = roleName;
                    role.RoleType = DaRoleType.SystemRole;

                    results.Add(DaAsyncHelper.RunSync<IdentityResult>(() => roleManager.CreateAsync(role)));
                }

                return results;
            }
        }
    }
}
