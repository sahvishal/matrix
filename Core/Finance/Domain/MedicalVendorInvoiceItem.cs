using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class MedicalVendorInvoiceItem : DomainObjectBase
    {
        public long MedicalVendorInvoiceId { get; set; }
 
        public DateTime ReviewDate { get; set; }
        public decimal MedicalVendorAmountEarned { get; set; }
        public decimal OrganizationRoleUserAmountEarned { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }

        public long PodId { get; set; }
        public string PodName { get; set; }
        public string PackageName { get; set; }

        public DateTime? EvaluationStartTime { get; set; }
        public DateTime? EvaluationEndTime { get; set; }

        public MedicalVendorInvoiceItem()
        {}

        public MedicalVendorInvoiceItem(long medicalVendorInvoiceItemId)
            : base(medicalVendorInvoiceItemId)
        {}
    }
}