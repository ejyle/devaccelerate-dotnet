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
    public class DaFileCollection : DaFileCollection<string, DaFileCollection, DaFile>
    { }

    public class DaFileCollection<TKey, TFileCollection, TFile> : DaAuditedEntityBase<TKey>, IDaFileCollection<TKey>
        where TKey : IEquatable<TKey>
        where TFileCollection : IDaFileCollection<TKey>
        where TFile : IDaFile<TKey>
    {
        public DaFileCollection() : base()
        {
            Children = new HashSet<TFileCollection>();
            Files = new HashSet<TFile>();
        }

        public string Name { get; set; }
        public TKey ObjectInstanceId { get; set; }
        public bool IsUserDefined { get; set; }
        public TKey OwnerUserId { get; set; }
        public TKey ParentId { get; set; }
        public TKey TenantId { get; set; }
        public virtual TFileCollection Parent { get; set; }
        public virtual ICollection<TFileCollection> Children { get; set; }
        public virtual ICollection<TFile> Files { get; set; }
        public TKey FileStorageLocationId { get; set; }
    }
}
