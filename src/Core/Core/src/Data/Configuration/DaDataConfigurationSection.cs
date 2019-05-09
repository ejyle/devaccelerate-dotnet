// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Data.Configuration
{
    /// <summary>
    /// Represents common configuration for data stores.
    /// </summary>
    public class DaDataConfigurationSection : DaConfigurationSection
    {
        private const string DB_CONNECTION = "dbConnection";

        /// <summary>
        /// Gets or sets the common database connection.
        /// </summary>
        [ConfigurationProperty(DB_CONNECTION, IsRequired = false)]
        public string DbConnection
        {
            get
            {
                return this[DB_CONNECTION] as string;
            }
            set
            {
                this[DB_CONNECTION] = value;
            }
        }

        public override string GetConfigurationSectionName()
        {
            return "daDataConfiguration";
        }
    }
}
