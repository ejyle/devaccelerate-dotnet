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
    public class DaFileStorage : DaFileStorage<int, DaFileStorageLocation, DaFileStorageAttribute>
    { }

    public class DaFileStorage<TKey, TFileStorageLocation, TFileStorageAttribute> : DaEntityBase<TKey>, IDaFileStorage<TKey>
        where TKey : IEquatable<TKey>
    {
        public DaFileStorage()
        {
            Locations = new HashSet<TFileStorageLocation>();
            Attributes = new HashSet<TFileStorageAttribute>();
        }

        public string Name { get; set; }
        public DaFileStorageType StorageType { get; set; }
        public string Platform { get; set; }
        public virtual ICollection<TFileStorageLocation> Locations { get; set; }
        public virtual ICollection<TFileStorageAttribute> Attributes { get; set; }
    }
}
