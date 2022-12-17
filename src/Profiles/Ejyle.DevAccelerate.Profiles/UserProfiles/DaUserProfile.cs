// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Profiles.UserProfiles
{
    public class DaUserProfile : DaUserProfile<string, DaUserProfileAttribute>
    {
        public DaUserProfile() : base()
        { }
    }

    public class DaUserProfile<TKey, TUserProfileAttribute> : DaAuditedEntityBase<TKey>, IDaUserProfile<TKey>
        where TKey : IEquatable<TKey>
        where TUserProfileAttribute : IDaUserProfileAttribute<TKey>
    {
        public DaUserProfile() : base()
        {
            Attributes = new HashSet<TUserProfileAttribute>();
        }

        public TKey OwnerUserId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public DaGender? Gender { get; set; }
        public string JobTitle { get; set; }
        public string OrganizationName { get; set; }
        public virtual ICollection<TUserProfileAttribute> Attributes { get; set; }
    }
}
