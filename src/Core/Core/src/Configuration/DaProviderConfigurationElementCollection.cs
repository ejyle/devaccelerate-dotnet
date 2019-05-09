// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Represents the collection of provider configuration elements.
    /// </summary>
    public class DaProviderConfigurationElementCollection : DaProviderConfigurationElementCollection<DaProviderConfigurationElement>
    {
        /// <summary>
        /// Creates a new instance of <see cref="DaProviderConfigurationElement"/>.
        /// </summary>
        /// <returns>Returns an instance of the type <see cref="ConfigurationElement"/>.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new DaProviderConfigurationElement();
        }
    }

    /// <summary>
    /// Represents the collection of provider configuration elements.
    /// </summary>
    /// <typeparam name="TDaProviderConfigurationElement">The type of the provider element.</typeparam>
    public abstract class DaProviderConfigurationElementCollection<TDaProviderConfigurationElement> : ConfigurationElementCollection
        where TDaProviderConfigurationElement : DaProviderConfigurationElement
    {
        /// <summary>
        /// Gets the key for a provider configuration element.
        /// </summary>
        /// <param name="element">The element to return the key for.</param>
        /// <returns>Returns an instance of <see cref="System.Object"/>.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TDaProviderConfigurationElement)element).Name;
        }

        /// <summary>
        /// Gets provider configuration element by its name.
        /// </summary>
        /// <param name="name">The name of the provider configuration element.</param>
        /// <returns>Returns an instance of the type <see cref="DaProviderConfigurationElement"/>.</returns>
        public TDaProviderConfigurationElement GetByName(string name)
        {
            return (TDaProviderConfigurationElement)this.BaseGet((object)name);
        }

        /// <summary>
        /// Adds a provider configuration element to the configuration collection.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        public void Add(TDaProviderConfigurationElement element)
        {
            this.BaseAdd(element);
        }

        /// <summary>
        /// Removes a provider configuration element from the configuration collection.
        /// </summary>
        /// <param name="name">The name of the element to be removed.</param>
        public void Remove(object name)
        {
            this.BaseRemove(name);
        }

        /// <summary>
        /// Removes a provider configuration element by its index from the configuration collection.
        /// </summary>
        /// <param name="index">The index of the element to be removed.</param>
        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }
    }
}
