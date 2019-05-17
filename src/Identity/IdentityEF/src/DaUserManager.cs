// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ejyle.DevAccelerate.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Identity.EF
{
    /// <summary>
    /// Represents the core functionality for creating and managing user accounts.
    /// </summary>
    public class DaUserManager : DaUserManager<DaUser>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaUserManager"/> class.
        /// </summary>
        /// <param name="repository">The user repository to be used by <see cref="DaUserManager"/>.</param>
        public DaUserManager(DaUserRepository repository)
            : base(repository)
        {
        }

        public static DaUserManager Create(IdentityFactoryOptions<DaUserManager> options, IOwinContext context)
        {
            var userManager = new DaUserManager(new DaUserRepository(context.Get<DaIdentityDbContext>()));

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                userManager.UserTokenProvider =
                    new DataProtectorTokenProvider<DaUser, int>(dataProtectionProvider.Create("DevAccelerate Identity"));
            }

            return userManager;
        }
    }
}
