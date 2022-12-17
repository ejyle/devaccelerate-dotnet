// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Profiles.Addresses
{
    public class DaUserAddress : DaUserAddress<DaAddressProfile>
    {
        public DaUserAddress() : base()
        { }
    }

    public class DaUserAddress<TAddressProfile> : DaUserAddress<string, TAddressProfile>
        where TAddressProfile : IDaAddressProfile<string>
    {
        public DaUserAddress() : base()
        { }
    }

    public class DaUserAddress<TKey, TAddressProfile> : DaAuditedEntityBase<TKey>, IDaUserAddress<TKey>
        where TKey : IEquatable<TKey>
        where TAddressProfile : IDaAddressProfile<TKey>
    {
        public DaUserAddress() : base()
        { }

        public TKey UserId { get; set; }
        public string Name { get; set; }
        public TKey TenantId { get; set; }
        public DaAddressType AddressType { get; set; }
        public TKey AddressProfileId { get; set; }
        public virtual TAddressProfile AddressProfile { get; set; }
    }
}
