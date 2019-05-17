// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Sms.Configuration;

namespace Ejyle.DevAccelerate.Sms
{
    public class DaDefaultSmsInitializer : DaInitializerBase
    {
        public DaDefaultSmsInitializer(IDaConfigurationSource configurationSource)
            : base(configurationSource)
        { }

        public override void Initialize()
        {
            DaSmsConfigurationManager.InitConfiguration(ConfigurationSource);
        }
    }
}
