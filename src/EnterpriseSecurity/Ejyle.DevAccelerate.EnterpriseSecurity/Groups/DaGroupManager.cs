// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Groups
{
    public class DaGroupManager<TKey, TGroup> : DaEntityManagerBase<TKey, TGroup>
        where TKey : IEquatable<TKey>
        where TGroup : IDaGroup<TKey>
    {
        public DaGroupManager(IDaGroupRepository<TKey, TGroup> repository)
            : base(repository)
        {
        }

        protected virtual IDaGroupRepository<TKey, TGroup> Repository
        {
            get
            {
                return GetRepository<IDaGroupRepository<TKey, TGroup>>();
            }
        }

        public virtual async Task CreateAsync(TGroup group)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(group, nameof(group));

            await Repository.CreateAsync(group);
        }

        public virtual void Create(TGroup group)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(group));
        }

        public virtual async Task UpdateAsync(TGroup group)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(group, nameof(group));

            await Repository.UpdateAsync(group);
        }

        public virtual void Update(TGroup group)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(group));
        }

        public virtual async Task DeleteAsync(TGroup group)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(group, nameof(group));

            await Repository.DeleteAsync(group);
        }

        public virtual void Delete(TGroup group)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(group));
        }

        public virtual TGroup FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TGroup>(() => FindByIdAsync(id));
        }

        public virtual Task<TGroup> FindByIdAsync(TKey userId)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(userId);
        }

        public virtual async Task AddUserAsync(TKey id, TKey userId)
        {
            ThrowIfDisposed();
            await Repository.AddUserAsync(id, userId);
        }

        public virtual void AddUser(TKey id, TKey userId)
        {
            DaAsyncHelper.RunSync(() => AddUserAsync(id, userId));
        }

        public virtual async Task RemoveUserAsync(TKey id, TKey userId)
        {
            ThrowIfDisposed();
            await Repository.RemoveUserAsync(id, userId);
        }

        public virtual void RemoveUser(TKey id, TKey userId)
        {
            DaAsyncHelper.RunSync(() => RemoveUserAsync(id, userId));
        }

        public virtual List<TKey> FindUserRolesByUserIdA(TKey tenantId, TKey userId)
        {
            return DaAsyncHelper.RunSync<List<TKey>>(() => FindUserRolesByUserIdAsync(tenantId, userId));
        }

        public virtual Task<List<TKey>> FindUserRolesByUserIdAsync(TKey tenantId, TKey userId)
        {
            ThrowIfDisposed();
            return Repository.FindUserRolesByUserIdAsync(tenantId, userId);
        }

        public virtual bool IsUserInRole(TKey tenantId, TKey roleId, TKey userId)
        {
            return DaAsyncHelper.RunSync<bool>(() => IsUserInRoleAsync(tenantId, roleId, userId));
        }

        public virtual Task<bool> IsUserInRoleAsync(TKey tenantId, TKey roleId, TKey userId)
        {
            ThrowIfDisposed();
            return Repository.IsUserInRoleAsync(tenantId, roleId, userId);
        }
    }
}