using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueEstimatedCustomerReportModel
    {
        public CallQueueEstimatedCustomer CallQueueEstimatedCustomer { get; set; }
        public OutboundCallQueueFilter Filter { get; set; }

        public HealthPlanCallQueueCriteria CallQueueCriteria { get; set; }
        public string HealthPlanName { get; set; }
        public string CallQueueName { get; set; }
        public string CallQueueCategory { get; set; }
    }
}
