// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Mail.Configuration
{
    public class DaMailProviderConfigurationElementCollection : DaProviderConfigurationElementCollection<DaMailProviderConfigurationElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DaMailProviderConfigurationElement();
        }
    }
}
