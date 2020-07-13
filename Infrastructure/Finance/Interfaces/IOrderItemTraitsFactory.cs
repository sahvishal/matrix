using Falcon.App.Core.Enum;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IOrderItemTraitsFactory
    {
        IOrderItemTraits CreateTraits(OrderItemType orderItemType);
    }
}