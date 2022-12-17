﻿// ----------------------------------------------------------------------------------------------------------------------
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

namespace Ejyle.DevAccelerate.Forms.Forms
{
    public class DaFormSection<TKey, TForm> : DaAuditedEntityBase<TKey>, IDaFormSection<TKey>
        where TKey : IEquatable<TKey>
        where TForm : IDaForm<TKey>
    {
        public TKey FormId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public virtual TForm Form { get; set; }
    }
}
