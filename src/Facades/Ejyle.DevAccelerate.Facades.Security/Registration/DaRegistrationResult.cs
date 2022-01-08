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
    public class DaRegistrationResult<TKey, TNullableKey, TKeyConverter>
        where TKey : IEquatable<TKey>
        where TKeyConverter : IDaEntityKeyConverter<TKey, TNullableKey>
    {
        private readonly TKeyConverter _keyConverter;

        public DaRegistrationResult(TKeyConverter keyConverter, TKey userId, TKey userProfileId)
        {
            IsSuccess = true;
            UserId = keyConverter.ToNullableKey(userId);
            UserProfileId = keyConverter.ToNullableKey(userId);
        }

        public DaRegistrationResult(TKeyConverter keyConverter, TKey userId, TKey userProfileId, TKey tenantId)
        {
            IsSuccess = true;
            UserId = keyConverter.ToNullableKey(userId);
            UserProfileId = keyConverter.ToNullableKey(userId);
            TenantId = keyConverter.ToNullableKey(tenantId);
        }

        public DaRegistrationResult(TKeyConverter keyConverter, TKey userId, TKey userProfileId, TKey tenantId, TKey subscriptionId)
        {
            IsSuccess = true;
            UserId = keyConverter.ToNullableKey(userId);
            UserProfileId = keyConverter.ToNullableKey(userId);
            TenantId = keyConverter.ToNullableKey(tenantId);
            SubscriptionId = keyConverter.ToNullableKey(subscriptionId);
        }

        public DaRegistrationResult(IEnumerable<DaRegistrationError> errors)
        {
            IsSuccess = false;
            Errors = errors;
        }

        public DaRegistrationResult(DaRegistrationError error)
        {
            IsSuccess = false;

            var errors = new List<DaRegistrationError>();
            errors.Add(error);

            Errors = errors;
        }

        public TNullableKey UserId { get; private set; }
        public TNullableKey UserProfileId { get; private set; }
        public TNullableKey TenantId { get; private set; }
        public TNullableKey SubscriptionId { get; private set; }

        public IEnumerable<DaRegistrationError> Errors
        {
            get;
            private set;
        }

        public bool IsSuccess { get; private set; }
    }
}
