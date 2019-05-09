// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Data.Configuration;
using System;
using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Data
{
    /// <summary>
    /// A helper class for database connections.
    /// </summary>
    public static class DaDbConnectionHelper
    {
        /// <summary>
        /// Gets the connection string based on the underlying data configuration.
        /// </summary>
        /// <returns>Returns the connection string as a <see cref="string"/>.</returns>
        public static string GetConnectionString()
        {
            var dbConfiguration = DaDataConfigurationManager.GetConfiguration();
            var dbConnection = dbConfiguration.DbConnection;

            var configurationSource = DaDataConfigurationManager.ConfigurationSource;

            string connectionString = string.Empty;

            if (configurationSource != null)
            {
                System.Configuration.ConnectionStringSettingsCollection connectionStrings = DaDataConfigurationManager.ConfigurationSource.GetConnectionStrings();

                if (connectionStrings != null)
                {
                    ConnectionStringSettings connectionStringSettings = null;

                    try
                    {
                        connectionStringSettings = connectionStrings[dbConnection];
                    }
                    catch (Exception)
                    {
                        // Ignore the exception as it simply means that the connection string doesn't exist in the configuration.
                    }

                    if (connectionStringSettings == null)
                    {
                        connectionStringSettings = new ConnectionStringSettings()
                        {
                            Name = dbConnection,
                            ProviderName = "System.Data.SqlClient",
                            ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DevAccelerateDb;Integrated Security=True"
                        };
                    }

                    connectionString = connectionStringSettings.ConnectionString;
                }
            }

            return connectionString;
        }
    }
}
