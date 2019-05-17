// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Sms.Configuration
{
    public class DaSmsProviderConfigurationElementCollection : DaProviderConfigurationElementCollection<DaSmsProviderConfigurationElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DaSmsProviderConfigurationElement();
        }
    }
}
