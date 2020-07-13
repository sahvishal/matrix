using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class QualificationRecommendationLogic
    {
        public string RecommendationLogic { get; set; }
        public string DisqualificationLogic { get; set; }
    }
}