using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Operations.Enum;

namespace Falcon.App.Core.Operations.Domain
{
    public class ShippingDetail : DomainObjectBase
    {
        public ShippingOption ShippingOption { get; set; }
        public Address ShippingAddress { get; set; }
        public DateTime? ShipmentDate { get; set; }

        public ShipmentStatus Status { get; set; }
        public decimal ActualPrice { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public bool IsExclusivelyRequested { get; set; }

        public long? ShippedByOrgRoleUserId { get; set; }

        public ShippingDetail()
        { }

        public ShippingDetail(long shippingDetailId)
            : base(shippingDetailId)
        { }
    }
}
