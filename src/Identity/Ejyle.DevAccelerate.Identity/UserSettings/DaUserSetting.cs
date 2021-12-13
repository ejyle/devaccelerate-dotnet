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

namespace Ejyle.DevAccelerate.Identity.UserSettings
{
    public class DaUserSetting : DaUserSetting<int>
    { }

    public class DaUserSetting<TKey> : DaAuditedEntityBase<TKey>, IDaUserSetting<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey UserId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
