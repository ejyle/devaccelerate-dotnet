// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Provides the base methods for a configuration section implementation.
    /// </summary>
    public class DaConfigurationSection : ConfigurationSection, IXmlSerializable
    {
        /// <summary>
        /// When overridden in a derived class, the method returns the XML schema of the configuration section.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="XmlSchema"/> class.</returns>
        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// When overridden in a derived class, the method returns name of the configuration section.
        /// </summary>
        /// <returns>Returns the name of the configuration section as a <see cref="string"/>.</returns>
        public virtual string GetConfigurationSectionName()
        {
            return null;
        }

        /// <summary>
        /// Serializes the configuration section into XML and writes to an XML writer object.
        /// </summary>
        /// <param name="writer">The XML writer object.</param>
        public virtual void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            var serializedSection = SerializeSection(this, GetConfigurationSectionName(), ConfigurationSaveMode.Full);

            /*
            if(!serializedSection.StartsWith("<?"))
            {
                serializedSection = "<?xml version=\"1.0\" ?>";
            }
            */

            writer.WriteRaw(serializedSection);
        }

        /// <summary>
        /// Updates the configuration section by reading XML from a configuration source.
        /// </summary>
        /// <param name="reader">The XML reader object.</param>
        public virtual void ReadXml(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            reader.Read();
            DeserializeSection(reader);
        }

        /// <summary>
        /// Gets an instance of a protected configuration provider by its name.
        /// </summary>
        /// <param name="providerName">The name of the protected configuration provider.</param>
        /// <returns>Returns an instance of the <see cref="ProtectedConfigurationProvider"/> class.</returns>
        public virtual ProtectedConfigurationProvider GetProtectionProviderByName(string providerName)
        {
            if (string.IsNullOrEmpty(providerName)) return null;
            return ProtectedConfiguration.Providers[providerName];
        }
    }
}
