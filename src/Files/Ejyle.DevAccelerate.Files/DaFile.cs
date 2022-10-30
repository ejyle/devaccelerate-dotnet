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
    public class DaFile : DaFile<int, int?, DaFileCollection>
    { }

    public class DaFile<TKey, TNullableKey, TFileCollection> : DaAuditedEntityBase<TKey>, IDaFile<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TFileCollection : IDaFileCollection<TKey, TNullableKey>
    {
        public string FileName { get; set; }
        public string GuidFileName { get; set; }
        public string MimeType { get; set; }
        public long? FileSize { get; set; }
        public string Extension { get; set; }
        public TNullableKey FileCollectionId { get; set; }
        public TNullableKey ObjectInstanceId { get; set; }
        public TKey OwnerUserId { get; set; }
        public TNullableKey TenantId { get; set; }
        public virtual TFileCollection FileCollection { get; set; }
    }
}
