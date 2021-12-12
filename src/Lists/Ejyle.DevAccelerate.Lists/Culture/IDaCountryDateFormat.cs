// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists.Culture
{
    /// <summary>
    /// Represents the basic interface of a country and date format mapping.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    public interface IDaCountryDateFormat<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Unique identifier of the country.
        /// </summary>
        TKey CountryId { get; set; }

        /// <summary>
        /// Unique identifier of the date format.
        /// </summary>
        TKey DateFormatId { get; set; }
    }
}
