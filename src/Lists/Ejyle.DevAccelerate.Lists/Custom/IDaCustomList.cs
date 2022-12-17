// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    /// <summary>
    /// Represents the basic interface of a custom list.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TKey">Represents a nullable type of an entity ID.</typeparam>
    public interface IDaCustomList<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The standard name of the custom list.
        /// </summary>        
        string Name { get; set; }

        /// <summary>
        /// The description of the custom list.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The unique string that represents the custom list.
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// The tenant ID associated with the custom list.
        /// </summary>
        TKey TenantId { get; set; }
    }
}
