// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.UserProfiles
{
    public class DaUserProfile : DaUserProfile<int, DaUserProfileAttribute>
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

        [Required]
        public TKey UserId { get; set; }

        [StringLength(50)]
        public string? Salutation { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? MiddleName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }
        public DateTime? Dob { get; set; }
        public DaGender? Gender { get; set; }

        [StringLength(256)]
        public string? JobTitle { get; set; }

        [StringLength(256)]
        public string? OrganizationName { get; set; }

        public virtual ICollection<TUserProfileAttribute> Attributes { get; set; }
    }
}
