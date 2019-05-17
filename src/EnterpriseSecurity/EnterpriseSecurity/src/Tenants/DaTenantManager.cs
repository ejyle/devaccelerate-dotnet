// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Tenants
{
    public class DaTenantManager<TKey, TNullableKey, TTenant>
        : DaEntityManagerBase<TKey, TTenant>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey, TNullableKey>
    {
        public DaTenantManager(IDaTenantRepository<TKey, TNullableKey, TTenant> repository)
            : base(repository)
        { }

        private IDaTenantRepository<TKey, TNullableKey, TTenant> GetRepository()
        {
            return GetRepository<IDaTenantRepository<TKey, TNullableKey, TTenant>>();
        }

        public Task CreateAsync(TTenant tenant)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(tenant, nameof(tenant));
            return GetRepository().CreateAsync(tenant);
        }

        public Task<TTenant> FindByIdAsync(TKey tenantId)
        {
            ThrowIfDisposed();
            return GetRepository().FindByIdAsync(tenantId);
        }

        public void Create(TTenant tenant)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(tenant, "tenant");
            DaAsyncHelper.RunSync(() => CreateAsync(tenant));
        }

        public void Update(TTenant tenant)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(tenant));
        }

        public TTenant FindById(TKey tenantId)
        {
            return DaAsyncHelper.RunSync<TTenant>(() => FindByIdAsync(tenantId));
        }

        public Task<TTenant> FindByKeyAsync(string tenantKey)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNullOrEmpty(tenantKey, "tenantKey");
            return GetRepository().FindByNameAsync(tenantKey);
        }

        public TTenant FindByKey(string tenantKey)
        {
            return DaAsyncHelper.RunSync<TTenant>(() => FindByKeyAsync(tenantKey));
        }

        public Task UpdateAsync(TTenant tenant)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(tenant, nameof(tenant));
            return GetRepository().UpdateAsync(tenant);
        }

        public Task<List<TTenant>> FindByUserIdAsync(TKey userId)
        {
            ThrowIfDisposed();
            return GetRepository().FindByUserIdAsync(userId);
        }

        public List<TTenant> FindByUserId(TKey userId)
        {
            return DaAsyncHelper.RunSync<List<TTenant>>(() => FindByUserIdAsync(userId));
        }

        public Task<bool> CheckTenantUserActiveAssociationAsync(TKey tenantId, TKey userId)
        {
            ThrowIfDisposed();
            return GetRepository().CheckTenantUserActiveAssociationAsync(tenantId, userId);
        }

        public bool CheckTenantUserActiveAssociation(TKey tenantId, TKey userId)
        {
            return DaAsyncHelper.RunSync<bool>(() => CheckTenantUserActiveAssociationAsync(tenantId, userId));
        }
    }
}
