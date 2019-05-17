// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.List.Culture
{
    public interface IDaCountryRegion<TKey, TNullableKey> : IDaList<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        TNullableKey ParentId { get; set; }
        TKey CountryId { get; set; }
        string RegionCode { get; set; }
        bool IsVerified { get; set; }
    }
}
