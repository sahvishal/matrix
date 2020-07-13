using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Domain.MedicalVendors.ViewData
{
    public class MedicalVendorAggregate
    {
        public MedicalVendor MedicalVendor { get; set; }
        public int NumberOfDoctors { get; set; }
        public int TotalNumberOfEvaluations { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalPayments { get; set; }
        public int AverageEvaluationsPerDay { get; set; }
        public decimal AverageEarningsPerDay { get; set; }
    }
}