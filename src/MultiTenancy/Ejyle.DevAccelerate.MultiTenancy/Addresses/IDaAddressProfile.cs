// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.MultiTenancy.Addresses
{
    public interface IDaAddressProfile<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string ZipCode { get; set; }
        string State { get; set; }
        string Country { get; set; }
        string OwnerUserId { get; set; }
        string PhoneNumber { get; set; }
        string AreaCode { get; set; }
        string Extension { get; set; }
        string FaxNumber { get; set; }
        double? Longitude { get; set; }
        double? Latitude { get; set; }
    }
}
