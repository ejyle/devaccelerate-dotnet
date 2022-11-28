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

namespace Ejyle.DevAccelerate.Forms.Definition.Questions
{
    public interface IDaQuestionOption<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey QuestionId { get; set; }
        DaQuestionOptionType OptionType { get; set; }
        string Name { get; set; }
        string Text { get; set; }
        string Value { get; set; }
        string HelpText { get; set; }
        bool IsCorrect { get; set; }
    }
}
