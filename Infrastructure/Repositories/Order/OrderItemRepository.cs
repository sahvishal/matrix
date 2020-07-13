using System;
using System.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Factories.Order;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.ORMSupportClasses;
using IsolationLevel = System.Data.IsolationLevel;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    public class OrderItemRepository : PersistenceRepository, IOrderItemRepository
    {
        private readonly IOrderItemTraitsFactory _orderItemTraitsFactory;

        public OrderItemRepository()
            : this(new SqlPersistenceLayer(), new OrderItemTraitsFactory())
        { }

        public OrderItemRepository(IPersistenceLayer persistenceLayer, IOrderItemTraitsFactory orderItemTraitsFactory)
            : base(persistenceLayer)
        {
            _orderItemTraitsFactory = orderItemTraitsFactory;
        }

        public OrderItem GetOrderItem(long orderItemId)
        {
            IOrderItemTraits orderItemTraits;
            long itemId;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var orderItemType = (OrderItemType)linqMetaData.OrderItem.Single(oi => oi.OrderItemId == orderItemId).Type;
                orderItemTraits = _orderItemTraitsFactory.CreateTraits(orderItemType);

                if (orderItemType == OrderItemType.CancellationFee)
                   return orderItemTraits.CreateOrderItem(orderItemId, orderItemId);

                IPredicate orderItemPredicate = orderItemTraits.OrderItemIdPredicate(orderItemId);
                IEntityCollection2 itemEntities = orderItemTraits.CreateItemEntityCollection();
                myAdapter.FetchEntityCollection(itemEntities, new RelationPredicateBucket(orderItemPredicate));
                if (itemEntities.HasSingleItem())
                {
                    itemId = orderItemTraits.GetItemId(itemEntities[0]);
                }
                else
                {
                    throw new DuplicateObjectException<OrderItem>();
                }
            }
            return orderItemTraits.CreateOrderItem(orderItemId, itemId);
        }

        public IEnumerable<OrderItem> GetOrderItems(long[] orderItemId)
        {
            IOrderItemTraits orderItemTraits;
            long itemId;
            var orderItems = new List<OrderItem>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var orderItemEntities = linqMetaData.OrderItem.Where(oi => orderItemId.Contains(oi.OrderItemId)).ToList();

                if (orderItemEntities.IsNullOrEmpty()) throw new ObjectNotFoundInPersistenceException<OrderItem>();

                var orderItemTypes = orderItemEntities.Select(oi => oi.Type).Distinct();

                foreach (var itemType in orderItemTypes)
                {
                    var orderItemType = (OrderItemType) itemType;
                    orderItemTraits = _orderItemTraitsFactory.CreateTraits(orderItemType);
                    orderItemEntities.Where(oi => oi.Type == itemType).ToList().
                        ForEach(oi =>
                                    {
                                        IPredicate orderItemPredicate =orderItemTraits.OrderItemIdPredicate(oi.OrderItemId);
                                        IEntityCollection2 itemEntities=orderItemTraits.CreateItemEntityCollection();
                                        myAdapter.FetchEntityCollection(itemEntities,new RelationPredicateBucket(orderItemPredicate));
                                        if (itemEntities.HasSingleItem())
                                        {
                                            itemId = orderItemTraits.GetItemId(itemEntities[0]);
                                        }
                                        else
                                        {
                                            throw new DuplicateObjectException<OrderItem>();
                                        }

                                        orderItems.Add(orderItemTraits.CreateOrderItem(oi.OrderItemId, itemId));
                                    });

                }
                return orderItems;
            }
        }

        public long SaveCancellationFeeOrderItem()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var orderItemEntity = new OrderItemEntity { Type = (short)OrderItemType.CancellationFee };
                if (!myAdapter.SaveEntity(orderItemEntity))
                {
                    throw new PersistenceFailureException();
                }
                return orderItemEntity.OrderItemId;
            }
        }

        public OrderItem SaveOrderItem(long itemId, OrderItemType orderItemType)
        {
            long orderItemId;

            IOrderItemTraits orderItemTraits = _orderItemTraitsFactory.CreateTraits(orderItemType);
            IPredicate itemIdPredicate = orderItemTraits.ItemIdPredicate(itemId);
            IEntityCollection2 itemEntityCollection = orderItemTraits.CreateItemEntityCollection();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // Check to make sure that this item isn't already mapped to another OrderItem.
                myAdapter.FetchEntityCollection(itemEntityCollection, new RelationPredicateBucket(itemIdPredicate));
                if (itemEntityCollection.Count > 0)
                {
                    IEntity2 entity = itemEntityCollection[0];
                    // Get order item ID based off of item ID.
                    return orderItemTraits.CreateOrderItem(orderItemTraits.GetOrderItemId(entity), itemId);
                }

                myAdapter.StartTransaction(IsolationLevel.ReadCommitted, "SaveNewOrderItemTransaction");
                try
                {
                    // Insert a new entry into the OrderItem table.
                    var orderItemEntity = new OrderItemEntity { Type = (short)orderItemType };
                    if (!myAdapter.SaveEntity(orderItemEntity))
                    {
                        throw new PersistenceFailureException();
                    }
                    // Insert a new entry into the corresponding mapping Item table.
                    orderItemId = orderItemEntity.OrderItemId;
                    IEntity2 itemEntityToSave = orderItemTraits.CreateItemEntity(orderItemId, itemId);
                    if (!myAdapter.SaveEntity(itemEntityToSave))
                    {
                        throw new PersistenceFailureException();
                    }
                    myAdapter.Commit();
                }
                catch (Exception)
                {
                    myAdapter.Rollback();
                    throw;
                }
            }
            return orderItemTraits.CreateOrderItem(orderItemId, itemId);
        }
    }
}