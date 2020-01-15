// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Configuration
{
    /// <summary>
    /// A static class that sets or gets enterprise security configuration section.
    /// </summary>
    public static class DaEnterpriseSecurityConfigurationManager
    {
        private const string CONFIG_NAME = "daEnterpriseSecurityConfiguration";

        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaEnterpriseSecurityConfigurationSection>(configurationName, configurationSource);
        }

        public static DaEnterpriseSecurityConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        public static DaEnterpriseSecurityConfigurationSection GetConfiguration(string configurationName)
        {
            return DaGlobalApplicationContext.GetConfiguration<DaEnterpriseSecurityConfigurationSection>(configurationName);
        }
    }
}
