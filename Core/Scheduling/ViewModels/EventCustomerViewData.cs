using System;
using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerViewData
    {
        public long CustomerId { get; set; }

        public long EventId { get; set; }
        public string EventName { get; set; }
        public EventStatus EventStatus { get; set; }
        public DateTime EventDate { get; set; }
        public Address EventAddress { get; set; }

        public long AppointmentId { get; set; }
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }

        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal PackagePrice { get; set; }
        public string AdditinalTest { get; set; }

        public long EventCustomerId { get; set; }
        public long CustomerEventTestId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string MarketingSource { get; set; }
        public DateTime EventSignupDate { get; set; }
        public RegulatoryState HipaaStatus { get; set; }
        public bool NoShow { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsManuallyVerified { get; set; }
        public bool IsClinicalFormPdfGenerated { get; set; }
        public bool IsResultPdfgenerated { get; set; }
        public bool IsResultReady { get; set; }
        public bool IsColoractelResultReady { get; set; }
        public CustomerEventSignUpMode SignUpMode { get; set; }

        public long OrderId { get; set; }
        public long OrderDetailId { get; set; }

        public long SourceCodeId { get; set; }
        public string SourceCode { get; set; }
        public decimal SourceCodeAmount { get; set; }

        public decimal EffectiveOrderPrice { get; set; }
        public decimal TotalPayment { get; set; }
        public bool IsPaid { get; set; }
        public bool IsShippingApplied { get; set; }
        public decimal TotalShippingCost { get; set; }

        public int ResultStatus { get; set; }

        public long OrganizationRoleUserCreatorId { get; set; }

        public RegulatoryState PartnerRelease { get; set; }
        public AssignedPhysicianViewModel AssignedPhysicians { get; set; }

        public IEnumerable<OrderedPair<string, DateTime>> RoomSlots { get; set; }
        public long AwvVisitId { get; set; }
    }
}