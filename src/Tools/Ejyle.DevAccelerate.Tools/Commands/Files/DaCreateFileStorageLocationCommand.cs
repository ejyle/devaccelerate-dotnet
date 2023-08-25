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

            Console.WriteLine("Creating file storage location...");

            using (var context = new DaFilesDbContext(GetConnectionString()))
            {
                Location = Location.Trim();
                FileStorageName = FileStorageName.Trim();

                if (string.IsNullOrEmpty(FileStorageName))
                {
                    throw new Exception("Name of the file storage is required.");
                }

                if (string.IsNullOrEmpty(Location))
                {
                    throw new Exception("Location is required.");
                }

                var fileStorageManager = new DaFileStorageManager(new DaFileStorageRepository(context));
                var fileStorage = fileStorageManager.FindByName(FileStorageName);

                if (fileStorage == null)
                {
                    throw new Exception("File storage doesn't exist.");
                }

                var storageLocation = new DaFileStorageLocation()
                {
                    Location = Location,
                    FileStorageId = fileStorage.Id,
                    FileStorage = fileStorage
                };

                fileStorage.Locations.Add(storageLocation);
                fileStorageManager.Update(fileStorage);

                Console.Write($"{storageLocation.Location} file storage location created.");
            }
        }
    }
}