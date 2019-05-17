// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Tenants
{
    public class DaTenantManager : DaTenantManager<int, int?, DaTenant>
    {
        public DaTenantManager(DaTenantRepository repository)
            : base(repository)
        { }
    }
}
