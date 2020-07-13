using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IShippingDetailOrderDetailRepository : IRepository<ShippingDetailOrderDetail>
    {
        IEnumerable<ShippingDetailOrderDetail> GetForOrderDetailId(long orderDetailId);
        bool UpdateStatus(long shippingDetailId, long orderDetailId, bool status);
    }
}
