// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaSignInManager : DaSignInManager<int, int?, DaUserManager, DaUser>
    {
        public DaSignInManager()
            : base()
        {
        }

        public DaSignInManager(DaUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(DaUser user)
        {
            return user.GenerateUserIdentityAsync((DaUserManager)UserManager);
        }

        public static DaSignInManager Create(IdentityFactoryOptions<DaSignInManager> options, IOwinContext context)
        {
            return new DaSignInManager(context.GetUserManager<DaUserManager>(), context.Authentication);
        }
    }
}
