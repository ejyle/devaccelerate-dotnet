// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.SimpleWorkflow.Configuration
{
    /// <summary>
    /// Represents simple workflow configuration.
    /// </summary>
    public class DaSimpleWorkflowConfigurationSection : DaConfigurationSection
    {
        private const string REPO_TYPE = "repositoryType";
        private const string REPO_LOCATION = "repositoryLocation";

        /// <summary>
        /// Gets or sets the location of the repository.
        /// </summary>
        [ConfigurationProperty(REPO_LOCATION, IsRequired = false, DefaultValue = "C:\\Data")]
        public string RepositoryLocation
        {
            get
            {
                return this[REPO_LOCATION] as string;
            }
            set
            {
                this[REPO_LOCATION] = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the repository.
        /// </summary>
        [ConfigurationProperty(REPO_TYPE, IsRequired = false, DefaultValue = "Ejyle.DevAccelerate.SimpleWorkflow.Xml.DaXmlSimpleWorkflowRepository, Ejyle.DevAccelerate.SimpleWorkflow.Xml")]
        public string RepositoryType
        {
            get
            {
                return this[REPO_TYPE] as string;
            }
            set
            {
                this[REPO_TYPE] = value;
            }
        }

        /// <summary>
        /// Gets the name of the simple workflow configuration section.
        /// </summary>
        /// <returns>Returns daSimpleWorkflowConfiguration as the name of the configuration section.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daSimpleWorkflowConfiguration";
        }
    }
}
