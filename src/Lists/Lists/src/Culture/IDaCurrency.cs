// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.List.Culture
{
    public interface IDaCurrency<TKey> : IDaList<TKey>
        where TKey : IEquatable<TKey>
    {
        string NativeName { get; set; }
        string Name { get; set; }
        string CurrencySymbol { get; set; }
        string CurrencyCode { get; set; }
    }
}
