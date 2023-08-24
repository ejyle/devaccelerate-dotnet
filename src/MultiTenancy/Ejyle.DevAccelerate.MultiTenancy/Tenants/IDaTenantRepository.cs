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
    public interface IDaTenantRepository<TKey, TTenant, TTenantUser, TMTPTenant> : IDaEntityRepository<TKey, TTenant>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey>
        where TTenantUser : IDaTenantUser<TKey>
        where TMTPTenant : IDaMTPTenant<TKey>
    {
        Task CreateAsync(TTenant tenant);
        Task CreateAsync(TTenant tenant, TKey mtpTenantId);
        Task UpdateAsync(TTenant tenant);
        Task UpdateMTPTenantStatusAsync(TKey mtpTenantId, TKey tenantId, bool isActive);
        Task<TTenant> FindByIdAsync(TKey tenantId);
        Task<TTenant> FindByNameAsync(string name);
        Task<List<TTenant>> FindByUserIdAsync(TKey userId);
        IQueryable<TTenant> Tenants { get; }
        IQueryable<TTenantUser> TenantUsers { get; }
        Task<TMTPTenant> FindMTPTenantIdAsync(TKey id);
        Task<bool> CheckTenantUserActiveAssociationAsync(TKey tenantId, TKey userId);
        Task<List<TTenant>> FindByAttributeAsync(string attributeName, string attributeValue);
    }
}
