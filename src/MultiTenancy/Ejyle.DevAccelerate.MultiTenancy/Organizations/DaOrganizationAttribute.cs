// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.MultiTenancy.Organizations
{
    public class DaOrganizationAttribute : DaOrganizationAttribute<DaOrganization>
    {
        public DaOrganizationAttribute() : base()
        { }
    }

    public class DaOrganizationAttribute<TOrganization> : DaOrganizationAttribute<string, TOrganization>
        where TOrganization : IDaOrganization<string>
    {
        public DaOrganizationAttribute() : base()
        { }
    }

    public class DaOrganizationAttribute<TKey, TOrganization> : DaEntityBase<TKey>, IDaOrganizationAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TOrganization : IDaOrganization<TKey>
    {
        public DaOrganizationAttribute() : base()
        { }

        public TKey OrganizationId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TOrganization Organization { get; set; }
    }
}
