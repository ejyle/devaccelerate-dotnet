// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity.UserSessions
{
    public class DaUserSession : DaUserSession<string>
    { }

    public class DaUserSession<TKey> : DaEntityBase<TKey>, IDaUserSession<TKey>
        where TKey : IEquatable<TKey>
    {

        public TKey UserId
        {
            get;
            set;
        }

        public string AccessToken
        {
            get;
            set;
        }

        public string SystemSessionId
        {
            get;
            set;
        }

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

        public string IpAddress
        {
            get;
            set;
        }

        public string DeviceAgent
        {
            get;
            set;
        }

        public DaUserSessionStatus Status { get; set; }
    }
}
