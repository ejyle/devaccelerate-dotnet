// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.MultiTenancy.ApiManagement
{
    public interface IDaApiKey<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey TenantId { get; set; }
        string ApiKey { get; set; }
        string Salt { get; set; }
        string SecretKey { get; set; }
        bool IsActive { get; set; }
        bool IsExpired { get; set; }
        DateTime? ExpiryDateUtc { get; set; }
        DateTime CreatedDateUtc { get; set; }
    }
}
