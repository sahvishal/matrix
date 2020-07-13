using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class CustomerHafEditModel 
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public long Gender { get; set; }
        public IEnumerable<HealthAssessmentQuestionEditModel> QuestionEditModels { get; set; }
    }
}