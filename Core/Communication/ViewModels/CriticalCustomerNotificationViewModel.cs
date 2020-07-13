using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class CriticalCustomerNotificationViewModel
    {
        public CriticalCustomerNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public long CustomerId { get; set; }
        public string MemberId { get; set; }
        public DateTime EventDate { get; set; }
        public long EventId { get; set; }
        public string Pod { get; set; }
        public string HospitalPartner { get; set; }
        public string HealthPlan { get; set; }
        public string TestName { get; set; }
        //public IEnumerable<CustomerEventCriticalTestDataViewModel> Tests { get; set; }
    }
}
