// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Sms.Configuration;

namespace Ejyle.DevAccelerate.Sms
{
    /// <summary>
    /// Represents the factory for creating an instance of <see cref="IDaSmsProvider"/> type.
    /// </summary>
    public static class DaSmsProviderFactory
    {
        /// <summary>
        /// Creates an instance of a <see cref="IDaSmsProvider"/> type.
        /// </summary>
        /// <returns>Returns an instance of <see cref="IDaSmsProvider"/>.</returns>
        public static IDaSmsProvider GetProvider()
        {
            DaProviderConfigurationElement providerConfig = null;

            var config = DaSmsConfigurationManager.GetConfiguration();

            if (config != null)
            {
                providerConfig = config.Providers.GetByName(config.DefaultProvider);
            }

            if (providerConfig == null)
            {
                return null;
            }

            var type = Type.GetType(providerConfig.Type);
            return Activator.CreateInstance(type) as IDaSmsProvider;
        }
    }
}
