// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Files
{
    public interface IDaFile<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string FileName { get; set; }
        string GuidFileName { get; set; }
        string MimeType { get; set; }
        long? FileSize { get; set; }
        string Extension { get; set; }
        TKey FileCollectionId { get; set; }
        string OwnerUserId { get; set; }
        string TenantId { get; set; }
        string ObjectInstanceId { get; set; }
        TKey FileStorageLocationId { get; set; }
    }
}
