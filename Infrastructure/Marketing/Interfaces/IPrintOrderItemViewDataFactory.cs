using System;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.Data.EntityClasses;

namespace Falcon.Web.Infrastructure.Marketing.Interfaces
{
    
    public interface IPrintOrderItemViewDataFactory
    {

        PrintOrderItemViewData Create(DateTime eventDate, long eventId, string eventName,long printOrderId,
             MarketingPrintOrderItemEntity printOrderItem, PrintOrderItemTrackingEntity printOrderItemTracking,
            string vendorName, string marketingMaterialType, string marketingMaterialName, string placedBy, MarketingOrderShippingInfoEntity printOrderShipping);
    }
}
