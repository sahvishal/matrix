using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class AppointmentBookedInTwentyFourHoursNotificationModel
    {
        public AppointmentBookedInTwentyFourHoursNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Address AddressOfCustomer { get; set; }

        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        public DateTime AppointmentTime { get; set; }

        public AddressViewModel AddressOfVenue { get; set; }

        

        public decimal TotalDue { get; set; }

        public decimal PackagePrice { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal AddlnProductPrice { get; set; }

        public string PaymentStatus { get; set; }

        public Package Packages { get; set; }

        public IEnumerable<Test> Tests { get; set; }

    }
}
