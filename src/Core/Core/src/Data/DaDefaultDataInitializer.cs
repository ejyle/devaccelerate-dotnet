// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Core.Data.Configuration;

namespace Ejyle.DevAccelerate.Core.Data
{
    public class DaDefaultDataInitializer : DaInitializerBase
    {
        public DaDefaultDataInitializer(IDaConfigurationSource configurationSource)
            : base(configurationSource)
        { }

        public override void Initialize()
        {
            DaDataConfigurationManager.InitConfiguration(ConfigurationSource);
        }
    }
}
