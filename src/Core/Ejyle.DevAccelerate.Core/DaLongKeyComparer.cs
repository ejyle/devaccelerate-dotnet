// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the functionality to compare the equality of long and long? values.
    /// </summary>
    public class DaLongKeyComparer : IDaEntityKeyComparer<long, long?>
    {
        /// <summary>
        /// Determines if an long and long? values are equal.
        /// </summary>
        /// <param name="longValue">The long value that needs to compared to long?.</param>
        /// <param name="nullableLongValue">The long? value that needs to compared to long.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        public bool Equals(long longValue, long? nullableLongValue)
        {
            return (longValue == nullableLongValue);
        }

        /// <summary>
        /// Determines if two long? values are equal.
        /// </summary>
        /// <param name="nullableLongValue1">The first long value that needs to compared to the second value.</param>
        /// <param name="nullableLongValue2">The second long value that needs to compared to the first value.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        public bool Equals(long? nullableLongValue1, long? nullableLongValue2)
        {
            return (nullableLongValue1 == nullableLongValue2);
        }

        /// <summary>
        /// Determines if a long? value equals to its default value.
        /// </summary>
        /// <param name="nullableLongValue">The long? value that needs to compared to its default value.</param>
        /// <returns>Returns True if the long? value equals to its default value otherwise returns False.</returns>
        public bool EqualsToDefault(long? nullableLongValue)
        {
            return (nullableLongValue == default(long?));
        }

        /// <summary>
        /// Determines if an long value equals to its default value.
        /// </summary>
        /// <param name="longValue">The long value that needs to be compared to its default value.</param>
        /// <returns>Returns True if the long value equals to its default value otherwise returns False.</returns>
        public bool EqualsToDefault(long longValue)
        {
            return (longValue == default(long));
        }
    }
}
