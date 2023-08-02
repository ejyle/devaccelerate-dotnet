// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using CommandLine;
using Ejyle.DevAccelerate.MultiTenancy.EF;
using Ejyle.DevAccelerate.MultiTenancy.EF.Tenants;
using Ejyle.DevAccelerate.MultiTenancy.Tenants;
using Ejyle.DevAccelerate.Tools.Commands.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Ejyle.DevAccelerate.Tools.Commands.MultiTenancy
{
    [Verb("adduser", HelpText = "Creates a new user and adds the user to a tenant.")]
    public class DaAddUserToTenantCommand : DaDatabaseCommand
    {
        [Option('i', "id", Required = true, HelpText = "ID of the tenant.")]
        public string TenantId
        {
            get;
            set;
        }

        [Option('u', "username", Required = true, HelpText = "Username for the new user to be created.")]
        public string Username
        {
            get;
            set;
        }

        [Option('p', "password", Required = true, HelpText = "Password for the new user to be created.")]
        public string Password
        {
            get;
            set;
        }

        [Option('e', "email", Required = true, HelpText = "Email for the new user to be created.")]
        public string Email
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaMultiTenancyDbContext(GetConnectionString()))
            {
                if (string.IsNullOrEmpty(TenantId))
                {
                    throw new Exception("Tenant ID is required.");
                }

                var tenantManager = new DaTenantManager(new DaTenantRepository(context));

                var tenant = tenantManager.FindById(TenantId);

                if (tenant == null)
                {
                    throw new Exception("Invalid tenant ID.");
                }

                var userCreationCmd = new DaCreateUserCommand()
                {
                    Email = Email,
                    Password = Password,
                    Username = TenantId
                };

                try
                {
                    userCreationCmd.Execute();

                    var services = new DaIdentityServiceConfiguration().CreateAndConfigureIdentity(GetConnectionString());
                    services.AddScoped<IDaUserService, DaUserService>();

                    var provider = services.BuildServiceProvider();

                    var userService = provider.GetService<IDaUserService>();
                    var tenantUser = userService.GetUser(Username);

                    if (tenantUser == null)
                    {
                        throw new Exception("Tenant user is not created.");
                    }

                    tenant.TenantUsers.Add(new DaTenantUser()
                    {
                        Tenant = tenant,
                        UserId = tenantUser.Id,
                        IsActive = true
                    });

                    tenantManager.Update(tenant);
                    Console.WriteLine($"User created and added to the tenant successfully.");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
