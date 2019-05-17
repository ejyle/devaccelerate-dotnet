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

namespace Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements
{
    public interface IDaUserAgreementVersionAction<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey UserAgreementVersionId { get; set; }
        TKey UserId { get; set; }
        TKey TenantId { get; set; }
        DateTime CreatedDateUtc { get; set; }
        string IpAddress { get; set; }
        string DeviceAgent { get; set; }
        DaUserAgreementVersionActionOwner ActionOwner { get; set; }
        DaUserAgreementVersionActionType ActionType { get; set; }
    }
}
