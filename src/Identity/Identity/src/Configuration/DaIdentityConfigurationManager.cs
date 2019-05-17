// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Identity.Configuration
{
    public static class DaIdentityConfigurationManager
    {
        private const string CONFIG_NAME = "daIdentityConfiguration";

        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaIdentityConfigurationSection>(configurationName, configurationSource);
        }

        public static DaIdentityConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        public static DaIdentityConfigurationSection GetConfiguration(string configurationName)
        {
            var config = DaGlobalApplicationContext.GetConfiguration<DaIdentityConfigurationSection>(configurationName);

            if(config == null)
            {
                config = new DaIdentityConfigurationSection();
            }

            return config;
        }
    }
}
