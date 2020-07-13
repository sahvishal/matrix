using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderSynchronizationService
    {
        Finance.Domain.Order SynchronizeOrder(Finance.Domain.Order oldOrder, Finance.Domain.Order newOrder, SourceCodeOrderDetail newSourceCodeOrderDetail);
    }
}