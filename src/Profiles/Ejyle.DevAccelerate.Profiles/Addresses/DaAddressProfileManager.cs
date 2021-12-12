// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.Addresses
{
    public class DaAddressProfileManager<TKey, TNullableKey, TAddressProfile> : DaEntityManagerBase<TKey, TAddressProfile>
        where TKey : IEquatable<TKey>
        where TAddressProfile : IDaAddressProfile<TKey, TNullableKey>
    {
        public DaAddressProfileManager(IDaAddressProfileRepository<TKey, TNullableKey, TAddressProfile> repository) : base(repository)
        {
        }

        protected virtual IDaAddressProfileRepository<TKey, TNullableKey, TAddressProfile> Repository
        {
            get
            {
                return GetRepository<IDaAddressProfileRepository<TKey, TNullableKey, TAddressProfile>>();
            }
        }

        public virtual async Task CreateAsync(TAddressProfile userProfile)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userProfile, nameof(userProfile));

            userProfile.CreatedDateUtc = DateTime.UtcNow;
            userProfile.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.CreateAsync(userProfile);
        }

        public virtual void Create(TAddressProfile addressProfile)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(addressProfile));
        }

        public virtual async Task UpdateAsync(TAddressProfile userProfile)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userProfile, nameof(userProfile));

            userProfile.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.UpdateAsync(userProfile);
        }

        public virtual void Update(TAddressProfile userProfile)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(userProfile));
        }

        public virtual async Task DeleteAsync(TAddressProfile userProfile)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(userProfile, nameof(userProfile));

            await Repository.DeleteAsync(userProfile);
        }

        public virtual void Delete(TAddressProfile userProfile)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(userProfile));
        }

        public virtual TAddressProfile FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TAddressProfile>(() => FindByIdAsync(id));
        }

        public virtual Task<TAddressProfile> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual List<TAddressProfile> FindByUserId(TKey userId)
        {
            return DaAsyncHelper.RunSync<List<TAddressProfile>>(() => FindByUserIdAsync(userId));
        }

        public virtual Task<List<TAddressProfile>> FindByUserIdAsync(TKey userId)
        {
            ThrowIfDisposed();
            return Repository.FindByUserIdAsync(userId);
        }

        public virtual List<TAddressProfile> FindByTenantId(TKey tenantId)
        {
            return DaAsyncHelper.RunSync<List<TAddressProfile>>(() => FindByTenantIdAsync(tenantId));
        }

        public virtual Task<List<TAddressProfile>> FindByTenantIdAsync(TKey tenantId)
        {
            ThrowIfDisposed();
            return Repository.FindByTenantIdAsync(tenantId);
        }
    }
}
