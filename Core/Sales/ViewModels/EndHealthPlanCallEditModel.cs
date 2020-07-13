using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Sales.ViewModels
{
    [NoValidationRequired]
    public class EndHealthPlanCallEditModel
    {
        public long CallQueueCustomerId { get; set; }
        public long CallId { get; set; }
        public string SelectedDisposition { get; set; }
        public long CallOutcomeId { get; set; }
        public string SkipCallNote { get; set; }
        public bool IsSkipped { get; set; }
        public long AttemptId { get; set; }
    }
}
