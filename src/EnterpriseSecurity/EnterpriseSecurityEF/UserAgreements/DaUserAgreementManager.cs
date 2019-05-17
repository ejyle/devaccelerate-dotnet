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
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.UserAgreements
{
    public class DaUserAgreementManager : DaUserAgreementManager<int,int?, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction>
    {
        public DaUserAgreementManager(DaUserAgreementRepository repository)
            : base(repository)
        { }
    }
}
