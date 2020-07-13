using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class OrderDetailMapper : DomainEntityMapper<OrderDetail, OrderDetailEntity>
    {
        private readonly IOrderItemStatusFactory _orderItemStatusFactory;
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public OrderDetailMapper(IOrderItemStatusFactory orderItemStatusFactory,
            IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _orderItemStatusFactory = orderItemStatusFactory;
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        protected override void MapDomainFields(OrderDetailEntity entity, OrderDetail domainObjectToMapTo)
        {
            NullArgumentChecker.CheckIfNull(entity.OrderItem, "entity.OrderItem", 
                "The OrderItem associated with the given OrderDetail must be provided.");

            OrderItemStatus orderItemStatus = _orderItemStatusFactory.CreateOrderItemStatus
                ((OrderItemType)entity.OrderItem.Type, entity.Status);
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(entity.OrganizationRoleUserCreatorId, entity.DateCreated);

            domainObjectToMapTo.Id = entity.OrderDetailId;
            domainObjectToMapTo.OrderId = entity.OrderId;
            domainObjectToMapTo.OrderItemId = entity.OrderItemId;
            domainObjectToMapTo.ForOrganizationRoleUserId = entity.ForOrganizationRoleUserId;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.Quantity = entity.Quantity;
            domainObjectToMapTo.Price = entity.Price;
            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
            domainObjectToMapTo.OrderItemStatus = orderItemStatus;
            domainObjectToMapTo.DetailType = (OrderItemType)entity.OrderItem.Type;
            domainObjectToMapTo.SourceId = entity.SourceId;
        }

        protected override void MapEntityFields(OrderDetail domainObject, OrderDetailEntity entityToMapTo)
        {
            NullArgumentChecker.CheckIfNull(domainObject.DataRecorderMetaData,
                "domainObject.DataRecorderMetaData", 
                "The given OrderDetail requires DataRecorderMetaData.");
            NullArgumentChecker.CheckIfNull(domainObject.DataRecorderMetaData.DataRecorderCreator,
                "domainObject.DataRecorderMetaData.DataRecorderCreator",
                "The given OrderDetail DataRecorderMetaData requires a Creator.");

            entityToMapTo.OrderDetailId = domainObject.Id;
            entityToMapTo.OrderId = domainObject.OrderId;
            entityToMapTo.OrderItemId = domainObject.OrderItemId;
            entityToMapTo.ForOrganizationRoleUserId = domainObject.ForOrganizationRoleUserId;
            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.Quantity = domainObject.Quantity;
            entityToMapTo.Price = domainObject.Price;
            entityToMapTo.Status = (short)domainObject.OrderItemStatus.StatusCode;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.OrganizationRoleUserCreatorId = domainObject.DataRecorderMetaData.
                DataRecorderCreator.Id;
            entityToMapTo.IsNew = domainObject.Id == 0;
            entityToMapTo.SourceId = domainObject.SourceId;
        }
    }
}