﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.CyberRisk.Comments;
using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Comments
{
    public interface IDaComment<TKey, TNullableKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TNullableKey ParentId
        {
            get;
            set;
        }

        string Message
        {
            get;
            set;
        }

        TKey CommentThreadId
        {
            get;
            set;
        }
    }
}