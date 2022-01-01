// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using CommandLine;
using Ejyle.DevAccelerate.Tools.Commands;
using Ejyle.DevAccelerate.Tools.Commands.EnterpriseSecurity;
using Ejyle.DevAccelerate.Tools.Commands.Identity;
using Ejyle.DevAccelerate.Tools.Commands.Lists;

namespace Ejyle.DevAccelerate.Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<DaCreateDatabaseCommand,
                    DaCreateAppCommand,
                    DaCreateAppFeatureCommand,
                    DaCreateDefaultListsCommand,
                    DaCreateUserCommand,
                    DaCreateRoleCommand>(args)
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
