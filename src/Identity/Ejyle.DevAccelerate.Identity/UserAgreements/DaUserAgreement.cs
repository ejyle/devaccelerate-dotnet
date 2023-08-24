// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Identity.UserAgreements
{
    public class DaUserAgreement : DaUserAgreement<string, DaUserAgreementVersion>
    {
        public DaUserAgreement() : base()
        { }
    }

    public class DaUserAgreement<TKey, TUserAgreementVersion> : DaAuditedEntityBase<TKey>, IDaUserAgreement<TKey>
        where TKey : IEquatable<TKey>
        where TUserAgreementVersion : IDaUserAgreementVersion<TKey>
    {
        public DaUserAgreement()
        {
            UserAgreementVersions = new HashSet<TUserAgreementVersion>();
        }
        public string Name { get; set; }
        public string Key { get; set; }
        public virtual ICollection<TUserAgreementVersion> UserAgreementVersions { get; set; }
    }
}
