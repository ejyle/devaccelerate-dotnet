// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.Addresses
{
    public class DaUserAddress : DaUserAddress<DaAddressProfile>
    {
        public DaUserAddress() : base()
        { }
    }

    public class DaUserAddress<TAddressProfile> : DaUserAddress<int, int?, TAddressProfile>
        where TAddressProfile : IDaAddressProfile<int, int?>
    {
        public DaUserAddress() : base()
        { }
    }

    public class DaUserAddress<TKey, TNullableKey, TAddressProfile> : DaEntityBase<TKey>, IDaUserAddress<TKey>
        where TKey : IEquatable<TKey>
        where TAddressProfile : IDaAddressProfile<TKey, TNullableKey>
    {
        public DaUserAddress() : base()
        { }

        public TKey UserId { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public TKey TenantId { get; set; }
        public DaAddressType AddressType { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public TKey AddressProfileId { get; set; }
        public virtual TAddressProfile AddressProfile { get; set; }
    }
}
