// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements
{
    /// <summary>
    /// Represents an interface for a user agreement version. A user agreement can have multiple versions.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    public interface IDaUserAgreementVersion<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the Id of the user agreement associated with the version.
        /// </summary>
        TKey UserAgreementId { get; set; }

        /// <summary>
        /// Gets or sets the version number of the user agreement version.
        /// </summary>
        int VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the text of the user agreement version.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Determines if the user agreement version is current.
        /// </summary>
        bool IsCurrent { get; set; }

        /// <summary>
        /// Determines if the user agreement version is published.
        /// </summary>
        bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets the date when the user agreement version was published.
        /// </summary>
        DateTime? PublishedDateUtc { get; set; }
    }
}
