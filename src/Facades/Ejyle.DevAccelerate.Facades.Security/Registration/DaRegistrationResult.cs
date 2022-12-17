// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Facades.Security.Registration
{
    public class DaRegistrationResult<TKey> : DaOperationResult<DaRegistrationError>
        where TKey : IEquatable<TKey>
    {
        public DaRegistrationResult(TKey userId, TKey userProfileId)
            :base()
        {
            UserId = userId;
            UserProfileId = userId;
        }

        public DaRegistrationResult(TKey userId, TKey userProfileId, TKey tenantId)
            : base()
        {
            UserId = userId;
            UserProfileId = userId;
            TenantId = tenantId;
        }

        public DaRegistrationResult(TKey userId, TKey userProfileId, TKey tenantId, TKey subscriptionId)
            : base()
        {
            UserId = userId;
            UserProfileId = userId;
            TenantId = tenantId;
            SubscriptionId = subscriptionId;
        }

        public DaRegistrationResult(IEnumerable<DaRegistrationError> errors)
            : base(errors)
        { }

        public DaRegistrationResult(DaRegistrationError error)
            : base(error)
        { }

        public TKey UserId { get; private set; }
        public TKey UserProfileId { get; private set; }
        public TKey TenantId { get; private set; }
        public TKey SubscriptionId { get; private set; }
    }
}
