// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps.Configuration
{
    /// <summary>
    /// A static class that sets or gets apps configuration section.
    /// </summary>
    public static class DaAppsConfigurationManager
    {
        private const string CONFIG_NAME = "daAppsConfiguration";

        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaAppsConfigurationSection>(configurationName, configurationSource);
        }

        public static DaAppsConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        public static DaAppsConfigurationSection GetConfiguration(string configurationName)
        {
            return DaGlobalApplicationContext.GetConfiguration<DaAppsConfigurationSection>(configurationName);
        }
    }
}
