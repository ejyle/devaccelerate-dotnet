﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.SystemLanguages
{
    /// <summary>
    /// Represents the basic interface of a system language entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    public interface IDaSystemLanguage<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
