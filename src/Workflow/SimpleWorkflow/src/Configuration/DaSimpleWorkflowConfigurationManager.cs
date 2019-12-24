// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Workflow.SimpleWorkflow.Configuration
{
    /// <summary>
    /// A static class that sets or gets simple workflow configuration section.
    /// </summary>
    public static class DaSimpleWorkflowConfigurationManager
    {
        private const string CONFIG_NAME = "daSimpleWorkflowConfiguration";

        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaSimpleWorkflowConfigurationSection>(configurationName, configurationSource);
        }

        public static DaSimpleWorkflowConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        public static DaSimpleWorkflowConfigurationSection GetConfiguration(string configurationName)
        {
            return DaGlobalApplicationContext.GetConfiguration<DaSimpleWorkflowConfigurationSection>(configurationName);
        }
    }
}
