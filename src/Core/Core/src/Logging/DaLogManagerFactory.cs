// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Logging.Configuration;
using Ejyle.DevAccelerate.Core.Properties;

namespace Ejyle.DevAccelerate.Core.Logging
{
    /// <summary>
    /// Represents the factory for creating <see cref="IDaLogManager"/>.
    /// </summary>
    public static class DaLogManagerFactory
    {
        /// <summary>
        /// Creates an instance of a log manager.
        /// </summary>
        /// <typeparam name="TLogManager">The type of the log manager.</typeparam>
        /// <returns>Returns an instance of the TLogManager that implements the <see cref="IDaLogManager"/> interface.</returns>
        public static TLogManager CreateLogManager<TLogManager>()
            where TLogManager : IDaLogManager
        {
            var loggingConfiguration = DaLoggingConfigurationManager.GetConfiguration();

            if (loggingConfiguration == null)
            {
                throw new InvalidOperationException(Resources.LoggingConfigurationNotSet);
            }

            var providerConfig = loggingConfiguration.Providers.GetByName(loggingConfiguration.DefaultProvider);

            Type type = Type.GetType(providerConfig.Type);
            var logManager = (TLogManager)Activator.CreateInstance(type);

            return logManager;
        }

        /// <summary>
        /// Creates an instance of a log manager.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="IDaLogManager"/> type.</returns>
        public static IDaLogManager CreateLogManager()
        {
            var loggingConfiguration = DaLoggingConfigurationManager.GetConfiguration();

            if (loggingConfiguration == null)
            {
                throw new InvalidOperationException(Resources.LoggingConfigurationNotSet);
            }

            var providerConfig = loggingConfiguration.Providers.GetByName(loggingConfiguration.DefaultProvider);

            Type type = Type.GetType(providerConfig.Type);
            var logManager = (IDaLogManager)Activator.CreateInstance(type);

            return logManager;
        }
    }
}
