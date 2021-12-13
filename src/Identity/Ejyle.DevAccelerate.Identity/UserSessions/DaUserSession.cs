// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.UserSessions;

namespace Ejyle.DevAccelerate.Identity.UserSessions
{
    public class DaUserSession : DaUserSession<int>
    { }

    public class DaUserSession<TKey> : DaAuditedEntityBase<TKey>, IDaUserSession<TKey>
        where TKey : IEquatable<TKey>
    {
        [Required]
        public TKey UserId
        {
            get;
            set;
        }

        [StringLength(128)]
        public string SessionKey
        {
            get;
            set;
        }

        [StringLength(128)]
        public string SystemSessionId
        {
            get;
            set;
        }

        [Required]
        public DateTime CreatedDateUtc
        {
            get;
            set;
        }

        public DateTime? ExpiryDateUtc
        {
            get;
            set;
        }

        public DateTime? ExpiredDateUtc
        {
            get;
            set;
        }

        [StringLength(15)]
        public string IpAddress
        {
            get;
            set;
        }

        [StringLength(500)]
        public string DeviceAgent
        {
            get;
            set;
        }

        [Required]
        public DaUserSessionStatus Status { get; set; }
    }
}
