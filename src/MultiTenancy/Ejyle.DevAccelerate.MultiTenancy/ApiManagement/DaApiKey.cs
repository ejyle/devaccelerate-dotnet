using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.MultiTenancy.ApiManagement
{
    public class DaApiKey : DaApiKey<string>
    { }
    
    public class DaApiKey<TKey> : DaEntityBase<TKey>, IDaApiKey<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey TenantId { get; set;  }
        public string ApiKey { get; set;  }
        public string Salt { get; set;  }
        public string SecretKey { get; set;  }
        public bool IsActive { get; set;  }
        public bool IsExpired { get; set;  }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? ExpiryDateUtc { get; set;  }
    }
}
