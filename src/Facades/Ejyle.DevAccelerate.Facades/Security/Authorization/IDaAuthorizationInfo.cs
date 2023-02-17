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
    public interface IDaAuthorizationInfo<TKey, TAuthorizedActionInfo>
        where TKey : IEquatable<TKey>
        where TAuthorizedActionInfo : IDaAuthorizedActionInfo<TKey>
    {
        TKey Id { get; set; }
        string Key { get; set; }
        List<TAuthorizedActionInfo> Actions { get; set; }
    }

    public interface IDaAuthorizedActionInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        string ActionName { get; set; }
        bool? Allowed { get; set; }
    }
}
