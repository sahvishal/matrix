using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;

namespace API.Areas.Finance.Models
{
    [NoValidationRequired]
    public class CustomerRefundRequest : ResponseBaseModel
    {
        public long OrderId { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public string Reason { get; set; }
        public long RefundRequestType { get; set; }
        public decimal RequestedRefundAmount { get; set; }
        public RefundRequestResult RefundRequestResult { get; set; }
        public long RequestedByOrgRoleUserId { get; set; }
        public DateTime RequestedOn { get; set; }
        public long RequestStatus { get; set; }
    }
}