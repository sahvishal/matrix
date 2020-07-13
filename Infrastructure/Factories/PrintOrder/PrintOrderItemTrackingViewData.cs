using System;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.Web.Infrastructure.Marketing.Interfaces;
using Falcon.Data.EntityClasses;
namespace Falcon.App.Infrastructure.Factories.PrintOrder
{
    public class PrintOrderItemTrackingViewDataFactory : IPrintOrderItemTrackingViewDataFactory
    {
        public PrintOrderItemTrackingViewData Create(MarketingPrintOrderItemEntity itemEntity, string assignedByName,
            string assignedForName, string assignedVendor, PrintOrderItemTrackingEntity trackingEntity)
        {
            var printOrderItemTrackingViewData = new PrintOrderItemTrackingViewData();

            printOrderItemTrackingViewData.DraftedDate = itemEntity.DateCreated.ToString("MMM dd yyyy  @ hh:mm tt");
            printOrderItemTrackingViewData.DraftedBy = assignedByName;
            printOrderItemTrackingViewData.DraftedFor = assignedForName;

            if (trackingEntity != null)
            {
                printOrderItemTrackingViewData.ShippedBy = assignedVendor;
                printOrderItemTrackingViewData.Status = (ItemStatus)itemEntity.Status;
                printOrderItemTrackingViewData.TrackingNo = trackingEntity.TrackingNumber;
                printOrderItemTrackingViewData.ShippedVia = trackingEntity.ShippingService;
                printOrderItemTrackingViewData.ShippedDate = trackingEntity.DateCreated.ToString("MMM dd yyyy  @ hh:mm tt");

                if (itemEntity.Status == (long)ItemStatus.Confirmed)
                {
                    printOrderItemTrackingViewData.AcknowledgeBy = trackingEntity.ConfirmedBy;
                    printOrderItemTrackingViewData.AcknowledgementDate = ((DateTime)trackingEntity.ActualDeliveryDate).ToString("MMM dd yyyy  @ hh:mm tt");
                    printOrderItemTrackingViewData.AcknowledgeVia = ((ItemConfirmationMode)trackingEntity.ConfirmationMode).ToString();


                }

            }


            return printOrderItemTrackingViewData;


        }
    }
}
