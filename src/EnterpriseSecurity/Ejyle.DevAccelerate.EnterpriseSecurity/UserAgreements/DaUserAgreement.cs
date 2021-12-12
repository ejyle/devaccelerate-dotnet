// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements
{
    public class DaUserAgreement : DaUserAgreement<int, int?, DaApp, DaUserAgreementVersion>
    {
        public DaUserAgreement() : base()
        { }
    }

    public class DaUserAgreement<TKey, TNullableKey, TApp, TUserAgreementVersion> : DaAuditedEntityBase<TKey>, IDaUserAgreement<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
        where TUserAgreementVersion : IDaUserAgreementVersion<TKey>
    {
        public DaUserAgreement()
        {
            UserAgreementVersions = new HashSet<TUserAgreementVersion>();
        }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        public TNullableKey AppId { get; set; }

        public virtual TApp App { get; set; }

        public virtual ICollection<TUserAgreementVersion> UserAgreementVersions { get; set; }
    }
}
