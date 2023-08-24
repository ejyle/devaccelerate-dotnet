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
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.Core.Objects
{
    public interface IDaObjectTypeRepository<TKey, TObjectType> : IDaEntityRepository<TKey, TObjectType>
        where TKey : IEquatable<TKey>
        where TObjectType : IDaObjectType<TKey>
    {
        Task CreateAsync(TObjectType objType);
        Task<TObjectType> FindByIdAsync(TKey id);
        Task<List<TObjectType>> FindAllAsync();
        Task UpdateAsync(TObjectType objType);
        Task DeleteAsync(TObjectType objType);
        IQueryable<TObjectType> ObjectTypes { get; }
    }
}
