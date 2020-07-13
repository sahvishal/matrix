using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerListModel
    {
        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public long HostId { get; set; }

        public string HostName { get; set; }

        public string HostContact { get; set; }

        public Address HostAddress { get; set; }

        public string AddressVerifiedBy { get; set; }

        public IEnumerable<Pod> Pods { get; set; }

        public HostFacilityViability HostFacility { get; set; }

        public IEnumerable<EventStaffBasicInfoModel> EventStaff { get; set; }

        public IEnumerable<EventAppointmentSlotDistributionViewModel> EventAppointmentSlotDistributions { get; set; }

        public IEnumerable<EventCustomerViewModel> CanceledCustomers { get; set; }

        public string EmrNotes { get; set; }

        public string AssignedToUserName { get; set; }

        public string AssignedToUserEmail { get; set; }

        public string TechnicianNotes { get; set; }

        public int AvailableProductsCount { get; set; }

        public EventCustomerListModelFilter Filter { get; set; }

        public long CustomerIdforAcceptPayment { get; set; }

        public bool IsDynamicScheduling { get; set; }

        public EventType EventType { get; set; }

        public bool CaptureInsuranceId { get; set; }

        public string Sponsor { get; set; }

        public IEnumerable<OrderedPair<long, string>> HospitalFacilities { get; set; }

        public bool IsKynIntegrationEnabled { get; set; }

        public long HighlightCustomerId { get; set; }

        public bool IsHospitalPartnerEvent { get; set; }

        public bool CaptureAbnStatus { get; set; }

        public bool CapturePcpStatus { get; set; }

        public bool IsBloodworkFormAttached { get; set; }

        public bool CaptureHaf { get; set; }

        public string BloodPackageTracking { get; set; }
        public string RecordsPackageTracking { get; set; }
        public bool BookPcpAppointment { get; set; }
        public bool PrintScreeningInfo { get; set; }
        public bool PrintPatientWorkSheet { get; set; }

        public string OrganizationNameForHraQuestioner { get; set; }
        public string CorporateAccountTag { get; set; }
        public string Token { get; set; }
        public bool IsHealthPlanEvent { get; set; }

        public bool ShowBarrier { get; set; }
        public bool ShowCheckListForm { get; set; }
        public bool ShowMicroalbuminForm { get; set; }
        public bool ShowIFOBTForm { get; set; }

        public bool ShowHraQuestionnaire { get; set; }
        public bool ShowChatQuestionnaire { get; set; }

        public string HraQuestionerAppUrl { get; set; }
        public string ChatQuestionerAppUrl { get; set; }
        public bool ShowChaperonForm { get; set; }

        //public QuestionnaireType QuestionnaireType { get; set; }
    }
}