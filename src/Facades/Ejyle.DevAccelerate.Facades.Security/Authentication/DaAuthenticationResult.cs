using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ejyle.DevAccelerate.Facades.Security.Authentication
{
    public class DaAuthenticationResult<TKey> : SignInResult
        where TKey : IEquatable<TKey>
    {
        public bool IsNotActive
        {
            get;
            protected set;
        }

        public bool IsSuspended
        {
            get;
            protected set;
        }

        public bool IsDeleted
        {
            get;
            protected set;
        }

        public bool IsClosed
        {
            get;
            protected set;
        }

        public bool IsTenantNotActive
        {
            get;
            protected set;
        }

        public List<TKey> Tenants
        {
            get;
            protected set;
        }

        public static DaAuthenticationResult<TKey> SuccessWithTenants(List<TKey> tenants)
        {
            var result = Success as DaAuthenticationResult<TKey>;
            result.Tenants = tenants;
            return result;
        }

        public static DaAuthenticationResult<TKey> NotActive
        {
            get
            {
                return new DaAuthenticationResult<TKey>()
                {
                    IsNotActive = true
                };
            }
        }

        public static DaAuthenticationResult<TKey> TenantNotActive
        {
            get
            {
                return new DaAuthenticationResult<TKey>()
                {
                    IsTenantNotActive = true
                };
            }
        }

        public static DaAuthenticationResult<TKey> Suspended
        {
            get
            {
                return new DaAuthenticationResult<TKey>()
                {
                    IsSuspended = true
                };
            }
        }

        public static DaAuthenticationResult<TKey> Closed
        {
            get
            {
                return new DaAuthenticationResult<TKey>()
                {
                    IsClosed = true
                };
            }
        }

        public static DaAuthenticationResult<TKey> Deleted
        {
            get
            {
                return new DaAuthenticationResult<TKey>()
                {
                    IsDeleted = true
                };
            }
        }
    }
}
