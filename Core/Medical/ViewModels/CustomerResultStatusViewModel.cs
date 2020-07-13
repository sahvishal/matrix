using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerResultStatusViewModel
    {
        public long EventCustomerId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OrderPurchased { get; set; }

        public AddressViewModel Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool IsPremiumVersionPdfGenerated { get; set; }
        public bool IsClinicalFormGenerated { get; set; }

        public RegulatoryState HipaaStatus { get; set; }
        public RegulatoryState PartnerRelease { get; set; }

        public IEnumerable<TestResultStatusViewModel> TestResults { get; set; }
        public IEnumerable<NotesViewModel> Notes { get; set; }

        public AssignedPhysicianViewModel AssignedPhysicians { get; set; }

        public string PhysicianComments { get; set; }

        public long? InQueuePriority { get; set; }
        public long? HospitalFacilityId { get; set; }
        public bool IsPaid { get; set; }

        public RegulatoryState AbnStatus { get; set; }

        public RegulatoryState PcpConsentStatus { get; set; }

        public bool CapturePcpConsent { get; set; }

        public RegulatoryState InsuranceReleaseStatus { get; set; }

        public string AcesId { get; set; }

        public bool IsChartSigned { get; set; }

        public bool IsCodingCompleted { get; set; }

        public DateTime? InvoicingDate { get; set; }

        public bool IsIpResultGenerated { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public bool IsAnyTestinHip { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<EventCustomerResultStatusListModelFilter>))]
    public class EventResultStatusListModelFilterValidator : AbstractValidator<EventCustomerResultStatusListModelFilter>
    {
        public EventResultStatusListModelFilterValidator()
        {

        }
    }
}
