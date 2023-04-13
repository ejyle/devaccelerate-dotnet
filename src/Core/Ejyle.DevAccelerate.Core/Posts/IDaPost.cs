// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Posts
{
    public interface IDaPost<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string UserId { get; set; }
        string TenantId { get; set; }
        DaPostVisibility PostVisibility { get; set; }
        bool IsSystemPost { get; set; }
        string Text { get; set; }
        bool IsTextHtml { get; set; }
        string Link { get; set; }
        string ActualLink { get; set; }
        bool IsLinkSortened { get; set; }
        string MediaUrl { get; set; }
        string MediaFileId { get; set; }
        DaPostMediaType MediaType { get; set; }
        string MediaExtension { get; set; }
        bool IsMediaUrlDownloadLink { get; set; }
    }
}
