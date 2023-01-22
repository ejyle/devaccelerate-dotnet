// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.MultiTenancy.Tenants
{
    /// <summary>
    /// Provides the interface for storing and retrieving tenants.
    /// </summary>
    /// <typeparam name="TKey">The type of an entity key.</typeparam>
    /// <typeparam name="TTenant">The type of a tenant.</typeparam>
    /// <typeparam name="TTenantUser">The type of a tenant user.</typeparam>
    public interface IDaTenantRepository<TKey, TTenant, TTenantUser> : IDaEntityRepository<TKey, TTenant>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey>
        where TTenantUser : IDaTenantUser<TKey>
    {
        /// <summary>
        /// Asynchronously creates a tenant in the tenant repository.
        /// </summary>
        /// <param name="tenant">The tenant to create.</param>
        /// <returns>The Task that represents the asynchronous operation.</returns>
        Task CreateAsync(TTenant tenant);

        /// <summary>
        /// Asynchronously updates a tenant in the tenant repository.
        /// </summary>
        /// <param name="tenant">The tenant to be updated.</param>
        /// <returns>The Task that represents the asynchronous operation.</returns>
        Task UpdateAsync(TTenant tenant);

        /// <summary>
        /// Asynchronously finds and returns a tenant by its ID.
        /// </summary>
        /// <param name="tenantId">The ID of the tenant.</param>
        /// <returns>The Task that represents the asynchronous operation containing the matching tenant.</returns>
        Task<TTenant> FindByIdAsync(TKey tenantId);

        /// <summary>
        /// Asynchronously finds and returns tenant by its name.
        /// </summary>
        /// <param name="name">The name of the tenant.</param>
        /// <returns>The Task that represents the asynchronous operation containing the matching tenant.</returns>
        Task<TTenant> FindByNameAsync(string name);

        /// <summary>
        /// Asynchronously finds and returns tenants associated with a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The Task that represents the asynchronous operation containing the matching tenants.</returns>
        Task<List<TTenant>> FindByUserIdAsync(TKey userId);

        /// <summary>
        /// Returns an IQueryable of tenants.
        /// </summary>
        IQueryable<TTenant> Tenants { get; }

        /// <summary>
        /// Returns an IQueryable of tenant users.
        /// </summary>
        IQueryable<TTenantUser> TenantUsers { get; }

        /// <summary>
        /// Asynchronously finds if a user has an active association with a tenant. 
        /// </summary>
        /// <param name="tenantId">The ID of the tenant.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Returns True if the active association exists otherwise it returns False.</returns>
        Task<bool> CheckTenantUserActiveAssociationAsync(TKey tenantId, TKey userId);

        /// <summary>
        /// Asynchronously finds a list of tenants that are associated with a pair of attribute name and its value.
        /// </summary>
        /// <param name="attributeName">The name of the attributte.</param>
        /// <param name="attributeValue">The value of the attribute.</param>
        /// <returns>The Task that represents the asynchronous operation containing the matching tenants.</returns>
        Task<List<TTenant>> FindByAttributeAsync(string attributeName, string attributeValue);
    }
}
