using System;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.Web.Infrastructure.Marketing.Interfaces;
using Falcon.Data.EntityClasses;


namespace Falcon.App.Infrastructure.Factories.PrintOrder
{
    public class PrintOrderItemViewDataFactory : IPrintOrderItemViewDataFactory
    {
        public PrintOrderItemViewData Create(DateTime eventDate, long eventId, string eventName,long printOrderId,
             MarketingPrintOrderItemEntity printOrderItem,PrintOrderItemTrackingEntity printOrderItemTracking,
            string vendorName, string marketingMaterialType, string marketingMaterialName, string placedBy,
            MarketingOrderShippingInfoEntity printOrderShipping)
        {
            var itemFactory = new PrintOrderItemFactory();
            
            return new PrintOrderItemViewData
                       {
                           EventDate = eventDate,
                           EventId = eventId,
                           EventName = eventName,
                           PrintOrderId =  printOrderId,
                           MarketingMaterialType = marketingMaterialType,
                           MarketingMaterialName = marketingMaterialName,
                           PrintOrderItem = itemFactory.CreatePrintOrderItem(printOrderItem, printOrderItemTracking, printOrderShipping),
                           PrintVendor = vendorName,
                           OrderPlacedBy = placedBy
                       };

        }
    }
}
