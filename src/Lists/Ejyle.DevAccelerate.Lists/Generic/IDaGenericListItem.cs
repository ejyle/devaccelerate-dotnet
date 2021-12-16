﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Generic
{
    /// <summary>
    /// Represents the basic interface of a generic list item.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    public interface IDaGenericListItem<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The ID of the list to which the list item belongs.
        /// </summary>
        TKey ListId { get; set; }
    }
}