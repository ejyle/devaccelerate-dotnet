// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Forms.Definition.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Forms.Definition.Questions
{
    public class DaFormQuestion<TKey, TNullableKey, TLayoutColumn, TQuestion> : DaAuditedEntityBase<TKey>, IDaFormQuestion<TKey>
        where TKey : IEquatable<TKey>
        where TLayoutColumn : IDaLayoutColumn<TKey>
        where TQuestion : IDaQuestion<TKey, TNullableKey>
    {
        public TKey LayoutColumnId { get; set; }
        public TKey QuestionId { get; set; }
        public virtual TLayoutColumn LayoutColumn { get; set; }
        public virtual TQuestion Question { get; set; }
    }
}
