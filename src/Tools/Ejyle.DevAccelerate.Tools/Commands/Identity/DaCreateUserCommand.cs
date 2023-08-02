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
using Ejyle.DevAccelerate.Identity;

namespace Ejyle.DevAccelerate.Tools.Commands.Identity
{
    [Verb("createuser", HelpText = "Creates a DevAccelerate user.")]
    public class DaCreateUserCommand : DaDatabaseCommand
    {
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

            var services = new DaIdentityServiceConfiguration().CreateAndConfigureIdentity(GetConnectionString());
            services.AddScoped<IDaUserService, DaUserService>();
            
            var provider = services.BuildServiceProvider();

            var userService = provider.GetService<IDaUserService>();   
            var result = userService.Create(Username, Email, Password);

            if (result.Succeeded)
            {
                Console.WriteLine($"User {Username} created.");
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
