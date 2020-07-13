using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventCustomerResultStatusListModel
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }
        [DisplayName("Host")]
        public string Host { get; set; }
        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }
        [DisplayName("Location")]
        public AddressViewModel Address { get; set; }
        public IEnumerable<CustomerResultStatusViewModel> Customers { get; set; }
        [IgnoreAudit]
        public IEnumerable<Test> EventTests { get; set; }
        public string EmrNotes { get; set; }
        public IEnumerable<OrderedPair<long, string>> HospitalFacilities { get; set; }
        [IgnoreAudit]
        public bool IsKynIntegrationEnabled { get; set; }
        public EventCustomerResultStatusListModelFilter Filter { get; set; }
        [IgnoreAudit]
        public bool IsHospitalPartnerEvent { get; set; }
        [IgnoreAudit]
        public bool CaptureAbnStatus { get; set; }
        [IgnoreAudit]
        public bool CaptureHaf { get; set; }
        [IgnoreAudit]
        public string BloodPackageTracking { get; set; }
        [IgnoreAudit]
        public string RecordsPackageTracking { get; set; }
        [IgnoreAudit]
        public long RoleId { get; set; }
        [IgnoreAudit]
        public long AccountId { get; set; }
        [IgnoreAudit]
        public bool IsHealthPlan { get; set; }
        [IgnoreAudit]
        public bool PrintCheckList { get; set; }
    }
}