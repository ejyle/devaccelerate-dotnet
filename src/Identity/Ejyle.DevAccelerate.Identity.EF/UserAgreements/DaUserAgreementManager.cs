// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.UserAgreements;

namespace Ejyle.DevAccelerate.Identity.EF.UserAgreements
{
    public class DaUserAgreementManager : DaUserAgreementManager<string, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction>
    {
        public DaUserAgreementManager(DaUserAgreementRepository repository)
            : base(repository)
        { }
    }
}
