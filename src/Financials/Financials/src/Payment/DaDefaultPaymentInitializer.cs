// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Financials.Payment.Configuration;

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public class DaDefaultAppsInitializer : DaInitializerBase
    {
        public DaDefaultAppsInitializer(IDaConfigurationSource configurationSource)
            : base(configurationSource)
        { }

        public override void Initialize()
        {
            DaPaymentConfigurationManager.InitConfiguration(ConfigurationSource);
        }
    }
}
