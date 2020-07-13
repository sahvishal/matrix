using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class RefundRequest : DomainObjectBase
    {
        public long OrderId { get; set; }
        public long  EventId { get; set; }
        public long  CustomerId { get; set; }

        public string Reason { get; set; }
        public RefundRequestType RefundRequestType { get; set; }
        public decimal RequestedRefundAmount { get; set; }

        public RefundRequestResult RefundRequestResult { get; set; }

        public long RequestedByOrgRoleUserId { get; set; }
        public DateTime RequestedOn { get; set; }
        public long RequestStatus { get; set; }

        public RefundRequest()
        {
            
        }

        public RefundRequest(long requestId)
            : base(requestId)
        {
        }

        public const string ProcessRequest = "ProcessRequest";
        public const string ProcessRequestId = "ProcessRequestId";

    }
}