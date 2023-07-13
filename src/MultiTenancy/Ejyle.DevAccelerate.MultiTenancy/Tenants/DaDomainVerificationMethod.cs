using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.MultiTenancy.Tenants
{
    public enum DaDomainVerificationMethod
    {
        HTMLFile = 0,
        MetaTag = 1,
        TXTDNSRecord = 2,
        CNAMEDNSRecord = 3,
        MXDNSRecord = 4,
        Other = 100
    }
}
