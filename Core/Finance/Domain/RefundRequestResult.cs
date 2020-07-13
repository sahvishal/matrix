using System;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class RefundRequestResult
    {
        public long RequestId { get; set; }
        public decimal RefundAmount { get; set; }
        public RequestResultType RequestResultType { get; set; }
        public string Notes { get; set; }
        public long? OrderId { get; set; } // In Case of Gift Certificate being issued

        public long ProcessedByOrgRoleUserId { get; set; }
        public DateTime ProcessedOn { get; set; }

        public RefundRequestResult()
        {

        }

        public RefundRequestResult(long requestId)
        {
            RequestId = requestId;
        }
    }
}