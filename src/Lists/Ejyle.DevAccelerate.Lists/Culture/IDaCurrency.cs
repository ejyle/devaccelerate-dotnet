// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Culture
{
    /// <summary>
    /// Represents the basic interface of a currency entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    public interface IDaCurrency<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The symbol of the currency.
        /// </summary>
        string CurrencySymbol { get; set; }

        /// <summary>
        /// The three-letter alphabetic ISO 4217 code of the currency.
        /// </summary>
        string AlphabeticCode { get; set; }

        /// <summary>
        /// The three-digit ISO 4217 code of the currency.
        /// </summary>
        int NumericCode { get; set; }
    }
}
