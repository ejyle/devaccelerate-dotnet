﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Profiles.Organizations
{
    public class DaOrganizationProfile : DaOrganizationProfile<int, int?, DaOrganizationProfileAttribute>
    {
        public DaOrganizationProfile() : base()
        { }
    }

    public class DaOrganizationProfile<TKey, TNullableKey, TOrganizationProfileAttribute> : DaAuditedEntityBase<TKey>, IDaOrganizationProfile<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TOrganizationProfileAttribute : IDaOrganizationProfileAttribute<TKey>
    {
        public DaOrganizationProfile() : base()
        {
            Attributes = new HashSet<TOrganizationProfileAttribute>();
        }

        [Required]
        public TNullableKey TenantId { get; set; }

        public TKey OwnerUserId { get; set; }

        [Required]
        [StringLength(256)]
        public string OrganizationName { get; set; }

        [Required]
        public DaOrganizationType OrganizationType { get; set; }
        public TNullableKey IndustryId { get; set; }
        public virtual ICollection<TOrganizationProfileAttribute> Attributes { get; set; }
    }
}