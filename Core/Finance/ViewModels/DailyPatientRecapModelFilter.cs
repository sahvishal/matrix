using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyPatientRecapModelFilter : ModelFilterBase
    {
        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }
        public string CustomerName { get; set; }
        public long CustomerId { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }
        public long CorporateAccountId { get; set; }
        public long HospitalPartnerId { get; set; }
        public string Pod { get; set; }
        public bool IsHealthPlanEvent { get; set; }
        public string IsGiftCertificateDeleievred { get; set; }
        public string Tag { get; set; }
    }
}
