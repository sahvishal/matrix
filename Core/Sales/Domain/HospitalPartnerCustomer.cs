using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class HospitalPartnerCustomer : DomainObjectBase
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public int Status { get; set; }
        public int Outcome { get; set; }
        public long CareCoordinatorOrgRoleUserId { get; set; }
        public string Notes { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
