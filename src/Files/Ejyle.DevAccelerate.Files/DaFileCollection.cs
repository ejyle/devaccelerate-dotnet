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
    public class DaFileCollection<TKey, TNullableKey, TFileCollection, TFile> : DaAuditedEntityBase<TKey>, IDaFileCollection<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TFileCollection : IDaFileCollection<TKey, TNullableKey>
        where TFile : IDaFile<TKey, TNullableKey>
    {
        public DaFileCollection() : base()
        {
            Children = new HashSet<TFileCollection>();
            Files = new HashSet<TFile>();
        }

        public string Name { get; set; }
        public TNullableKey ObjectInstanceId { get; set; }
        public bool IsUserDefined { get; set; }
        public TKey OwnerUserId { get; set; }
        public TNullableKey ParentId { get; set; }
        public TNullableKey TenantId { get; set; }
        public virtual TFileCollection Parent { get; set; }
        public virtual ICollection<TFileCollection> Children { get; set; }
        public virtual ICollection<TFile> Files { get; set; }
    }
}
