// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.EF;
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
    [Verb("createfilestoragelocation", HelpText = "Creates a DevAccelerate file storage location.")]
    public class DaCreateFileStorageLocationCommand : DaDatabaseCommand
    {
        [Option('n', "name", Required = true, HelpText = "Storage name for the new file storage location. It must already exist.")]
        public string FileStorageName
        {
            get;
            set;
        }

        [Option('l', "location", Required = true, HelpText = "Location path of the new file storage location.")]
        public string Location
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaFilesDbContext(GetConnectionString()))
            {
                Location = Location.Trim();
                FileStorageName = FileStorageName.Trim();

                if (string.IsNullOrEmpty(FileStorageName))
                {
                    Console.WriteLine("Name of the file storage is required.");
                    return;
                }

                if (string.IsNullOrEmpty(Location))
                {
                    Console.WriteLine("Location is required.");
                    return;
                }

                var fileStorageManager = new DaFileStorageManager(new DaFileStorageRepository(context));
                var fileStorage = fileStorageManager.FindByName(FileStorageName);

                if (fileStorage == null)
                {
                    Console.WriteLine("File storage doesn't exist.");
                    return;
                }

                var storageLocation = new DaFileStorageLocation()
                {
                    Location = Location,
                    FileStorageId = fileStorage.Id,
                    FileStorage = fileStorage
                };

                fileStorage.Locations.Add(storageLocation);
                fileStorageManager.Update(fileStorage);
            }

            Console.Write("File stroage created.");
        }
    }
}