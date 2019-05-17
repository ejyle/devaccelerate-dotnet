using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements
{
    public class DaUserAgreementVersionAction : DaUserAgreementVersionAction<int, DaUserAgreementVersion>
    {
        public DaUserAgreementVersionAction() : base()
        { }
    }

    public class DaUserAgreementVersionAction<TKey, TUserAgreementVersion> : DaEntityBase<TKey>, IDaUserAgreementVersionAction<TKey>
        where TKey : IEquatable<TKey>
        where TUserAgreementVersion : IDaUserAgreementVersion<TKey>
    {
        public TKey UserAgreementVersionId { get; set; }
        public TKey UserId { get; set; }
        public TKey TenantId { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string IpAddress { get; set; }
        public string DeviceAgent { get; set; }
        public DaUserAgreementVersionActionOwner ActionOwner { get; set; }
        public DaUserAgreementVersionActionType ActionType { get; set; }
        public virtual TUserAgreementVersion UserAgreementVersion { get; set; }
    }
}
