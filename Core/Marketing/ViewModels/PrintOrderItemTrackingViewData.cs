using Falcon.App.Core.Domain.PrintOrder.Enum;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PrintOrderItemTrackingViewData
    {
        public string DraftedDate { get; set; }
        public string DraftedBy { get; set; }
        public string DraftedFor { get; set; }

        public string ShippedDate { get; set; }
        public string ShippedBy { get; set; }
        public string TrackingNo { get; set; }
        public string ShippedVia { get; set; }

        public string AcknowledgementDate { get; set; }
        public string AcknowledgeBy { get; set; }
        public string AcknowledgeVia { get; set; }
        public ItemStatus Status { get; set; }

    }
}
