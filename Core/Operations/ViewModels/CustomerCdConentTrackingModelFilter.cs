using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CustomerCdConentTrackingModelFilter : ModelFilterBase
    {
        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public long EventId { get; set; }
    }
}
