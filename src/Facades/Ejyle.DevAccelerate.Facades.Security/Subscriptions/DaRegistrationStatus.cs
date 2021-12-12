using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public enum DaRegistrationStatus
    {
        Success = 0,
        DuplicateUserName = 1,
        DuplicateEmail = 2,
        InvalidUserName = 3,
        InvalidEmail = 4,
        InvalidPersonName = 5,     
        UnknownError = 100
    }
}
