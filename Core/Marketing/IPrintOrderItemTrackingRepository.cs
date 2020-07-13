using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Marketing
{
    public interface IPrintOrderItemTrackingRepository
    {
        PrintOrderItemTracking GetById(long printOrderItemShippingId);
        void Save(PrintOrderItemTracking printOrderItemShipping);

        List<PrintOrderItemViewData> GetPrintOrderItemTrackingDetailByFilters(long? eventId,
                                                                                      DateTime? eventStartDate,
                                                                                      DateTime? eventEndDate,
                                                                                      ItemStatus? status,
             long? orderBySalesRepId,
            int pageNumber, int pageSize,
            out long totalRecord);
        PrintOrderItemTrackingViewData GetPrintOrderItemTrackingDetail(long printOrderItemId);
       
    }

      
}
