using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerCustomerListModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public long HospitalPartnerId { get; set; }

        public long CustomerId { get; set; }

        public string Pod { get; set; }

        public string CustomerName { get; set; }

        public long CorporateAccountId { get; set; }

        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsHospitalPartnerAttached { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }

        public long ResultSummary { get; set; }
        public long Status { get; set; }
        public int DateType { get; set; }

        public string PhoneNumber { get; set; }

        public int SortingColumn { get; set; }
        public int SortingOrder { get; set; }

        public bool CriticalMarkedByTechnician { get; set; }

        public long HospitalFacilityId { get; set; }
    }
}
