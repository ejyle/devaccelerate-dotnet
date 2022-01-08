// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Facades.Security.Registration
{
    public enum DaRegistrationStatus
    {
        Success = 0,
        DuplicateUserName = 1,
        DuplicateEmail = 2,
        InvalidUserName = 3,
        InvalidEmail = 4,
        InvalidPersonName = 5,   
        InvalidCountry = 50,
        UnknownError = 100
    }
}
