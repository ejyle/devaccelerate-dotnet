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
    /// Represents a currency entity.
    /// </summary>
    public class DaCurrency : DaCurrency<int, int?, DaCountry>
    {
    }

    /// <summary>
    /// Represents a currency entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TNullableKey">Represents a nullable type for an entity ID.</typeparam>
    /// <typeparam name="TCountry">Represents the type of the currency's countries.</typeparam>
    public class DaCurrency<TKey, TNullableKey, TCountry> : DaListItemBase<TKey>, IDaCurrency<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaCurrency{TKey, TNullableKey, TCountry}"/> entity.
        /// </summary>
        public DaCurrency()
        {
            Countries = new HashSet<TCountry>();
        }

        /// <summary>
        /// The symbol of the currency.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// The three-letter alphabetic ISO 4217 code of the currency.
        /// </summary>
        public string AlphabeticCode { get; set; }

        /// <summary>
        /// The three-digit ISO 4217 code of the currency.
        /// </summary>
        public int NumericCode { get; set; }

        /// <summary>
        /// The list of the countries that use the currency.
        /// </summary>
        public virtual ICollection<TCountry> Countries { get; set; }
    }
}
