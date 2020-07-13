using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class CorporateCustomerCustomTag : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public string Tag { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public bool IsActive { get; set; }
        public CorporateCustomerCustomTag()
        {}
        public CorporateCustomerCustomTag(long customerTagId)
            : base(customerTagId)
        {}
    }
}
