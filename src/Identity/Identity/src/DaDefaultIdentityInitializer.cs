// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Identity.Configuration;

namespace Ejyle.DevAccelerate.Identity
{
    public class DaDefaultIdentityInitializer : DaInitializerBase
    {
        public DaDefaultIdentityInitializer(IDaConfigurationSource configurationSource)
            : base(configurationSource)
        { }

        public override void Initialize()
        {
            DaIdentityConfigurationManager.InitConfiguration(ConfigurationSource);
        }
    }
}
