﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.Lists.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ejyle.DevAccelerate.Tools.Commands
{
    [Verb("setconn", HelpText = "Sets DevAccelerate database connection environment variable")]
    public class DaSetConnectionCommand : IDaCommand
    {
        private const string ENV_VARIABLE = "DEVACCELERATE_DB_CONN";

        public DaSetConnectionCommand()
        { }

        [Option('c', "connectionstring", Required = true, HelpText = "Connection string of the DevAccelerate database")]
        public string ConnectionString { get; set; }

        public void Execute()
        {
            Environment.SetEnvironmentVariable(ENV_VARIABLE, ConnectionString, EnvironmentVariableTarget.User);
            Console.WriteLine($"The environment variable {ENV_VARIABLE} with DevAccelerate database connection is set.");
        }
    }
}
