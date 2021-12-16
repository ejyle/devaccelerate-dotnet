// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the interface to convert int to int? and vice-versa.
    /// </summary>
    public class DaIntegerKeyConverter : IDaEntityKeyConverter<int, int?>
    {
        /// <summary>
        /// Converts int to int?.
        /// </summary>
        /// <param name="value">The int value that needs to be converted to int?.</param>
        /// <returns>Returns the value as int?.</returns>
        public int? ToNullableKey(int value)
        {
            int? intValue = value;
            return intValue;
        }

        /// <summary>
        /// Converts int? to int.
        /// </summary>
        /// <param name="value">The int? value that needs to be converted to int.</param>
        /// <returns>Returns the value as an int.</returns>
        public int ToKey(int? value)
        {
            int intValue = (int)value;
            return intValue;
        }
    }
}
