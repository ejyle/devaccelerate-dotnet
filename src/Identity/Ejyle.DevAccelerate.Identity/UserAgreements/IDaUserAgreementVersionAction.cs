// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Identity.UserAgreements
{
    public interface IDaUserAgreementVersionAction<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey UserAgreementVersionId { get; set; }
        TKey UserId { get; set; }
        string TenantId { get; set; }
        string IpAddress { get; set; }
        string DeviceAgent { get; set; }
        DaUserAgreementVersionActionOwner ActionOwner { get; set; }
        DaUserAgreementVersionActionType ActionType { get; set; }
    }
}
