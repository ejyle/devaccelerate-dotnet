// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.List.Culture
{
    public interface IDaTimeZone<TKey, TNullableKey> : IDaList<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string SystemTimeZoneId { get; set; }
        string DisplayName { get; set; }
        bool SupportsDaylightSavingTime { get; set; }
        string DaylightName { get; set; }
    }
}
