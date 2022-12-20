// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.TimeZones
{
    /// <summary>
    /// Represents the basic interface of a time zone entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    public interface IDaTimeZone<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The unique ID of the time zone on the operating system.
        /// </summary>
        string SystemTimeZoneId { get; set; }

        /// <summary>
        /// Determines if the time zone supports day light savings.
        /// </summary>
        bool SupportsDaylightSavingTime { get; set; }

        /// <summary>
        /// The day light saving name of the time zone if applicable.
        /// </summary>
        string DaylightName { get; set; }
    }
}
