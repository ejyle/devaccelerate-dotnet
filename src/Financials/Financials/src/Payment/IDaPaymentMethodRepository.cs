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

namespace Ejyle.DevAccelerate.Financials.Payment
{
    public interface IDaPaymentMethodRepository<TKey, TPaymentMethod> : IDaEntityRepository<TKey, TPaymentMethod>
        where TKey : IEquatable<TKey>
        where TPaymentMethod : IDaPaymentMethod<TKey>
    {
        Task CreateAsync(TPaymentMethod paymentMethod);
        Task<TPaymentMethod> FindByIdAsync(TKey id);
        Task<List<TPaymentMethod>> FindByOwnerUserIdAsync(TKey ownerUserId);
        Task ActivateAsync(TKey paymentMethodId);
        Task DeactivateAsync(TKey paymentMethodId);
    }
}
