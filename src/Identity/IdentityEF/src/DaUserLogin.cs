// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.EF
{
    /// <summary>
    /// Represents a user's external login.
    /// </summary>
    public class DaUserLogin : DaUserLogin<int>
    { }

    /// <summary>
    /// Represents a user's external login.
    /// </summary>
    /// <typeparam name="TKey">The type of the user ID.</typeparam>
    public class DaUserLogin<TKey> : IdentityUserLogin<TKey>
        where TKey : IEquatable<TKey>
    { }
}
