using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareStandingOrderViewModel
    {
        public long PatientVisitId { get; set; }
        public int Version { get; set; }
        public bool IsSync { get; set; }
        public IEnumerable<MedicareCheckListQuestionViewModel> Questions { get; set; }
    }
}
