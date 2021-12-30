// ----------------------------------------------------------------------------------------------------------------------
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
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.Lists.EF;
using Ejyle.DevAccelerate.Profiles.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ejyle.DevAccelerate.Tools.Commands
{
    [Verb("createdb", HelpText = "Creates DevAccelerate database")]
    public class DaCreateDatabaseCommand : DaDatabaseCommand
    {
        public DaCreateDatabaseCommand()
        { }

        public override void Execute()
        { 
            using (var listsDbContext = new DaListsDbContext(ConnectionString))
            {
                try
                {
                    listsDbContext.Database.EnsureCreated();
                    var databaseCreator = listsDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch(Exception)
                {
                    // Ignore the error
                }
            }

            using (var identityDbContext = new DaIdentityDbContext(ConnectionString))
            {
                try
                {
                    identityDbContext.Database.EnsureCreated();
                    var databaseCreator = identityDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var enterpriseSecurityDbContext = new DaEnterpriseSecurityDbContext(ConnectionString))
            {
                try
                {
                    enterpriseSecurityDbContext.Database.EnsureCreated();
                    var databaseCreator = enterpriseSecurityDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var profilesDbContext = new DaProfilesDbContext(ConnectionString))
            {
                try
                {
                    profilesDbContext.Database.EnsureCreated();
                    var databaseCreator = profilesDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            Console.WriteLine("DevAccelerate lists database created.");
        }
    }
}
