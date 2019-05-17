// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Sms.Configuration
{
    /// <summary>
    /// A static class that sets or gets SMS provider configuration section.
    /// </summary>
    public static class DaSmsConfigurationManager
    {
        private const string CONFIG_NAME = "daSmsConfiguration";

        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaSmsConfigurationSection>(configurationName, configurationSource);
        }

        public static DaSmsConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        public static DaSmsConfigurationSection GetConfiguration(string configurationName)
        {
            return DaGlobalApplicationContext.GetConfiguration<DaSmsConfigurationSection>(configurationName);
        }
    }
}
