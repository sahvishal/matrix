using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class ExitInterviewAnswerModel
    {
        public long EventCustomerId { get; set; }

        public IEnumerable<ExitInterviewAnswerSignatureModel> Answers { get; set; }
    }
}
