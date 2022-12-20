// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists.Countries
{
    /// <summary>
    /// Represents the basic interface of a country and time zone mapping.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    public interface IDaCountryTimeZone<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Unique identifier of the country.
        /// </summary>
        TKey CountryId { get; set; }

        /// <summary>
        /// Unique identifier of the time zone.
        /// </summary>
        TKey TimeZoneId { get; set; }
    }
}
