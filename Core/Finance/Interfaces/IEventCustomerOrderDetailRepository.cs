using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IEventCustomerOrderDetailRepository : IRepository<EventCustomerOrderDetail>
    {
        bool UpdateStatus(long eventCustomerId, long orderDetailId, bool status);
        IEnumerable<EventCustomerOrderDetail> GetForOrderDetailId(long orderDetailId);
    }

}
