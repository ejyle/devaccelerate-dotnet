// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.List.Culture
{
    public interface IDaCountry<TKey, TNullableKey> : IDaList<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string DialingCode { get; set; }
        string TwoLetterCode { get; set; }
        string ThreeLetterCode { get; set; }
        int NumericCode { get; set; }
        TNullableKey CurrencyId { get; set; }
        bool HasRegions { get; set; }
    }
}
