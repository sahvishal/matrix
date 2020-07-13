using System;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CallOutComeEditModel
    {
        public long CallQueueCustomerId { get; set; }
        public long CallId { get; set; }
        public long CallQueueId { get; set; }
        public long CallStatusId { get; set; }
        public DateTime? CallBackDateTime { get; set; }
        public String Note { get; set; }
        public long CustomerId { get; set; }
        public long ProspectCustomerId { get; set; }
        public bool DoNotCall { get; set; }
        public bool RemoveFromQueue { get; set; }
        public string DispositionAlias { get; set; }

        public long? NotIntrestedReasonId { get; set; }

        public string PhoneHome { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneCell { get; set; }
        public long PhoneHomeConsent { get; set; }
        public long PhoneOfficeConsent { get; set; }
        public long PhoneCellConsent { get; set; }
        public long? ActivityId { get; set; }
    }
}
