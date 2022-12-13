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

namespace Ejyle.DevAccelerate.Forms.Fields
{
    public interface IDaFormField<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey LayoutColumnId { get; set; }
        int? Order { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        string Label { get; set; }
        bool IsRequired { get; set; }
        string HelpText { get; set; }
        DaFormFieldType FieldType { get; set; }
        TNullableKey CustomListId { get; set; }
    }
}