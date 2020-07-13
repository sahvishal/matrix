using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IOrderViewDataFactory
    {
        OrderViewData Create(OrderDetail orderDetail);
        OrderViewData Create(long orderDetailId);
    }
}