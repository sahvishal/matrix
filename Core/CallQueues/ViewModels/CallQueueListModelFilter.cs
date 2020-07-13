using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class CallQueueListModelFilter : ModelFilterBase
    {
        public string Name { get; set; }
        public long CriteriaId { get; set; }
    }
}
