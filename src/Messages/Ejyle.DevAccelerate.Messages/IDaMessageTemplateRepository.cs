﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Messages
{
    public interface IDaMessageTemplateRepository<TKey, TMessageTemplate> : IDaEntityRepository<TKey, TMessageTemplate>
        where TKey : IEquatable<TKey>
        where TMessageTemplate : IDaMessageTemplate<TKey>
    {
        Task CreateAsync(TMessageTemplate messageTemplate);
        Task<TMessageTemplate> FindByIdAsync(TKey id);
        Task UpdateAsync(TMessageTemplate messageTemplate);
        Task DeleteAsync(TMessageTemplate messageTemplate);
    }
}