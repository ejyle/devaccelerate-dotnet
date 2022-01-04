// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.AspNetCore.Identity;
using System;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;

namespace Ejyle.DevAccelerate.Tools.Commands.EnterpriseSecurity
{
    [Verb("createappfeature", HelpText = "Creates an app feature.")]
    public class DaCreateAppFeatureCommand : DaDatabaseCommand
    {
        [Option('n', "name", Required = true, HelpText = "Name of the new app feature to be created.")]
        public string Name
        {
            get;
            set;
        }

        [Option('a', "appkey", Required = true, HelpText = "The key of the app to which the new feature is to be mapped.")]
        public string AppKey
        {
            get;
            set;
        }

        [Option('c', "crudactions", Required = false, HelpText = "The standard CRUD actions are to be added to the new feature.")]
        public bool AddCRUDActions { get; set; } = true;

        public override void Execute()
        {
            EnsureConnectionIsValid();

            using (var context = new DaEnterpriseSecurityDbContext(ConnectionString))
            {
                DaApp app = null;

                var appManager = new DaAppManager(new DaAppRepository(context));
                app = appManager.FindByKey(AppKey);

                if (app == null)
                {
                    throw new Exception($"Invalid app key {AppKey}");
                }

                var featureManager = new DaFeatureManager(new DaFeatureRepository(context));
                var feature = new DaFeature()
                {
                    Name = Name,
                    App = app
                };

                feature.AppFeatures.Add(new DaAppFeature()
                {
                    App = app,
                    Feature = feature
                });

                if(AddCRUDActions)
                {
                    feature.FeatureActions.Add(new DaFeatureAction()
                    {
                         Feature = feature,
                         Name = "create"
                    });

                    feature.FeatureActions.Add(new DaFeatureAction()
                    {
                        Feature = feature,
                        Name = "read"
                    });

                    feature.FeatureActions.Add(new DaFeatureAction()
                    {
                        Feature = feature,
                        Name = "update"
                    });

                    feature.FeatureActions.Add(new DaFeatureAction()
                    {
                        Feature = feature,
                        Name = "delete"
                    });
                }

                featureManager.Create(feature);

                Console.WriteLine($"Feature created. The key is {feature.Key}");
            }
        }
    }
}
