// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the interface to compare the equality comparisons of TKey and TNullableKey values.
    /// </summary>
    /// <typeparam name="TKey">The non-nullable key type.</typeparam>
    /// <typeparam name="TNullableKey">The nullable key type.</typeparam>
    public interface IDaEntityKeyComparer<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Determines if a TKey and TNullableKey values are equal.
        /// </summary>
        /// <param name="keyValue">The TKey value that needs to compared to TNullableKey.</param>
        /// <param name="nullableKeyValue">The TNullableKey value that needs to compared to TKey.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        bool Equals(TKey keyValue, TNullableKey nullableKeyValue);

        /// <summary>
        /// Determines if two TNullableKey values are equal.
        /// </summary>
        /// <param name="nullableKeyValue1">The first TNullableKey value that needs to compared to the second value.</param>
        /// <param name="nullableKeyValue2">The second TNullableKey value that needs to compared to the first value.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        bool Equals(TNullableKey nullableKeyValue1, TNullableKey nullableKeyValue2);

        /// <summary>
        /// Determines if a TNullableKey value equals to its default value.
        /// </summary>
        /// <param name="nullableKeyValue">The TNullableKey value that needs to compared to its default value.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        bool EqualsToDefault(TNullableKey nullableKeyValue);

        /// <summary>
        /// Determines if a TKey value equals to its default value.
        /// </summary>
        /// <param name="keyValue">The TKey value that needs to compared to its default value.</param>
        /// <returns>Returns True if both values are same otherwise returns False.</returns>
        bool EqualsToDefault(TKey keyValue);
    }
}
