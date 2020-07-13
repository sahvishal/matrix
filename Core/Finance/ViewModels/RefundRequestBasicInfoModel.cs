using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class RefundRequestBasicInfoModel : ViewModelBase
    {
        [Hidden]
        public long RequestId { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [Hidden]
        public long OrderId { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [DisplayName("Event Name")]
        public string HostName { get; set; }

        [DisplayName("Event Address")]
        public Address HostAddress { get; set; }

        [DisplayName("Refund Amount")]
        public decimal RequestedRefundAmount { get; set; }

        [DisplayName("Refund Reason")]
        public string ReasonforRefund { get; set; }

        [Hidden]
        public RefundRequestType RefundRequestType { get; set; }

        [DisplayName("Request Type")]
        public string RequestType
        {
            get
            {
                return RefundRequestType.GetDescription();
            }
        }

        [DisplayName("Booked By")]
        public string BookedBy { get; set; }

        [DisplayName("Booked By Role")]
        public string BookedByRole { get; set; }

        [DisplayName("Requested By")]
        public string RequestedBy { get; set; }

        [DisplayName("Requested By Role")]
        public string RequestedByRole { get; set; }

        [DisplayName("Requested On")]
        [Format("MM/dd/yyyy")]
        public DateTime RequestedOn { get; set; }

        [DisplayName("Status")]
        public RequestStatus Status { get; set; }

        [Hidden]
        public RequestResultType? RequestResultType { get; set; }

        public string Action
        {
            get
            {
                return RequestResultType.HasValue && (int)RequestResultType.Value > 0 ? RequestResultType.GetDescription() : "";
            }
        }

        [DisplayName("Processed By")]
        public string RequestProcessedBy { get; set; }

        [DisplayName("Processed By Role")]
        public string RequestProcessedByRole { get; set; }

        [DisplayName("Processed On")]
        [Format("MM/dd/yyyy")]
        public DateTime? RequestProcessedOn { get; set; }

        public string CancellationReason { get; set; }

        public string SubReason { get; set; }

        [Hidden]
        public string RequestProcessedNotes { get; set; }

        //for export to csv
        public string Notes
        {
            get
            {
                return string.IsNullOrEmpty(RequestProcessedNotes)
                    ? ""
                    : RequestProcessedNotes.Replace("<b>", "")
                        .Replace("</b>", "")
                        .Replace("<i>", "")
                        .Replace("</i>", "")
                        .Replace("<br />", "\r\n");
            }
        }

    }
}