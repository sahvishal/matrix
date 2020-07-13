using Falcon.App.Core.Marketing.ViewModels;
using Falcon.Data.EntityClasses;


namespace Falcon.Web.Infrastructure.Marketing.Interfaces
{

    public interface IPrintOrderItemTrackingViewDataFactory
    {

        PrintOrderItemTrackingViewData Create(MarketingPrintOrderItemEntity itemEntity, string assignedByName,
            string assignedForName, string assignedVendor, PrintOrderItemTrackingEntity trackingEntity 
            );
    }
}
