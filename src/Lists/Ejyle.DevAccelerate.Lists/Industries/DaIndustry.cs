// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Industries
{
    /// <summary>
    /// Represents a industry entity.
    /// </summary>
    public class DaIndustry : DaIndustry<string>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaIndustry"/> class.
        /// </summary>
        public DaIndustry() : base() { }

        /// <summary>
        /// Creates an instance of the <see cref="DaIndustry"/> class.
        /// </summary>
        /// <param name="name">The name of the industry.</param>
        /// <exception cref="ArgumentNullException">This exception is thrown if the name is empty or null.</exception>
        public DaIndustry(string name)
            : base(name)
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaIndustry"/> class.
        /// </summary>
        /// <param name="name">The name of the industry.</param>
        /// <param name="sector">The sector which the industry falls under.</param>
        /// <exception cref="ArgumentNullException">The exception is thrown if name or sector is empty or null.</exception>
        public DaIndustry(string name, string sector)
            : base(name, sector)
        { }
    }

    /// <summary>
    /// Represents a industry entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    public class DaIndustry<TKey> : DaListItemBase<TKey>, IDaIndustry<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaIndustry{TKey}"/> class.
        /// </summary>
        public DaIndustry() { }

        /// <summary>
        /// Creates an instance of the <see cref="DaIndustry{TKey}"/> class.
        /// </summary>
        /// <param name="name">The name of the industry.</param>
        /// <exception cref="ArgumentNullException">This exception is thrown if the name is empty or null.</exception>
        public DaIndustry(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = name;
            this.DisplayName = name;
            this.Sector = null;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaIndustry{TKey}"/> class.
        /// </summary>
        /// <param name="name">The name of the industry.</param>
        /// <param name="sector">The sector which the industry falls under.</param>
        /// <exception cref="ArgumentNullException">The exception is thrown if name or sector is empty or null.</exception>
        public DaIndustry(string name, string sector)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(sector))
            {
                throw new ArgumentNullException(nameof(sector));
            }

            this.Name = name;
            this.DisplayName = name;
            this.Sector = sector;
        }

        /// <summary>
        /// The main category of the industry.
        /// </summary>
        public string Sector { get; set; }
    }
}
