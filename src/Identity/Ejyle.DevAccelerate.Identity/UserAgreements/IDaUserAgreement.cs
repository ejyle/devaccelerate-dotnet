// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity.UserAgreements
{
    /// <summary>
    /// Represents the interface for a user agreement.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    /// <typeparam name="TKey">The type of nullable key.</typeparam>
    public interface IDaUserAgreement<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the name of a user agreement.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique text key of a user agreement.
        /// </summary>
        string Key { get; set; }
    }
}
