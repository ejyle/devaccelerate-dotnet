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
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Objects
{
    public class DaObjectTypeManager<TKey, TObjectType> : DaEntityManagerBase<TKey, TObjectType>
        where TKey : IEquatable<TKey>
        where TObjectType : IDaObjectType<TKey>
    {
        public DaObjectTypeManager(IDaObjectTypeRepository<TKey, TObjectType> repository)
            : base(repository)
        {
        }

        protected virtual IDaObjectTypeRepository<TKey, TObjectType> Repository
        {
            get
            {
                return GetRepository<IDaObjectTypeRepository<TKey, TObjectType>>();
            }
        }

        public virtual async Task CreateAsync(TObjectType objType)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(objType, nameof(objType));

            await Repository.CreateAsync(objType);
        }

        public virtual void Create(TObjectType objType)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(objType));
        }

        public virtual async Task UpdateAsync(TObjectType objType)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(objType, nameof(objType));

            await Repository.UpdateAsync(objType);
        }

        public virtual void Update(TObjectType objType)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(objType));
        }

        public virtual async Task DeleteAsync(TObjectType objType)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(objType, nameof(objType));

            await Repository.DeleteAsync(objType);
        }

        public virtual void Delete(TObjectType objType)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(objType));
        }

        public virtual TObjectType FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TObjectType>(() => FindByIdAsync(id));
        }

        public virtual Task<TObjectType> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }
    }
}