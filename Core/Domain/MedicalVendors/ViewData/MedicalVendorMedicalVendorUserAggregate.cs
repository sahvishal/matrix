namespace Falcon.App.Core.Domain.MedicalVendors.ViewData
{
    public class MedicalVendorMedicalVendorUserAggregate
    {
        public MedicalVendorMedicalVendorUser MedicalVendorMedicalVendorUser { get; set; }
        public decimal PayRate { get; set; }
        public int NumberOfEvaluations { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalPayments { get; set; }
        public int EvaluationRate { get; set; }
    }
}