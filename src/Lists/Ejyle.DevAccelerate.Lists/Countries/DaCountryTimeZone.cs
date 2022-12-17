// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Lists.TimeZones;

namespace Ejyle.DevAccelerate.Lists.Countries
{
    /// <summary>
    /// Represents the mapping of a country and a time zone.
    /// </summary>
    public class DaCountryTimeZone : DaCountryTimeZone<string, DaCountry, DaTimeZone>
    { }

    /// <summary>
    /// Represents the mapping of a country and a time zone.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TKey">Represents a nullable type for an entity ID.</typeparam>
    /// <typeparam name="TCountry">Represents the type of a country entity.</typeparam>
    /// <typeparam name="TTimeZone">Represents the type of a time zone entity.</typeparam>
    public class DaCountryTimeZone<TKey, TCountry, TTimeZone> : DaEntityBase<TKey>, IDaCountryTimeZone<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey>
        where TTimeZone : IDaTimeZone<TKey>
    {
        /// <summary>
        /// Unique identifier of the country.
        /// </summary>
        public TKey CountryId { get; set; }

        /// <summary>
        /// Gets or sets the country of the mapping.
        /// </summary>
        public virtual TCountry Country { get; set; }

        /// <summary>
        /// Unique identifier of the time zone.
        /// </summary>
        public TKey TimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets the time zone of the mapping.
        /// </summary>
        public virtual TTimeZone TimeZone { get; set; }
    }
}
