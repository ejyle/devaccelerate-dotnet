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

namespace Ejyle.DevAccelerate.Forms.Questions
{
    public class DaQuestion<TKey, TNullableKey> : DaAuditedEntityBase<TKey>, IDaQuestion<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        public TNullableKey TenantId { get; set; }
        public string QuestionText { get; set; }
        public DaQuestionType QuestionType { get; set; }
    }
}
