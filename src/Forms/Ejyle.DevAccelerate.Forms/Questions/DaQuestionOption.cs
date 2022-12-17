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
    public class DaQuestionOption<TKey, TQuestion> : DaAuditedEntityBase<TKey>, IDaQuestionOption<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey QuestionId { get; set; }
        public DaQuestionOptionType OptionType { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string HelpText { get; set; }
        public bool IsCorrect { get; set; }
        public virtual TQuestion Question { get; set; }
    }
}
