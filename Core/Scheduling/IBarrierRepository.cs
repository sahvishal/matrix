using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface IBarrierRepository
    {
        IEnumerable<OrderedPair<string, long>> GetBarrierCategoryIdNamePairs();
        void Save(EventCustomerBarrier model);
        EventCustomerBarrier GetCustomerBarrierByEventCustomerId(long eventCustomerId);
        IEnumerable<EventCustomerBarrier> GetCustomerBarrierByEventCustomerIds(IEnumerable<long> eventCustomerIds);
        IEnumerable<EventCustomerBarrier> GetForBarrierInboundReport(BarrierInboundFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<Barrier> GetByIds(long[] ids);
    }
}
