// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the interface to convert long to long? and vice-versa.
    /// </summary>
    public class DaLongKeyConverter : IDaEntityKeyConverter<long, long?>
    {
        /// <summary>
        /// Converts long to long?.
        /// </summary>
        /// <param name="value">The long value that needs to be converted to long?.</param>
        /// <returns>Returns the value as long?.</returns>
        public long? ToNullableKey(long value)
        {
            long? longValue = value;
            return longValue;
        }

        /// <summary>
        /// Converts long? to long.
        /// </summary>
        /// <param name="value">The long? value that needs to be converted to long.</param>
        /// <returns>Returns the value as an long.</returns>
        public long ToKey(long? value)
        {
            long intValue = (long)value;
            return intValue;
        }
    }
}
