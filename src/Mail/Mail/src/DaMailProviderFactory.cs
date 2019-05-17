// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Mail.Configuration;

namespace Ejyle.DevAccelerate.Mail
{
    /// <summary>
    /// Represents the factory for creating an instance of <see cref="IDaMailProvider"/> type.
    /// </summary>
    public static class DaMailProviderFactory
    {
        /// <summary>
        /// Creates an instance of a <see cref="IDaMailProvider"/> type.
        /// </summary>
        /// <returns>Returns an instance of <see cref="IDaMailProvider"/>.</returns>
        public static IDaMailProvider GetProvider()
        {
            DaProviderConfigurationElement providerConfig = null;

            var config = DaMailConfigurationManager.GetConfiguration();

            if(config == null)
            {
                return null;
            }

            providerConfig = config.Providers.GetByName(config.DefaultProvider);

            if(providerConfig == null)
            {
                return null;
            }

            var type = Type.GetType(providerConfig.Type);
            return Activator.CreateInstance(type) as IDaMailProvider;
        }
    }
}
