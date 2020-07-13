using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class OnlineHealthAssessmentQuestionModel
    {
        public HafModel HafModel { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Race { get; set; }
        public decimal? Waist { get; set; }
        public bool IsKynPurchased { get; set; }
    }
}