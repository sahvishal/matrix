
using Falcon.App.Core.Application.Attributes;
using System.Collections.Generic;
namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class PreAssessmentCallQueueModel
    {
        public IEnumerable<PreAssessmentCallQueueCustomerList> Data { get; set; }
    }
}
