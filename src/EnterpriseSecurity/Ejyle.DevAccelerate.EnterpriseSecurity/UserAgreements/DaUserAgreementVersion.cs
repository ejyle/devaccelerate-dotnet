// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements
{
    public class DaUserAgreementVersion : DaUserAgreementVersion<int, int?, DaUserAgreement, DaUserAgreementVersionAction>
    {
        public DaUserAgreementVersion() : base()
        { }
    }

    public class DaUserAgreementVersion<TKey, TNullableKey, TUserAgreement, TUserAgreementVersionAction> : DaAuditedEntityBase<TKey>, IDaUserAgreementVersion<TKey>
        where TKey : IEquatable<TKey>
        where TUserAgreement : IDaUserAgreement<TKey, TNullableKey>
        where TUserAgreementVersionAction : IDaUserAgreementVersionAction<TKey>
    {
        public DaUserAgreementVersion() 
            : base()
        {
            Actions = new HashSet<TUserAgreementVersionAction>();
        }

        public TKey UserAgreementId { get; set; }
        public int VersionNumber { get; set; }
        public string Text { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDateUtc { get; set; }
        public virtual TUserAgreement UserAgreement { get; set; }
        public virtual ICollection<TUserAgreementVersionAction> Actions { get; set; }
    }
}
