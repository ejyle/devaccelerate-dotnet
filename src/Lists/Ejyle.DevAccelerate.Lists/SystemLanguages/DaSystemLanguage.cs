// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Lists.Countries;

namespace Ejyle.DevAccelerate.Lists.SystemLanguages
{
    /// <summary>
    /// Represents a system language entity.
    /// </summary>
    public class DaSystemLanguage : DaSystemLanguage<string, DaCountrySystemLanguage>
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
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    /// <typeparam name="TCountrySystemLanguage">Represents the type for mapping applicable countries and system languages.</typeparam>
    public class DaSystemLanguage<TKey, TCountrySystemLanguage> : DaListItemBase<TKey>, IDaSystemLanguage<TKey>
        where TKey : IEquatable<TKey>
        where TCountrySystemLanguage : IDaCountrySystemLanguage<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaSystemLanguage{TKey, TCountry}"/> entity.
        /// </summary>
        public DaSystemLanguage()
        {
            CountrySystemLanguages = new HashSet<TCountrySystemLanguage>();
        }

        /// <summary>
        /// The mapping of applicable countries and system languages.
        /// </summary>
        public virtual ICollection<TCountrySystemLanguage> CountrySystemLanguages { get; set; }
    }
}
