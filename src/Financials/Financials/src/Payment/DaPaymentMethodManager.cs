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
    public class DaPaymentMethodManager<TKey, TPaymentMethod> : DaEntityManagerBase<TKey, TPaymentMethod>
        where TKey : IEquatable<TKey>
        where TPaymentMethod : IDaPaymentMethod<TKey>
    {
        public DaPaymentMethodManager(IDaPaymentMethodRepository<TKey, TPaymentMethod> repository)
            : base(repository)
        {
        }

        protected virtual IDaPaymentMethodRepository<TKey, TPaymentMethod> Repository
        {
            get
            {
                return GetRepository<IDaPaymentMethodRepository<TKey, TPaymentMethod>>();
            }
        }

        public virtual async Task CreateAsync(TPaymentMethod paymentMethod)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(paymentMethod, nameof(paymentMethod));

            await Repository.CreateAsync(paymentMethod);
        }

        public virtual void Create(TPaymentMethod app)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(app));
        }

        public virtual TPaymentMethod FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TPaymentMethod>(() => FindByIdAsync(id));
        }

        public virtual Task<TPaymentMethod> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual List<TPaymentMethod> FindByOwnerUserId(TKey ownerUserId)
        {
            return DaAsyncHelper.RunSync<List<TPaymentMethod>>(() => FindByOwnerUserIdAsync(ownerUserId));
        }

        public virtual Task<List<TPaymentMethod>> FindByOwnerUserIdAsync(TKey ownerUserId)
        {
            ThrowIfDisposed();
            return Repository.FindByOwnerUserIdAsync(ownerUserId);
        }
    }
}
