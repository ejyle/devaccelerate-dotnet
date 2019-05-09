// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// The base functionality for an initializer.
    /// </summary>
    public abstract class DaInitializerBase : IDaInitializer
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaInitializerBase"/> class.
        /// </summary>
        /// <param name="configurationSource">The configuration source used for initialization.</param>
        public DaInitializerBase(IDaConfigurationSource configurationSource)
        {
            if(configurationSource == null)
            {
                throw new ArgumentNullException(nameof(configurationSource));
            }

            ConfigurationSource = configurationSource;
        }

        /// <summary>
        /// Gets the <see cref="IDaConfigurationSource"/> object used by the initializer.
        /// </summary>
        public IDaConfigurationSource ConfigurationSource
        {
            get;
            private set;
        }

        /// <summary>
        /// Executes the initialization process.
        /// </summary>
        public abstract void Initialize();
    }
}
