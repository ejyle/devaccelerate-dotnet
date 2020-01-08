using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Facades.Security.Authorization
{
    public class DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>
        where TKey : IEquatable<TKey>
        where TAuthorizationInfo : IDaAuthorizationInfo<TKey, TAuthorizedActionInfo>
        where TAuthorizedActionInfo : IDaAuthorizedActionInfo<TKey>
    {
        public DaAuthorizationResult(TAuthorizationInfo authorizationInfo)
        {
            if(authorizationInfo == null)
            {
                throw new ArgumentNullException(nameof(authorizationInfo));
            }

            Status = DaAuthorizationStatus.Success;
            AuthorizationInfo = authorizationInfo;
        }

        public DaAuthorizationResult(DaAuthorizationStatus status)
        {
            if(status == DaAuthorizationStatus.Success)
            {
                throw new InvalidOperationException("The status cannot be Success when this consutructor is used.");
            }

            Status = status;
            AuthorizationInfo = default(TAuthorizationInfo);
        }

        public TAuthorizationInfo AuthorizationInfo
        {
            private set;
            get;
        }

        public DaAuthorizationStatus Status
        {
            private set;
            get;
        }
    }
}
