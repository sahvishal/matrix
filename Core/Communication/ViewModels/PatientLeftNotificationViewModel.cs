using System;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class PatientLeftNotificationViewModel
    {
        public PatientLeftNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MemberId { get; set; }
        public DateTime EventDate { get; set; }
        public long EventId { get; set; }
        public AddressViewModel EventLocation { get; set; }
        public string User { get; set; }
        public string Reason { get; set; }
        public string Tag { get; set; }
        public string Pod { get; set; }
        public string Notes { get; set; }
    }
}
