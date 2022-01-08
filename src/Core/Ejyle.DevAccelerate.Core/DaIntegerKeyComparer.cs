// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the functionality to compare the equality of int and int? values.
    /// </summary>
    public class DaIntegerKeyComparer : IDaEntityKeyComparer<int, int?>
    {
        /// <summary>
        /// Determines if an int and int? values are equal.
        /// </summary>
        /// <param name="intValue">The int value that needs to compared to int?.</param>
        /// <param name="nullableIntValue">The int? value that needs to compared to int.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        public bool Equals(int intValue, int? nullableIntValue)
        {
            return (intValue == nullableIntValue);
        }

        /// <summary>
        /// Determines if two int? values are equal.
        /// </summary>
        /// <param name="nullableIntValue1">The first int value that needs to compared to the second value.</param>
        /// <param name="nullableIntValue2">The second int value that needs to compared to the first value.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        public bool Equals(int? nullableIntValue1, int? nullableIntValue2)
        {
            return (nullableIntValue1 == nullableIntValue2);
        }

        /// <summary>
        /// Determines if a int? value equals to its default value.
        /// </summary>
        /// <param name="nullableIntValue">The int? value that needs to compared to its default value.</param>
        /// <returns>Returns True if the int? value equalts to its default value otherwise returns False.</returns>
        public bool EqualsToDefault(int? nullableIntValue)
        {
            return (nullableIntValue == default(int?));
        }

        /// <summary>
        /// Determines if an int value equals to its default value.
        /// </summary>
        /// <param name="intValue">The int value that needs to be compared to its default value.</param>
        /// <returns>Returns True if the int value equals to its default value otherwise returns False.</returns>
        public bool EqualsToDefault(int intValue)
        {
            return (intValue == default(int));
        }
    }
}
