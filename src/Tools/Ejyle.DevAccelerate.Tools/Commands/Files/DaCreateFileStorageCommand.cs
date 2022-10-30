// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.Culture;
using Ejyle.DevAccelerate.Lists.EF;
using Ejyle.DevAccelerate.Lists.EF.Culture;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CommandLine;
using Ejyle.DevAccelerate.Comments.EF;
using Ejyle.DevAccelerate.Files;
using Ejyle.DevAccelerate.Files.EF;

namespace Ejyle.DevAccelerate.Tools.Commands.Files
{
    [Verb("createfilestorage", HelpText = "Creates a DevAccelerate file storage.")]
    public class DaCreateFileStorageCommand : DaDatabaseCommand
    {
        [Option('n', "name", Required = true, HelpText = "Name for the new file storage to be created.")]
        public string Name
        {
            get;
            set;
        }

        [Option('p', "platform", Required = true, HelpText = "Platform for the new file storage to be created.")]
        public string Platform
        {
            get;
            set;
        }

        [Option('r', "root", Required = true, HelpText = "Root of the new file storage to be created.")]
        public string Root
        {
            get;
            set;
        }

        [Option('t', "type", Required = true, HelpText = "Type of the new file storage to be created. Passible values: LocalFileSystem, NetworkFileSystem, CloudStorage")]
        public DaFileStorageType StorageType
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaFilesDbContext(GetConnectionString()))
            {
                Name = Name.Trim();
                Root = Root.Trim();
                Platform = Platform.Trim();

                if (string.IsNullOrEmpty(Name))
                {
                    Console.WriteLine("Name is required.");
                    return;
                }

                if (string.IsNullOrEmpty(Platform))
                {
                    Console.WriteLine("Platform is required.");
                    return;
                }

                if (string.IsNullOrEmpty(Root))
                {
                    Console.WriteLine("Root is required.");
                    return;
                }

                var fileStorageManager = new DaFileStorageManager(new DaFileStorageRepository(context));
                var existingFileStorage = fileStorageManager.FindByName(Name);

                if (existingFileStorage != null)
                {
                    Console.WriteLine("Name must be unique.");
                    return;
                }

                var storage = new DaFileStorage()
                {
                    Name = Name,
                    Root = Root,
                    Platform = Platform,
                    StorageType = StorageType
                };

                fileStorageManager.Create(storage);                
            }

            Console.Write("File stroage created.");
        }
    }
}