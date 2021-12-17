// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Utils
{
    /// <summary>
    /// Represents a utility class for generating random numbers.
    /// </summary>
    public class DaRandomNumberUtil
    {
        /// <summary>
        /// Generates an integer random number.
        /// </summary>
        /// <returns>Returns the randome number as <see cref="int"/>.</returns>
        public static int GenerateInt()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            return rand.Next();
        }
    }
}
