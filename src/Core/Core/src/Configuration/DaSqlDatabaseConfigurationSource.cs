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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Represents the SQL Server based configuration source.
    /// </summary>
    public class DaSqlDatabaseConfigurationSource : IDaConfigurationSource
    {
        private string _ConnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=DevAccelerateConfigDb; Integrated Security=True;";

        /// <summary>
        /// Creates an instance of the <see cref="DaSqlDatabaseConfigurationSource"/> class.
        /// </summary>
        public DaSqlDatabaseConfigurationSource()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaSqlDatabaseConfigurationSource"/> class.
        /// </summary>
        public DaSqlDatabaseConfigurationSource(string connectionString)
        {
            if(string.IsNullOrEmpty(_ConnectionString))
            {
                throw new ArgumentNullException(nameof(_ConnectionString));
            }

            _ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets a configuration section from the configuration source.
        /// </summary>
        /// <typeparam name="TConfigurationSection">The type of the configuration section.</typeparam>
        /// <param name="configSectionName">The name of the configuration section.</param>
        /// <returns>Returns an instance of the configuration section.</returns>
        public TConfigurationSection GetConfigurationSection<TConfigurationSection>(string configSectionName)
            where TConfigurationSection : DaConfigurationSection
        {
            TConfigurationSection configSection = default(TConfigurationSection);

            using (var conn = new SqlConnection(_ConnectionString))
            {
                var cmd = new SqlCommand($"SELECT [Id], [Name], [Configuration] FROM [dbo].[Configurations] WHERE [Name] = '{configSectionName}'", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    var dataExists = reader.Read();

                    if (dataExists)
                    {
                        configSection = (TConfigurationSection)Activator.CreateInstance(typeof(TConfigurationSection), true);

                        using (StringReader str = new StringReader(reader.GetString(2)))
                        {
                            using (var xmlReader = XmlReader.Create(str))
                            {
                                configSection.ReadXml(xmlReader);
                            }
                        }
                    }
                }
            }

            return configSection;
        }

        /// <summary>
        /// Gets or sets a collection of connection strings managed in the SQL Server based configuration source.
        /// </summary>
        /// <returns></returns>
        public ConnectionStringSettingsCollection GetConnectionStrings()
        {
            var connStrs = new ConnectionStringSettingsCollection();

            using (var conn = new SqlConnection(_ConnectionString))
            {
                var cmd = new SqlCommand($"SELECT [Id], [Name], [ConnectionString], [ProviderName], [IsEncrypted] FROM [dbo].[ConnectionStrings] WHERE [ConnectionStringType] = 'SQL Server'", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        connStrs.Add(new ConnectionStringSettings()
                        {
                            Name = reader.GetString(1),
                            ConnectionString = reader.GetString(2),
                            ProviderName = reader.GetString(3)
                        });
                    }
                }
            }

            return connStrs;
        }

        /// <summary>
        /// Saves changes to the configuration source. This method is not implemented.
        /// </summary>
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
