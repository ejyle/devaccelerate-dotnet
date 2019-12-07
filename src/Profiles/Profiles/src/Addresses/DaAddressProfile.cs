// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.Addresses
{
    public class DaAddressProfile : DaAddressProfile<DaUserAddress>
    {
        public DaAddressProfile()
            : base()
        { }
    }

    public class DaAddressProfile<TUserAddress> : DaAddressProfile<int, int?, TUserAddress>
        where TUserAddress : IDaUserAddress<int>
    {
        public DaAddressProfile()
            : base()
        { }
    }

    public class DaAddressProfile<TKey, TNullableKey, TUserAddress> : DaEntityBase<TKey>, IDaAddressProfile<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TUserAddress : IDaUserAddress<TKey>
    {
        public DaAddressProfile()
            : base()
        {
            UserAddresses = new HashSet<TUserAddress>();
        }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public TNullableKey CountryId { get; set; }
        public TKey OwnerUserId { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaCode { get; set; }
        public string Extension { get; set; }
        public string FaxNumber { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public virtual ICollection<TUserAddress> UserAddresses { get; set; }
    }
}
