// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity.UserSessions
{
    /// <summary>
    /// Represents an interface for a user session.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    public interface IDaUserSession<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the Id of the user associated with the session.
        /// </summary>
        TKey UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique key of the session.
        /// </summary>
        string SessionKey { get; set; }

        /// <summary>
        /// Gets or sets the system session ID.
        /// </summary>
        string SystemSessionId { get; set; }

        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the device agent name.
        /// </summary>
        string DeviceAgent { get; set; }

        /// <summary>
        /// Gets or sets the date and time of when the user session is expired.
        /// </summary>
        DateTime? ExpiryDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of when the user session actually got expired.
        /// </summary>
        DateTime? ExpiredDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the created date of the user session.
        /// </summary>
        DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the status of the user session.
        /// </summary>
        DaUserSessionStatus Status { get; set; }
    }
}
