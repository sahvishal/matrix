using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Domain.ViewData
{
    public class MedicalVendorPaymentPodViewData
    {
        public Pod Pod { get; set; }
        public int NumberOfEvaluations { get; set; }
        public decimal AmountEarned { get; set; }
    }
}