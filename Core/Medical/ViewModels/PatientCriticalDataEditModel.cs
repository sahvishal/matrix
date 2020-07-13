using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class PatientCriticalDataEditModel
    {
        public long EventCustomerId { get; set; }

        public IEnumerable<CriticalQuestionAnswerEditModel> Answers { get; set; }
    }
}
