// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Facades.Security.Authorization
{
    public class DaAuthorizationInfo : DaAuthorizationInfo<int, DaAuthorizedActionInfo>
    { }

    public class DaAuthorizationInfo<TKey, TAuthorizedActionInfo> : IDaAuthorizationInfo<TKey, TAuthorizedActionInfo>
        where TKey : IEquatable<TKey>
        where TAuthorizedActionInfo : IDaAuthorizedActionInfo<TKey>
    {
        public TKey Id {get; set;}
        public string Key {get; set;}
        public List<TAuthorizedActionInfo> Actions {get; set;}
    }

    public class DaAuthorizedActionInfo : DaAuthorizedActionInfo<int>
    { }

    public class DaAuthorizedActionInfo<TKey> : IDaAuthorizedActionInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        public string ActionName {get; set;}
        public bool? Allowed {get; set;}
    }
}
