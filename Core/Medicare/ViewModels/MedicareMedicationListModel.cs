using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareMedicationListModel
    {
        public MedicareMedicationViewModel[] Medication { get; set; }
        public string AuthToken { get; set; }
        public string OrganizationName { get; set; }
    }
}
