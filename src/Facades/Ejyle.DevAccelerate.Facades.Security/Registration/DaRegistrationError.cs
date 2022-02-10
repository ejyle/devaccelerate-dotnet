// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Microsoft.AspNetCore.Identity;

namespace Ejyle.DevAccelerate.Facades.Security.Registration
{
    public class DaRegistrationError : DaOperationError
    {
        public const string DUPLICATE_USER_NAME = nameof(DUPLICATE_USER_NAME);
        public const string DUPLICATE_EMAIL = nameof(DUPLICATE_EMAIL);
        public const string DUPLICATE_TENANT = nameof(DUPLICATE_TENANT);
        public const string INVALID_USER_NAME = nameof(INVALID_USER_NAME);
        public const string INVALID_USER_ID = nameof(INVALID_USER_ID);
        public const string INVALID_TENANT_ID = nameof(INVALID_TENANT_ID);
        public const string INVALID_EMAIL = nameof(INVALID_EMAIL);
        public const string INVALID_TENANT = nameof(INVALID_TENANT);
        public const string INVALID_PERSON_NAME = nameof(INVALID_PERSON_NAME);
        public const string INVALID_COUNTRY = nameof(INVALID_COUNTRY);
        public const string INVALID_PHONE_NUMBER = nameof(INVALID_PHONE_NUMBER);
        public const string INVALID_SUBSCRIPTION_PLAN = nameof(INVALID_SUBSCRIPTION_PLAN);
        public const string UNKNOWN_ERROR = nameof(UNKNOWN_ERROR);

        public DaRegistrationError(string code, string description) : base(code, description)
        { }

        public DaRegistrationError(string description) : base(description)
        { }
    }
}
