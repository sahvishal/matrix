using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.ViewModels;

namespace Falcon.App.Core.OutboundReport
{
    public interface ICareCodingOutboundFactory
    {
        CareCodingOutbound Create(CareCodingOutboundViewModel model);
    }
}
