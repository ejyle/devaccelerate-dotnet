// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the basic interface of an entity's repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDaEntityRepository<TEntity> : IDaEntityRepository<string, TEntity>
        where TEntity : IDaEntity<string>
    {
    }

    /// <summary>
    /// Represents the basic interface of an entity's repository.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDaEntityRepository<TKey, TEntity> : IDisposable
        where TKey : IEquatable<TKey>
        where TEntity: IDaEntity
    {
    }
}
