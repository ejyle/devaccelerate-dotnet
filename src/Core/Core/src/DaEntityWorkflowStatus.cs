// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Defines the status levels of an entity in a workflow environment.
    /// </summary>
    public enum DaEntityWorkflowStatus
    {
        /// <summary>
        /// Entity has been created but may be incomplete or not ready.
        /// </summary>
        Draft = 0,
        /// <summary>
        /// Entity is under review.
        /// </summary>
        UnderReview = 1,
        /// <summary>
        /// There is a temporary hold on the status of the entity.
        /// </summary>
        OnHold = 2,
        /// <summary>
        /// The entity has been approved.
        /// </summary>
        Approved = 3,
        /// <summary>
        /// The entity has been rejected.
        /// </summary>
        Rejected = 4,
        /// <summary>
        /// The entity has been returned and needs to be updated or rectified.
        /// </summary>
        Returned = 5,
        /// <summary>
        /// The entity has been published for its ultimate purpose.
        /// </summary>
        Published = 6,
        /// <summary>
        /// The entity has been removed from the published status.
        /// </summary>
        Unpublished = 7,
        /// <summary>
        /// The entity is no longer useful in normal circumtances and has been archived for record-keeping purposes.
        /// </summary>
        Archived = 8,
        /// <summary>
        /// The entity is marked for deletion either for hard deletion or soft deletion.
        /// </summary>
        ToBeDeleted = 9,
        /// <summary>
        /// The entity has been deleted. This is a soft-deletion marker.
        /// </summary>
        Deleted = 10
    }
}
