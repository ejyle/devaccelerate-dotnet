// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Provides an interface for storing and retrieving roles.
    /// </summary>
    /// <typeparam name="TKey">The type of an entity key.</typeparam>
    /// <typeparam name="TRole">The type of a role.</typeparam>
    public interface IDaRoleRepository<TKey, TRole> : IDaEntityRepository<TKey, TRole>
        where TKey : IEquatable<TKey>
        where TRole : IDaRole<TKey>
    {
    }
}
