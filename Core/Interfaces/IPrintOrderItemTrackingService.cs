using System;
using System.Collections.Generic;
using HealthYes.Web.Core.Domain.PrintOrder.Enum;
using HealthYes.Web.Core.Domain.PrintOrder.ViewData;

namespace HealthYes.Web.Core.Interfaces
{
    public interface IPrintOrderItemTrackingService
    {
        List<PrintOrderItemTrackingViewData> GetPrintOrderItemTrackingByFilters(long? eventId, DateTime? eventStartDate,
                                                                                DateTime? eventEndDate,
                                                                                ItemShippingStatus? status,
                                                                                int pageNumber, int pageSize,
                                                                                out long totalRecord);

    }
}
