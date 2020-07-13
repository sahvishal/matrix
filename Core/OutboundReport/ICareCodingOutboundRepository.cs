using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface ICareCodingOutboundRepository
    {
        CareCodingOutbound GetByCustomerId(long customerId);

        CareCodingOutbound Save(CareCodingOutbound domain);
    }
}
