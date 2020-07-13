namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareCustomerSetupViewModel
    {
        public long PatientId { get; set; }
        public long PatientVisitId { get; set; }
        public bool IsVisitTypeKnown { get; set; }
    }
}
