﻿// ----------------------------------------------------------------------------------------------------------------------
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
using Ejyle.DevAccelerate.Tools.Commands.MultiTenancy;

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
                    DaAddUserToRolesCommand,
                    DaCreateTenantCommand,
                    DaAddUserToTenantCommand>(args)
                .WithParsed<IDaCommand>(t => t.Execute());

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                var errorWriter = Console.Error;
                errorWriter.WriteLine($"ERROR: {ex.Message}");

                Environment.Exit(1);
            }
        }
    }
}
