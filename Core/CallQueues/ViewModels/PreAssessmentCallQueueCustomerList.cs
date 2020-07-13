

using Falcon.App.Core.Application.Attributes;
namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class PreAssessmentCallQueueCustomerList
    {
        public long EventID { get; set; }
        public long CustomerId { get; set; }
        public bool IsAssessmentCompleted { get; set; }
    }
}
