// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.EnterpriseSecurity.Apps.Configuration;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaDefaultAppsInitializer : DaInitializerBase
    {
        public DaDefaultAppsInitializer(IDaConfigurationSource configurationSource)
            : base(configurationSource)
        { }

        public override void Initialize()
        {
            DaAppsConfigurationManager.InitConfiguration(ConfigurationSource);
        }
    }
}
