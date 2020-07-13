using Falcon.App.Core.Marketing.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Marketing.Interfaces
{
    public interface IPrintOrderItemFactory
    {
        PrintOrderItem CreatePrintOrderItem(MarketingPrintOrderItemEntity printOrderItemEntity);



    }
}