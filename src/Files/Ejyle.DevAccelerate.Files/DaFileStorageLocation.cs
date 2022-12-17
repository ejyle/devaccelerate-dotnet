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
    public class DaFileStorageLocation : DaFileStorageLocation<string, DaFileStorage>
    { }

    public class DaFileStorageLocation<TKey, TFileStorage> : DaEntityBase<TKey>, IDaFileStorageLocation<TKey>
        where TKey : IEquatable<TKey>
        where TFileStorage : IDaFileStorage<TKey>
    {

        public string Location { get; set; }
        public TKey FileStorageId { get; set; }
        public virtual TFileStorage FileStorage { get; set; }
    }
}
