using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Insurance.Domain
{
    public class Claim : DomainObjectBase
    {
        public long EncounterId { get; set; }
        public long InsurancePaymentId { get; set; }
        public long BillingPatientId { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public int Units { get; set; }
        public decimal UnitCharge { get; set; }
        public decimal TotalCharges { get; set; }
        public decimal AdjustedCharges { get; set; }
        public decimal Receipts { get; set; }
        public decimal PatientBalance { get; set; }
        public decimal InsuranceBalance { get; set; }
        public decimal TotalBalance { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? FirstBillDate { get; set; }
        public DateTime? LastBillDate { get; set; }
    }
}
