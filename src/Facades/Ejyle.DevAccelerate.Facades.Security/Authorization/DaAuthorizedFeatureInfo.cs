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

namespace Ejyle.DevAccelerate.Facades.Security.Authorization
{
    public class DaAuthorizedFeatureInfo : DaAuthorizedFeatureInfo<int>
    { }

    public class DaAuthorizedFeatureInfo<TKey> : IDaAuthorizedFeatureInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id {get; set;}
        public string Name {get; set;}
        public string Key {get; set;}
        public string Location {get; set;}
    }
}
