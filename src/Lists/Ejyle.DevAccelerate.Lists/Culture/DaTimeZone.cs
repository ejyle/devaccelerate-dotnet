// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Lists.Culture
{
    /// <summary>
    /// Represents a time zone entity.
    /// </summary>
    public class DaTimeZone : DaTimeZone<int, DaCountryTimeZone>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaTimeZone"/> entity.
        /// </summary>
        public DaTimeZone()
            : base()
        { }
    }

    /// <summary>
    /// Represents a time zone entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TCountryTimeZone">Represents the type for mapping of applicable countries and time zones.</typeparam>
    public class DaTimeZone<TKey, TCountryTimeZone> : DaListItemBase<TKey>, IDaTimeZone<TKey>
        where TKey : IEquatable<TKey>
        where TCountryTimeZone : IDaCountryTimeZone<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaTimeZone"/> entity.
        /// </summary>
        public DaTimeZone()
        {
            CountryTimeZones = new HashSet<TCountryTimeZone>();
        }

        /// <summary>
        /// The unique ID of the time zone on the operating system.
        /// </summary>
        public string SystemTimeZoneId { get; set; }

        /// <summary>
        /// Determines if the time zone supports day light savings.
        /// </summary>
        public bool SupportsDaylightSavingTime { get; set; }

        /// <summary>
        /// The day light saving name of the time zone if applicable.
        /// </summary>
        public string DaylightName { get; set; }

        /// <summary>
        /// The mapping of applicable countries and time zones.
        /// </summary>
        public virtual ICollection<TCountryTimeZone> CountryTimeZones { get; set; }
    }
}
