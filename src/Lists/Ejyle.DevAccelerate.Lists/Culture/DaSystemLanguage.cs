// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Lists.Culture
{
    /// <summary>
    /// Represents a system language entity.
    /// </summary>
    public class DaSystemLanguage : DaSystemLanguage<int, DaCountrySystemLanguage>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaSystemLanguage"/> entity.
        /// </summary>
        public DaSystemLanguage()
            : base()
        { }
    }

    /// <summary>
    /// Presents a system language.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TCountrySystemLanguage">Represents the type for mapping applicable countries and system languages.</typeparam>
    public class DaSystemLanguage<TKey, TCountrySystemLanguage> : DaListItemBase<TKey>, IDaSystemLanguage<TKey>
        where TKey : IEquatable<TKey>
        where TCountrySystemLanguage : IDaCountrySystemLanguage<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaSystemLanguage{TKey, TNullableKey, TCountry}"/> entity.
        /// </summary>
        public DaSystemLanguage()
        {
            CountrySystemLanguages = new HashSet<TCountrySystemLanguage>();
        }

        /// <summary>
        /// Unique identifier of the system language on the OS.
        /// </summary>
        public string SystemLanguageId { get; set; }

        /// <summary>
        /// The mapping of applicable countries and system languages.
        /// </summary>
        public virtual ICollection<TCountrySystemLanguage> CountrySystemLanguages { get; set; }
    }
}
