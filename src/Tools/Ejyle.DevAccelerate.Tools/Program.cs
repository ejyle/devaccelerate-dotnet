// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using CommandLine;
using Ejyle.DevAccelerate.Tools.Commands;
using Ejyle.DevAccelerate.Tools.Commands.Core;
using Ejyle.DevAccelerate.Tools.Commands.Platform;
using Ejyle.DevAccelerate.Tools.Commands.Files;
using Ejyle.DevAccelerate.Tools.Commands.Identity;
using Ejyle.DevAccelerate.Tools.Commands.Lists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<
                    DaSetConnectionCommand,
                    DaCreateDatabaseCommand,
                    DaCreateObjectTypesCommand,
                    DaCreateAppCommand,
                    DaCreateAppFeatureCommand,
                    DaCreateDefaultListsCommand,
                    DaCreateFileStorageCommand,
                    DaCreateFileStorageLocationCommand,
                    DaCreateUserCommand,
                    DaCreateRolesCommand,
                    DaAddUserToRolesCommand>(args)
                .WithParsed<IDaCommand>(t => t.Execute());
            }
            catch (Exception ex)
            {
                var errorWriter = Console.Error;
                errorWriter.WriteLine($"Something went wrong. More information: {ex.Message}");
            }
        }
    }
}
