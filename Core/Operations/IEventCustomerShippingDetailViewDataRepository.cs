using System.Collections.Generic;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IEventCustomerShippingDetailViewDataRepository
    {
        List<EventCustomerShippingDetailViewData> GetEventCustomerShippingDetailViewDatas(int shipmentStatus,
                                                                                          long shippingOptionId,
                                                                                          long eventId,
                                                                                          string eventStartDate,
                                                                                          string eventEndDate,
                                                                                          long podId,
                                                                                          bool resultsAreReady,
                                                                                          int pageIndex, int pageSize);
    }
}