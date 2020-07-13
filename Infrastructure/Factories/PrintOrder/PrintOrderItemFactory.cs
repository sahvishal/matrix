using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.PrintOrder;
using System.Linq;
using Falcon.App.Infrastructure.Marketing.Interfaces;
using Falcon.Data.EntityClasses;


namespace Falcon.App.Infrastructure.Factories.PrintOrder
{

    public class PrintOrderItemFactory : IPrintOrderItemFactory
    {
        private readonly DomainEntityMapper<PrintOrderItemTracking, PrintOrderItemTrackingEntity> _mapper;

        public PrintOrderItemFactory()
            : this(new PrintOrderItemTrackingMapper())
        { }

        public PrintOrderItemFactory(DomainEntityMapper<PrintOrderItemTracking, PrintOrderItemTrackingEntity> mapper)
        {
            _mapper = mapper;
        }
        public MarketingPrintOrderItemEntity CreatePrintOrderItemEntity(PrintOrderItem printOrderItem)
        {
            return new MarketingPrintOrderItemEntity(printOrderItem.PrintOrderItemId)
                       {
                           Quantity = (int?)printOrderItem.Quantity,
                           IsNew = printOrderItem.PrintOrderItemId == 0,
                           Sourcecode = printOrderItem.SourceCode,

                       };
        }

        public PrintOrderItem CreatePrintOrderItem(MarketingPrintOrderItemEntity printOrderItemEntity)
        {
            return new PrintOrderItem(printOrderItemEntity.MarketingPrintOrderItemId)
                       {
                           SourceCode = RemoveSourceCodeIdFromPrintOrderItemEntity(printOrderItemEntity.Sourcecode),
                           Quantity = printOrderItemEntity.Quantity != null ? (long)printOrderItemEntity.Quantity : 0,
                           TrackingInfo =
                               printOrderItemEntity.PrintOrderItemTracking.Select(poit => _mapper.Map(poit)).
                               SingleOrDefault(),
                           Status =(ItemStatus) printOrderItemEntity.Status
                       };

        }

        public PrintOrderItem CreatePrintOrderItem(MarketingPrintOrderItemEntity printOrderItemEntity,
            PrintOrderItemTrackingEntity printOrderItemTrackingEntity,MarketingOrderShippingInfoEntity printOrderItemShipping )
        {
            return new PrintOrderItem(printOrderItemEntity.MarketingPrintOrderItemId)
            {
                PrintOrderItemId = printOrderItemEntity.MarketingPrintOrderItemId,
                SourceCode = RemoveSourceCodeIdFromPrintOrderItemEntity(printOrderItemEntity.Sourcecode),
                Quantity = printOrderItemEntity.Quantity != null ? (long)printOrderItemEntity.Quantity : 0,
                Status = printOrderItemEntity.Status != null ? (ItemStatus)printOrderItemEntity.Status : ItemStatus.Unknown,
                Shipping = new PrintOrderItemShipping
                {
                    ShippedToAddress1 = printOrderItemShipping.Address1,
                    ShippedToAddress2 = printOrderItemShipping.Address2,
                    ShippedToCity = printOrderItemShipping.City,
                    ShippedToState = printOrderItemShipping.State,
                    ShippedToZip = printOrderItemShipping.ZipCode.ToString(),
                    ShipToAttentionOf = printOrderItemShipping.FirstName + " " + printOrderItemShipping.LastName,
                    ShippedPhoneNumber = printOrderItemShipping.PhoneNumber
                               },
                    
                TrackingInfo = printOrderItemTrackingEntity != null ? _mapper.Map(printOrderItemTrackingEntity) : null

            };

        }
        private static string RemoveSourceCodeIdFromPrintOrderItemEntity(string sourceCodeWithId)
        {
            //toDo: this will be removed once the creating of print order is moved to Domain. currently it is saving source code with Id in the dB when creating from the event wizard.
            int startIndex = sourceCodeWithId.IndexOf("[");
            return sourceCodeWithId = sourceCodeWithId.Remove(startIndex, sourceCodeWithId.Length - startIndex);
        }
    }
}
