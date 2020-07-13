using Falcon.App.Core.Application.Attributes;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class ChaperoneFormModel
    {
        public long EventCustomerId { get; set; }

        public IEnumerable<ChaperoneAnswerModel> CustomerAnswers { get; set; }

        public string PatientSignatureBytes { get; set; }

        public string StaffSignatureBytes { get; set; }
    }
}
