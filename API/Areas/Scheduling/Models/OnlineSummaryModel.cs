using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Models
{
    public class OnlineSummaryModel
    {
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public EventCustomerOrderSummaryModel EventCustomerOrderSummaryModel { get; set; }
    }
}