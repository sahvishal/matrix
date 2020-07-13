using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class SurveyEmailNotificationModel
    {
        public SurveyEmailNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public Name CustomerName { get; set; }

        public long CustomerId { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public string PodName { get; set; }

        public string CustomerEmail { get; set; }

        public string HospitalPartnerLogoFilePathUrl { get; set; }

    }
}