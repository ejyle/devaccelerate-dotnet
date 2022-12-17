// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Comments;

namespace Ejyle.DevAccelerate.Comments.EF
{
    public class DaCommentThreadManager : DaCommentThreadManager<string, DaCommentThread, DaComment>
    {
        public DaCommentThreadManager(DaCommentThreadRepository repository)
            : base(repository)
        { }
    }
}
