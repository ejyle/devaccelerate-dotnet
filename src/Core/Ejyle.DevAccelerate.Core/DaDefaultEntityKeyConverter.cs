using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core
{
    public class DaDefaultEntityKeyConverter : IDaEntityKeyConverter<int, int?>
    {
        public int? ToNullableKey(int value)
        {
            int? intValue = value;
            return intValue;
        }

        public int ToKey(int? value)
        {
            int intValue = (int)value;
            return intValue;
        }
    }
}
