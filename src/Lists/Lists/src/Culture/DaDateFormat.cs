// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.List.Culture
{
    public class DaDateFormat : DaDateFormat<int, int?>
    { }

    public class DaDateFormat<TKey, TNullableKey> : DaListBase<TKey>, IDaDateFormat<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public string DateFormatExpression
        {
            get;
            set;
        }
        public DaDateFormatType DateFormatType
        {
            get;
            set;
        }
    }
}
