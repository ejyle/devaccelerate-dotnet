// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Lists.DateFormats;

namespace Ejyle.DevAccelerate.Lists.Countries
{
    /// <summary>
    /// Represents the mapping of a country and a time zone.
    /// </summary>
    public class DaCountryDateFormat : DaCountryDateFormat<int, int?, DaCountry, DaDateFormat>
    { }

    /// <summary>
    /// Represents the mapping of a country and a time zone.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TNullableKey">Represents a nullable type for an entity ID.</typeparam>
    /// <typeparam name="TCountry">Represents the type of a country entity.</typeparam>
    /// <typeparam name="TDateFormat">Represents the type of a date format entity.</typeparam>
    public class DaCountryDateFormat<TKey, TNullableKey, TCountry, TDateFormat> : DaEntityBase<TKey>, IDaCountryDateFormat<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
        where TDateFormat : IDaDateFormat<TKey>
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
        /// Unique identifier of the date format.
        /// </summary>
        public TKey DateFormatId { get; set; }

        /// <summary>
        /// Gets or sets the date format of the mapping.
        /// </summary>
        public virtual TDateFormat DateFormat { get; set; }
    }
}
