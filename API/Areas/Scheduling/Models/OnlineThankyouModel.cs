using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Models
{
    public class OnlineThankyouModel
    {
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public EventCustomerOrderSummaryModel EventCustomerOrderSummaryModel { get; set; }
        public GoogleAnalyticsEnableReportingDataModel GoogleAnalyticsReportingDataModel { get; set; }
    }
}