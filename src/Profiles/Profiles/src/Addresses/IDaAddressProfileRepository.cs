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
    public interface IDaAddressProfileRepository<TKey, TNullableKey, TAddressProfile> : IDaEntityRepository<TKey, TAddressProfile>
        where TKey : IEquatable<TKey>
        where TAddressProfile : IDaAddressProfile<TKey, TNullableKey>
    {
        Task CreateAsync(TAddressProfile addressProfile);
        Task<TAddressProfile> FindByIdAsync(TKey id);
        Task<List<TAddressProfile>> FindByUserIdAsync(TKey ownerUserId);
        Task UpdateAsync(TAddressProfile addressProfile);
        Task DeleteAsync(TAddressProfile addressProfile);
    }
}
