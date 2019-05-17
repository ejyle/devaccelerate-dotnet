// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TNullableKey"></typeparam>
    /// <typeparam name="TUserManager"></typeparam>
    /// <typeparam name="TUser"></typeparam>
    public class DaSignInManager<TKey, TNullableKey, TUserManager, TUser> : SignInManager<TUser, TKey>
        where TKey : IEquatable<TKey>
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TUser : class, IDaUser<TKey, TNullableKey>
    {
        public DaSignInManager()
            : base(null, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="authenticationManager"></param>
        public DaSignInManager(TUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}
