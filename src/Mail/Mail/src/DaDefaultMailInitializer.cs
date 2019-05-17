// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Mail.Configuration;

namespace Ejyle.DevAccelerate.Mail
{
    public class DaDefaultMailInitializer : DaInitializerBase
    {
        public DaDefaultMailInitializer(IDaConfigurationSource configurationSource)
            : base(configurationSource)
        { }

        public override void Initialize()
        {
            DaMailConfigurationManager.InitConfiguration(ConfigurationSource);
        }
    }
}
