using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Finance.Impl
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public OrderFactory()
            : this(new DataRecorderMetaDataFactory())
        {}

        public OrderFactory(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        public Finance.Domain.Order CreateNewOrder(OrderType orderType, long dataRecorderCreatorId)
        {
            DataRecorderMetaData metaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(dataRecorderCreatorId);
            return new Finance.Domain.Order
            {
                OrderType = orderType,
                DataRecorderMetaData = metaData
            };
        }

        public Finance.Domain.Order CreateDuplicateOrder(Finance.Domain.Order order)
        {
            return new Finance.Domain.Order(order.Id)
                       {
                           OrderType = order.OrderType,
                           DataRecorderMetaData = order.DataRecorderMetaData
                       };
        }
    }
}