// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Lists.SystemLanguages;

namespace Ejyle.DevAccelerate.Lists.Countries
{
    /// <summary>
    /// Represents the mapping of a country and a system language.
    /// </summary>
    public class DaCountrySystemLanguage : DaCountrySystemLanguage<string, DaCountry, DaSystemLanguage>
    { }

    /// <summary>
    /// Represents the mapping of a country and a system language.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TKey">Represents a nullable type for an entity ID.</typeparam>
    /// <typeparam name="TCountry">Represents the type of a country entity.</typeparam>
    /// <typeparam name="TSystemLanguage">Represents the type of a system language entity.</typeparam>
    public class DaCountrySystemLanguage<TKey, TCountry, TSystemLanguage> : DaEntityBase<TKey>, IDaCountrySystemLanguage<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey>
        where TSystemLanguage : IDaSystemLanguage<TKey>
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
        /// Unique identifier of the system language ID.
        /// </summary>
        public TKey SystemLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the system language of the mapping.
        /// </summary>
        public virtual TSystemLanguage SystemLanguage { get; set; }
    }
}
