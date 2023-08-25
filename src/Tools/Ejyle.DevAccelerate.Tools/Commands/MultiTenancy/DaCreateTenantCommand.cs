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
    [Verb("createtenant", HelpText = "Creates a tenant.")]
    public class DaCreateTenantCommand : DaDatabaseCommand
    {
        [Option('n', "name", Required = true, HelpText = "Name of the tenant.")]
        public string Name
        {
            get;
            set;
        }

        [Option('m', "mtpname", Required = false, HelpText = "Name of the MTP with which tenant will be associated with.")]
        public string MTPName
        {
            get;
            set;
        }

        [Option('t', "ismtp", Required = false, HelpText = "Specifies if the tenant is an MTP.")]
        public bool IsMTP
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

            Console.WriteLine("Creating a tenant...");

            using (var context = new DaMultiTenancyDbContext(GetConnectionString()))
            {
                if(string.IsNullOrEmpty(Name)) {
                    throw new Exception("Tenant name is required.");
                }

                var tenantManager = new DaTenantManager(new DaTenantRepository(context));

                DaTenant mtpTenant = null;

                if(!string.IsNullOrEmpty(MTPName))
                {
                    mtpTenant = tenantManager.FindByName(MTPName);

                    if(mtpTenant == null || mtpTenant.MTPStatus != DaTenantMTPStatus.IsMTP)
                    {
                        throw new Exception("Invalid MTP name.");
                    }
                }

                var userCreationCmd = new DaCreateUserCommand()
                {
                    Email = Email,
                    Password = Password,
                    Username = Username
                };

                var addUserToRoleCmd = new DaAddUserToRolesCommand()
                {
                    Role = "TENANT_ADMIN, TENANT_USER",
                    Username = Username
                };

                try
                {
                    userCreationCmd.Execute();

                    if(mtpTenant == null && IsMTP == true)
                    {
                        addUserToRoleCmd.Role = $"{addUserToRoleCmd.Role}, MTP_ADMIN";
                    }

                    addUserToRoleCmd.Execute();

                    var services = new DaIdentityServiceConfiguration().CreateAndConfigureIdentity(GetConnectionString());
                    services.AddScoped<IDaUserService, DaUserService>();

                    var provider = services.BuildServiceProvider();

                    var userService = provider.GetService<IDaUserService>();
                    var tenantUser = userService.GetUser(Username);

                    if(tenantUser == null)
                    {
                        throw new Exception("Tenant user is not created.");
                    }

                    var systemUser = userService.GetSystemUser();

                    if (systemUser == null)
                    {
                        throw new Exception("System user is not found.");
                    }

                    var tenant = new DaTenant()
                    {
                        Name = Name,
                        FriendlyName = Name,
                        BillingEmail = null,
                        Country = null,
                        Currency = null,
                        DateFormat = null,
                        IsSystemTenant = false,
                        OwnerUserId = tenantUser.Id,
                        Status = DaTenantStatus.Active,
                        SystemLanguage = null,
                        TenantType = DaTenantType.Organization,
                        TimeZone = null,
                        CreatedBy = systemUser.Id,
                        CreatedDateUtc = DateTime.UtcNow,
                        LastUpdatedBy = systemUser.Id,
                        LastUpdatedDateUtc = DateTime.UtcNow
                    };

                    if (mtpTenant != null)
                    {
                        tenant.MTPManagedTenants.Add(new DaMTPTenant()
                        {
                            MTPManagedTenant = tenant,
                            MTPTenant = mtpTenant,
                            MTPTenantId = mtpTenant.Id,
                            IsActive = true,
                            CreatedBy = systemUser.Id,
                            CreatedDateUtc = DateTime.UtcNow,
                            LastUpdatedBy = systemUser.Id,
                            LastUpdatedDateUtc = DateTime.UtcNow
                        });
                        tenant.MTPStatus = DaTenantMTPStatus.IsMTPManaged;
                    }
                    else if (IsMTP == true)
                    {
                        tenant.MTPStatus = DaTenantMTPStatus.IsMTP;
                    }
                    else
                    {
                        tenant.MTPStatus = DaTenantMTPStatus.None;
                    }

                    tenant.TenantUsers.Add(new DaTenantUser()
                    {
                        Tenant = tenant,
                        UserId = tenantUser.Id,
                        IsActive = true
                    });

                    tenantManager.Create(tenant);
                    Console.WriteLine($"Tenant created.");
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }
    }
}
