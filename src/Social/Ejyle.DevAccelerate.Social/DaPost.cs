// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Social
{
    public class DaPost : DaPost<string, DaPostRole, DaPostOrganizationGroup, DaPostMention, DaPostTag>
    { }

    public class DaPost<TKey, TPostRole, TPostOrganizationGroup, TPostMention, TPostTag> : DaAuditedEntityBase<TKey>, IDaPost<TKey>
        where TKey : IEquatable<TKey>
        where TPostRole : IDaPostRole<TKey>
        where TPostOrganizationGroup : IDaPostOrganizationGroup<TKey>
        where TPostMention : IDaPostMention<TKey>
        where TPostTag : IDaPostTag<TKey>
    {
        public DaPost()
        {
            OrganizationGroups = new HashSet<TPostOrganizationGroup>();
            Roles = new HashSet<TPostRole>();
            Mentions = new HashSet<TPostMention>();
            Tags = new HashSet<TPostTag>();
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
        public bool IsPinned { get; set; }
        public virtual ICollection<TPostMention> Mentions { get; set; }
        public virtual ICollection<TPostTag> Tags { get; set; } 
        public virtual ICollection<TPostRole> Roles { get; set; }
        public virtual ICollection<TPostOrganizationGroup> OrganizationGroups { get; set; }
    }
}
