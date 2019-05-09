// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Exceptions.Configuration;
using Ejyle.DevAccelerate.Core.Properties;

namespace Ejyle.DevAccelerate.Core.Exceptions
{
    /// <summary>
    /// Represents the factory for creating <see cref="IDaExceptionManager"/>.
    /// </summary>
    public static class DaExceptionManagerFactory
    {
        /// <summary>
        /// Creates an instance of a exception manager.
        /// </summary>
        /// <typeparam name="TExceptionManager">The type of the exception manager.</typeparam>
        /// <returns>Returns an instance of the TExceptionManager type that implements the <see cref="IDaExceptionManager"/> interface.</returns>
        public static TExceptionManager CreateExceptionManager<TExceptionManager>()
            where TExceptionManager : IDaExceptionManager
        {
            var exceptionHandlingConfiguration = DaExceptionHandlingConfigurationManager.GetConfiguration(); ;

            if (exceptionHandlingConfiguration == null)
            {
                throw new InvalidOperationException(Resources.ExceptionHandlingConfigNotSet);
            }

            var providerConfig = exceptionHandlingConfiguration.Providers.GetByName(exceptionHandlingConfiguration.DefaultProvider);

            Type type = Type.GetType(providerConfig.Type);
            var exceptionManager = (TExceptionManager)Activator.CreateInstance(type);

            return exceptionManager;
        }

        /// <summary>
        /// Creates an instance of a exception manager.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="IDaExceptionManager"/> interface.</returns>
        public static IDaExceptionManager CreateExceptionManager()
        {
            var exceptionHandlingConfiguration = DaExceptionHandlingConfigurationManager.GetConfiguration();

            if (exceptionHandlingConfiguration == null)
            {
                throw new InvalidOperationException(Resources.ExceptionHandlingConfigNotSet);
            }

            var providerConfig = exceptionHandlingConfiguration.Providers.GetByName(exceptionHandlingConfiguration.DefaultProvider);

            Type type = Type.GetType(providerConfig.Type);
            var exceptionManager = (IDaExceptionManager)Activator.CreateInstance(type);

            return exceptionManager;
        }
    }
}
