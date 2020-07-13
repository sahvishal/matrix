using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Insurance.Domain
{
    public class BillingAccount : DomainObjectBase
    {
        public string Name { get; set; }
        public string CustomerKey { get; set; }
        public string UserName { get; set; }
        [IgnoreAudit]
        public string Password { get; set; }
    }
}
