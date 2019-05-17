// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaRoleManager : DaRoleManager<DaRole>
    {
        /// <summary>
        /// Creates an instance of the <see cref="RoleManager{TRepository, TContext}"/> class.
        /// </summary>
        /// <param name="repository">The repository that saves changes to a role.</param>
        public DaRoleManager(DaRoleRepository repository)
            : base(repository)
        {
        }
    }
}
