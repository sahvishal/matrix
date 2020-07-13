using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderReceiptService
    {
        List<TestViewData> GetOrderTestViewData(long eventId, long customerId);

    }
}