using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class DaUserAgreementVersionAction<TKey, TUserAgreementVersion> : DaAuditedEntityBase<TKey>, IDaUserAgreementVersionAction<TKey>
        where TKey : IEquatable<TKey>
        where TUserAgreementVersion : IDaUserAgreementVersion<TKey>
    {
        [Required]
        public TKey UserAgreementVersionId { get; set; }

        [Required]
        public TKey UserId { get; set; }

        [Required]
        public TKey TenantId { get; set; }
        public string? IpAddress { get; set; }
        public string? DeviceAgent { get; set; }

        [Required]
        public DaUserAgreementVersionActionOwner ActionOwner { get; set; }

        [Required]
        public DaUserAgreementVersionActionType ActionType { get; set; }
        public virtual TUserAgreementVersion UserAgreementVersion { get; set; }
    }
}
