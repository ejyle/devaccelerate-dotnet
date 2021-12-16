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
    /// Represents the interface to convert TKey to TNullableKey and vice-versa.
    /// </summary>
    /// <typeparam name="TKey">The non-nullable key type.</typeparam>
    /// <typeparam name="TNullableKey">The nullable key type.</typeparam>
    public interface IDaEntityKeyConverter<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Converts TKey to TNullableKey.
        /// </summary>
        /// <param name="value">The TKey value that needs to converted to TNullableKey.</param>
        /// <returns>Returns the value as TNullableKey.</returns>
        TNullableKey ToNullableKey(TKey value);

        /// <summary>
        /// Converts TNullableKey to TKey.
        /// </summary>
        /// <param name="value">The TNullableKey value that needs to be converted to TKey.</param>
        /// <returns>Returns the value as TNullableKey.</returns>
        TKey ToKey(TNullableKey value);
    }
}
