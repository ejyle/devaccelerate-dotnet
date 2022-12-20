// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    /// <summary>
    /// Represents the basic interface of a custom list item.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    public interface IDaCustomListItem<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The ID of the list to which the list item belongs.
        /// </summary>
        TKey ListId { get; set; }

        /// <summary>
        /// The ID of the parent list item.
        /// </summary>
        TKey ParentId { get; set; }
    }
}
