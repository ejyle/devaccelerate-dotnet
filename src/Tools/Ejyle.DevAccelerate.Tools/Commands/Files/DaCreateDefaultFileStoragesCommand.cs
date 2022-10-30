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
    [Verb("createfilestorages", HelpText = "Creates default DevAccelerate file storages.")]
    public class DaCreateDefaultFileStoragesCommand : DaDatabaseCommand
    {
        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaFilesDbContext(GetConnectionString()))
            {
                var fileStorageManager = new DaFileStorageManager(new DaFileStorageRepository(context));
                var existingFileStorages = fileStorageManager.FindAll();

                DaFileStorage storage = null;
                DaFileStorage existingFileStorage = null;

                if (existingFileStorages != null && existingFileStorages.Count > 0)
                {
                    existingFileStorage = existingFileStorages.Where(m => m.Name == "Windows File System").SingleOrDefault();
                }

                if (existingFileStorage == null)
                {
                    storage = new DaFileStorage()
                    {
                        Name = "Windows File System",
                        Platform = "windows",
                        StorageType = DaFileStorageType.LocalFileSystem
                    };

                    fileStorageManager.Create(storage);
                }

                if (existingFileStorages != null && existingFileStorages.Count > 0)
                {
                    existingFileStorage = existingFileStorages.Where(m => m.Name == "Linux File System").SingleOrDefault();
                }

                if (existingFileStorage == null)
                {
                    storage = new DaFileStorage()
                    {
                        Name = "Linux File System",
                        Platform = "linux",
                        StorageType = DaFileStorageType.LocalFileSystem
                    };

                    fileStorageManager.Create(storage);
                }

                if (existingFileStorages != null && existingFileStorages.Count > 0)
                {
                    existingFileStorage = existingFileStorages.Where(m => m.Name == "Azure").SingleOrDefault();
                }

                if (existingFileStorage == null)
                {
                    storage = new DaFileStorage()
                    {
                        Name = "Azure",
                        Platform = "azure",
                        StorageType = DaFileStorageType.CloudStorage
                    };

                    fileStorageManager.Create(storage);
                }

                if (existingFileStorages != null && existingFileStorages.Count > 0)
                {
                    existingFileStorage = existingFileStorages.Where(m => m.Name == "AWS").SingleOrDefault();
                }

                if (existingFileStorage == null)
                {
                    storage = new DaFileStorage()
                    {
                        Name = "AWS",
                        Platform = "aws",
                        StorageType = DaFileStorageType.CloudStorage
                    };

                    fileStorageManager.Create(storage);
                }

                if (existingFileStorages != null && existingFileStorages.Count > 0)
                {
                    existingFileStorage = existingFileStorages.Where(m => m.Name == "Google Cloud").SingleOrDefault();
                }

                if (existingFileStorage == null)
                {
                    storage = new DaFileStorage()
                    {
                        Name = "Google Cloud",
                        Platform = "gc",
                        StorageType = DaFileStorageType.CloudStorage
                    };

                    fileStorageManager.Create(storage);
                }
            }

            Console.Write("Default set of file stroages created.");
        }
    }
}