using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class AppointmentConfirmationViewModel
    {
        public AppointmentConfirmationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string CustomerName { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime AppointmentTime { get; set; }

        public string LocationName { get; set; }

        public AddressViewModel AddressOfVenue { get; set; }

        public decimal TotalDue { get; set; }

        public decimal PackagePrice { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal AddlnProductPrice { get; set; }

        public string PaymentStatus { get; set; }

        public Package Packages { get; set; }

        public IEnumerable<Test> Tests { get; set; }

        public string HospitalPartnerLogoFilePathUrl { get; set; }

        public bool HasAddlnProduct { get; set; }

        public decimal? DiscountPrice { get; set; }

        public string DiscountCode { get; set; }

        public string PcpPhoneNumber { get; set; }

        public string CustomerFirstName { get; set; }

        public long CustomerId { get; set; }
    }
}