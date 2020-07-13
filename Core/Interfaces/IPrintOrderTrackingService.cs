using System;
using System.Collections.Generic;
using HealthYes.Web.Core.Domain.PrintOrder.Enum;
using HealthYes.Web.Core.Domain.PrintOrder.ViewData;

namespace HealthYes.Web.Core.Interfaces
{
    public interface IPrintOrderTrackingService
    {
        List<PrintOrderItemTrackingViewData> GetPrintOrderItemTrackingByFilters(long? eventId, DateTime? depositStartDate,
                                                               DateTime? depositEndDate,
                                                               ItemShippingStatus? printOrderItemShippingStatus, int pageNumber, int pageSize, out long totalRecord
                                                               );

    }
}