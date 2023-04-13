// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Core.Posts
{
    public class DaPost : DaPost<string, DaPostRole, DaPostOrganizationGroup>
    { }

    public class DaPost<TKey, TPostRole, TPostOrganizationGroup> : DaAuditedEntityBase<TKey>, IDaPost<TKey>
        where TKey : IEquatable<TKey>
        where TPostRole : IDaPostRole<TKey>
        where TPostOrganizationGroup : IDaPostOrganizationGroup<TKey>
    {
        public DaPost()
        {
            OrganizationGroups = new HashSet<TPostOrganizationGroup>();
            Roles = new HashSet<TPostRole>();
        }

        public string UserId { get; set; }
        public string TenantId { get; set; }
        public DaPostVisibility PostVisibility { get; set; }
        public bool IsSystemPost { get; set; }
        public string Text { get; set; }
        public bool IsTextHtml { get; set; }
        public string Link { get; set; }
        public string ActualLink { get; set; }
        public bool IsLinkSortened { get; set; }
        public string MediaUrl { get; set; }
        public DaPostMediaType MediaType { get; set; }
        public string MediaExtension { get; set; }
        public bool IsMediaUrlDownloadLink { get; set; }
        public string MediaFileId { get; set; }
        public virtual ICollection<TPostRole> Roles { get; set; }
        public virtual ICollection<TPostOrganizationGroup> OrganizationGroups { get; set; }
    }
}
