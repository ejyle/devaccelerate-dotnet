// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Lists.Countries;

namespace Ejyle.DevAccelerate.Lists.Links
{
    /// <summary>
    /// Represents the format of a date.
    /// </summary>
    public class DaLink : DaLink<string>
    { }

    public class DaLink<TKey> : DaAuditedEntityBase<TKey>, IDaLink<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Category { get; set; }
        public bool IsRelativeUrl { get; set; }
    }
}
