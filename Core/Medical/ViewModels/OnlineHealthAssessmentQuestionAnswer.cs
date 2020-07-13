using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class OnlineHealthAssessmentQuestionAnswer
    {
        public string Guid { get; set; }
        public IEnumerable<HealthAssessmentQuestionEditModel> QuestionEditModels { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }
        public int Race { get; set; }
        public decimal? Waist { get; set; }
        public bool IsKynPurchased { get; set; }
    }
}