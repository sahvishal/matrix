using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class OrderMapper : DomainEntityMapper<Order, OrderEntity>
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public OrderMapper(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        protected override void MapDomainFields(OrderEntity entity, Order domainObjectToMapTo)
        {
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(entity.OrganizationRoleUserCreatorId,
                entity.DateCreated);

            domainObjectToMapTo.Id = entity.OrderId;
            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
            domainObjectToMapTo.OrderType = (OrderType)entity.Type;
        }

        protected override void MapEntityFields(Order domainObject, OrderEntity entityToMapTo)
        {
            NullArgumentChecker.CheckIfNull(domainObject.DataRecorderMetaData,
                "order.DataRecorderMetaData");
            NullArgumentChecker.CheckIfNull(domainObject.DataRecorderMetaData.DataRecorderCreator,
                "order.DataRecorderMetaData.DataRecorderCreator");

            entityToMapTo.OrderId = domainObject.Id;
            entityToMapTo.Type = (byte)domainObject.OrderType;
            entityToMapTo.OrganizationRoleUserCreatorId = domainObject.DataRecorderMetaData.
                DataRecorderCreator.Id;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.IsNew = domainObject.Id == 0;
        }
    }
}