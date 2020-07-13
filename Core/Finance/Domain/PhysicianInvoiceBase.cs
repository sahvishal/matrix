using System;
using System.Text;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public abstract class PhysicianInvoiceBase : DomainObjectBase
    {
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PayPeriodStartDate { get; set; }
        public DateTime PayPeriodEndDate { get; set; }

        public string PayPeriodString { get { return PayPeriodStartDate.ToShortDateString() + " - " + 
                                                     PayPeriodEndDate.ToShortDateString(); } }

        public DateTime DateGenerated { get; set; }
        public long MedicalVendorId { get; set; }
        public string MedicalVendorName { get; set; }
        public string MedicalVendorAddress { get; set; }
        public Guid ApprovalGuid { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public long PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DatePaid { get; set; }

        public abstract decimal InvoiceAmount { get; }
        public abstract int NumberOfEvaluations { get; }

        protected PhysicianInvoiceBase()
        {}

        protected PhysicianInvoiceBase(long medicalVendorInvoiceId)
            : base(medicalVendorInvoiceId)
        {}

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(MedicalVendorName);
            stringBuilder.Append(" | " + PhysicianName);
            stringBuilder.Append(" | " + PayPeriodString);
            stringBuilder.Append(" | #" + Id);
            return stringBuilder.ToString();
        }
    }
}