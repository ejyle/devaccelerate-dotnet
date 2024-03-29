﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Core.Objects;

namespace Ejyle.DevAccelerate.Tools.Commands.Core
{
    [Verb("createobjecttypes", HelpText = "Creates one or more DevAccelerate object types.")]
    public class DaCreateObjectTypesCommand : DaDatabaseCommand
    {
        [Option('t', "types", Required = true, HelpText = "Comma-separated list of object types to be created.")]
        public string ObjectType
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            string[] arrObjectTypes = ObjectType.Split(",");

            for (int i = 0; i < arrObjectTypes.Length; i++)
            {
                arrObjectTypes[i] = arrObjectTypes[i].Trim();
            }

            using (var coreDbContext = new DaCoreDbContext(GetConnectionString()))
            {
                var existingObjectTypes = coreDbContext.ObjectTypes.ToList();
                var objectTypes = new List<DaObjectType>();

                foreach (var ot in arrObjectTypes)
                {
                    DaObjectType existingObjectType = null;

                    if (existingObjectTypes != null && existingObjectTypes.Count > 0)
                    {
                        existingObjectType = existingObjectTypes.Where(m => m.Name == ot).FirstOrDefault();
                    }

                    if (existingObjectType == null)
                    {
                        var obectType = new DaObjectType()
                        {
                            Name = ot
                        };

                        objectTypes.Add(obectType);
                    }
                }

                if (objectTypes.Count > 0)
                {
                    coreDbContext.AddRange(objectTypes);
                    coreDbContext.SaveChanges();

                    Console.WriteLine($"{objectTypes.Count} object types created.");
                }
            }
        }
    }
}
