﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Identity.UserProfiles
{
    public interface IDaUserProfile<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey OwnerUserId { get; set; }
        string Salutation { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string JobTitle { get; set; }
        string OrganizationName { get; set; }
        DateTime? Dob { get; set; }
        DaGender? Gender { get; set; }
    }
}
