using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderFactory
    {
        Finance.Domain.Order CreateNewOrder(OrderType orderType, long dataRecorderCreatorId);
        Finance.Domain.Order CreateDuplicateOrder(Finance.Domain.Order order);
    }
}