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
using Ejyle.DevAccelerate.Comments.EF;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Platform.Apps;
using Ejyle.DevAccelerate.Platform.EF;
using Ejyle.DevAccelerate.Platform.EF.Apps;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.Lists.EF;
using Ejyle.DevAccelerate.Notifications.EF;
using Ejyle.DevAccelerate.SystemTasks.EF;
using Ejyle.DevAccelerate.Tasks.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Ejyle.DevAccelerate.MultiTenancy.EF;
using Ejyle.DevAccelerate.Subscriptions.EF;

namespace Ejyle.DevAccelerate.Tools.Commands
{
    [Verb("createdb", HelpText = "Creates DevAccelerate database")]
    public class DaCreateDatabaseCommand : DaDatabaseCommand
    {
        public DaCreateDatabaseCommand()
        { }

        public override void Execute()
        {
            using (var coreDbContext = new DaCoreDbContext(GetConnectionString()))
            {
                try
                {
                    coreDbContext.Database.EnsureCreated();
                    var databaseCreator = coreDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch(Exception)
                {
                    // Ignore the error
                }
            }

            EnsureConnectionIsValid();

            using (var listsDbContext = new DaListsDbContext(GetConnectionString()))
            {
                try
                {
                    listsDbContext.Database.EnsureCreated();
                    var databaseCreator = listsDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var systemTasksDbContext = new DaSystemTasksDbContext(GetConnectionString()))
            {
                try
                {
                    systemTasksDbContext.Database.EnsureCreated();
                    var databaseCreator = systemTasksDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var identityDbContext = new DaIdentityDbContext(GetConnectionString()))
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

            using (var platformDbcontext = new DaPlatformDbContext(GetConnectionString()))
            {
                try
                {
                    platformDbcontext.Database.EnsureCreated();
                    var databaseCreator = platformDbcontext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var multiTenancyDbContext = new DaMultiTenancyDbContext(GetConnectionString()))
            {
                try
                {
                    multiTenancyDbContext.Database.EnsureCreated();
                    var databaseCreator = multiTenancyDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var subscriptionsDbContext = new DaSubscriptionsDbContext(GetConnectionString()))
            {
                try
                {
                    subscriptionsDbContext.Database.EnsureCreated();
                    var databaseCreator = subscriptionsDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var commentsDbContext = new DaCommentsDbContext(GetConnectionString()))
            {
                try
                {
                    commentsDbContext.Database.EnsureCreated();
                    var databaseCreator = commentsDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var filesDbContext = new DaFilesDbContext(GetConnectionString()))
            {
                try
                {
                    filesDbContext.Database.EnsureCreated();
                    var databaseCreator = filesDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var notificationsDbContext = new DaNotificationsDbContext(GetConnectionString()))
            {
                try
                {
                    notificationsDbContext.Database.EnsureCreated();
                    var databaseCreator = notificationsDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            using (var tasksDbContext = new DaTasksDbContext(GetConnectionString()))
            {
                try
                {
                    tasksDbContext.Database.EnsureCreated();
                    var databaseCreator = tasksDbContext.GetService<IRelationalDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception)
                {
                    // Ignore the error
                }
            }

            Console.WriteLine("DevAccelerate database created.");
        }
    }
}
