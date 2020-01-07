// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public class DaAccountManager<TKey, TNullableKey, TAccount, TTransaction> : DaEntityManagerBase<TKey, TAccount>
        where TKey : IEquatable<TKey>
        where TAccount : IDaAccount<TKey>
        where TTransaction : IDaTransaction<TKey, TNullableKey>
    {
        public DaAccountManager(IDaAccountRepository<TKey, TNullableKey, TAccount, TTransaction> repository)
            : base(repository)
        { 
        }

        protected virtual IDaAccountRepository<TKey, TNullableKey, TAccount, TTransaction> Repository
        {
            get
            {
                return GetRepository<IDaAccountRepository<TKey, TNullableKey, TAccount, TTransaction>>();
            }
        }

        public virtual async Task CreateAsync(TTransaction feature)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(feature, nameof(feature));

            await Repository.CreateAsync(feature);
        }

        public virtual void Create(TTransaction feature)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(feature));
        }

        public virtual TAccount FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TAccount>(() => FindByIdAsync(id));
        }

        public virtual Task<TAccount> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual List<TAccount> FindByTenantId(TKey tenatId)
        {
            return DaAsyncHelper.RunSync<List<TAccount>>(() => FindByTenantIdAsync(tenatId));
        }

        public virtual List<TAccount> FindByOwnerUserId(TKey ownerUserId)
        {
            return DaAsyncHelper.RunSync<List<TAccount>>(() =>FindByOwnerUserIdAsync(ownerUserId));
        }

        public virtual Task<List<TAccount>> FindByOwnerUserIdAsync(TKey ownerUserId)
        {
            ThrowIfDisposed();
            return Repository.FindByOwnerUserIdAsync(ownerUserId);
        }

        public virtual Task<List<TAccount>> FindByTenantIdAsync(TKey tenantId)
        {
            ThrowIfDisposed();
            return Repository.FindByTenantIdAsync(tenantId);
        }
    }
}