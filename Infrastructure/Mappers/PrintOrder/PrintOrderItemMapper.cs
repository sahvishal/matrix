using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.PrintOrder
{
    class PrintOrderItemMapper : DomainEntityMapper<PrintOrderItem, MarketingPrintOrderItemEntity>
    {

        private readonly IDataRecorderMetaDataFactory _factory;

        public PrintOrderItemMapper()
            : this(new DataRecorderMetaDataFactory())
        { }

        private PrintOrderItemMapper(IDataRecorderMetaDataFactory factory)
        {
            _factory = factory;
        }

        protected override void MapDomainFields(MarketingPrintOrderItemEntity entity, PrintOrderItem domainObjectToMapTo)
        {
            domainObjectToMapTo.Status = (ItemStatus)entity.Status;
            domainObjectToMapTo.SourceCode = entity.Sourcecode;
            domainObjectToMapTo.Quantity = entity.Quantity != null ? (long)entity.Quantity : 0;

        }

        protected override void MapEntityFields(PrintOrderItem domainObject, MarketingPrintOrderItemEntity entityToMapTo)
        {
            entityToMapTo.Sourcecode = domainObject.SourceCode;
            entityToMapTo.Quantity = (int?)domainObject.Quantity;
            entityToMapTo.Status = (int)domainObject.Status;
            entityToMapTo.IsNew = domainObject.PrintOrderItemId == 0;
        }
    }

}
