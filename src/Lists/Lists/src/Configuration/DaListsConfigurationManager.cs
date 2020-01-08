// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Lists.Configuration
{
    /// <summary>
    /// A static class that sets or gets lists configuration section.
    /// </summary>
    public static class DaListsConfigurationManager
    {
        private const string CONFIG_NAME = "daListsConfiguration";

        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaListsConfigurationSection>(configurationName, configurationSource);
        }

        public static DaListsConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        public static DaListsConfigurationSection GetConfiguration(string configurationName)
        {
            return DaGlobalApplicationContext.GetConfiguration<DaListsConfigurationSection>(configurationName);
        }
    }
}
