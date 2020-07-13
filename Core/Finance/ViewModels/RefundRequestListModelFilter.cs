using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class RefundRequestListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [DisplayName("Date Type")]
        public int DateType { get; set; }
        [DisplayName("Refund Type")]
        public int RefundType { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("Status")]
        public long RefundRequestStatus { get; set; }
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        public RefundRequestListModelFilter()
        {
            RefundRequestStatus = (int)RequestStatus.Pending;
        }
    }
}