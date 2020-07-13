using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Product = Falcon.App.Core.Enum.Product;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    public class ElectronicProductRepository : UniqueItemRepository<ElectronicProduct, ProductEntity>, IElectronicProductRepository
    {
        public ElectronicProductRepository()
            : base(new ElectronicProductMapper())
        {
        }

        protected override EntityField2 EntityIdField
        {
            get { return ProductFields.ProductId; }
        }

        public List<ElectronicProduct> GetAllProducts()
        {
            var products =
                GetByPredicate(new PredicateExpression(ProductFields.IsActive == true)).ToList();
            if (products.Count == 0) return null;
            return products;
        }

        public ElectronicProduct GetElectronicProductForOrder(long eventId, long customerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orderId = (from ec in linqMetaData.EventCustomers
                               join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                   ecod.EventCustomerId
                               join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                               where
                                   !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue && ecod.IsActive && ec.EventId == eventId &&
                                   ec.CustomerId == customerId
                               select od.OrderId).FirstOrDefault();

                var electronicProductDetails = (from od in linqMetaData.OrderDetail
                                                join oi in linqMetaData.OrderItem on od.OrderItemId equals
                                                    oi.OrderItemId
                                                join poi in linqMetaData.ProductOrderItem on oi.OrderItemId equals
                                                    poi.OrderItemId
                                                join p in linqMetaData.Product on poi.ProductId equals p.ProductId
                                                where
                                                    od.Status == (short)OrderStatusState.FinalSuccess &&
                                                    oi.Type == (short)OrderItemType.ProductItem &&
                                                    od.OrderId == orderId
                                                select new { p.ProductId, od.Price }).FirstOrDefault();

                if (electronicProductDetails != null && electronicProductDetails.ProductId > 0)
                {
                    var product = GetById(electronicProductDetails.ProductId);
                    product.Price = electronicProductDetails.Price;
                    return product;
                }
                return null;
            }
        }
        
        public IEnumerable<ElectronicProduct> GetElectronicProductForOrder(long orderId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var electronicProductDetails = (from od in linqMetaData.OrderDetail
                                                join oi in linqMetaData.OrderItem on od.OrderItemId equals
                                                    oi.OrderItemId
                                                join poi in linqMetaData.ProductOrderItem on oi.OrderItemId equals
                                                    poi.OrderItemId
                                                join p in linqMetaData.Product on poi.ProductId equals p.ProductId
                                                where
                                                    od.Status == (short)OrderStatusState.FinalSuccess &&
                                                    oi.Type == (short)OrderItemType.ProductItem &&
                                                    od.OrderId == orderId
                                                select new { p.ProductId, od.Price });

                if (electronicProductDetails.Count() > 0)
                {
                    var products = new ElectronicProduct[electronicProductDetails.Count()];
                    int index = 0;

                    foreach (var electronicProductDetail in electronicProductDetails)
                    {
                        var product = GetById(electronicProductDetail.ProductId);
                        product.Price = electronicProductDetail.Price;
                        products[index++] = product;
                    }
                    return products;
                }
                return null;
            }
        }

        public string GetElectronicProductNameForOrder(long orderItemId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from oi in linqMetaData.OrderItem
                        join poi in linqMetaData.ProductOrderItem on oi.OrderItemId equals poi.OrderItemId
                        join p in linqMetaData.Product on poi.ProductId equals p.ProductId
                        where oi.OrderItemId == orderItemId
                        select p.Name).FirstOrDefault();
            }
        }

        // TODO: to be moved into product repository.
        public IEnumerable<OrderedPair<long, string>> GetProductNameForOrderItems(long[] orderItemIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from oi in linqMetaData.OrderItem
                        join poi in linqMetaData.ProductOrderItem on oi.OrderItemId equals poi.OrderItemId
                        join p in linqMetaData.Product on poi.ProductId equals p.ProductId
                        where orderItemIds.Contains(oi.OrderItemId)
                        select new OrderedPair<long, string>(oi.OrderItemId, p.Name)).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetProductIdsForOrderItems(long[] orderItemIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from oi in linqMetaData.OrderItem
                        join poi in linqMetaData.ProductOrderItem on oi.OrderItemId equals poi.OrderItemId
                        join p in linqMetaData.Product on poi.ProductId equals p.ProductId
                        where orderItemIds.Contains(oi.OrderItemId)
                        select new OrderedPair<long, long>(oi.OrderItemId, p.ProductId)).ToList();
            }
        }

        public bool IsProductPurchased(long eventId, long customerId, Product productType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var orderId = (from ec in linqMetaData.EventCustomers
                               join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                   ecod.EventCustomerId
                               join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                               where
                                   !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue && ecod.IsActive && ec.EventId == eventId &&
                                   ec.CustomerId == customerId
                               select od.OrderId).FirstOrDefault();

                return (from od in linqMetaData.OrderDetail
                        join oi in linqMetaData.OrderItem on od.OrderItemId equals
                            oi.OrderItemId
                        join poi in linqMetaData.ProductOrderItem on oi.OrderItemId equals
                            poi.OrderItemId
                        where
                            od.Status == (short)OrderStatusState.FinalSuccess &&
                            od.OrderId == orderId &&
                            oi.Type == (short)OrderItemType.ProductItem &&
                            poi.ProductId == (long)productType
                        select od.OrderDetailId
                       ).Any();
            }

        }

        public IEnumerable<long> GetExcludedProductIdsForEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ep in linqMetaData.EventProductExclusion
                        where ep.EventId == eventId
                        select ep.ProductId).ToList();
            }
        }

        public List<ElectronicProduct> GetAllProductsForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var excludedProductIds = GetExcludedProductIdsForEventId(eventId);
                var entities = (from p in linqMetaData.Product
                                where !excludedProductIds.Contains(p.ProductId)
                                      && p.IsActive
                                select p);

                return Mapper.MapMultiple(entities).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetProductNamesForOrder(IEnumerable<long> orderIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from od in linqMetaData.OrderDetail
                        join poi in linqMetaData.ProductOrderItem on od.OrderItemId equals poi.OrderItemId
                        join p in linqMetaData.Product on poi.ProductId equals p.ProductId
                        where orderIds.Contains(od.OrderId)
                              && od.Status == (int)OrderStatusState.FinalSuccess
                        select new OrderedPair<long, string>(od.OrderId, p.Name)).ToArray();
            }
        }

        public ElectronicProduct GetElectronicProductByOrderId(long orderId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var electronicProductDetails = (from od in linqMetaData.OrderDetail
                                                join oi in linqMetaData.OrderItem on od.OrderItemId equals
                                                    oi.OrderItemId
                                                join poi in linqMetaData.ProductOrderItem on oi.OrderItemId equals
                                                    poi.OrderItemId
                                                join p in linqMetaData.Product on poi.ProductId equals p.ProductId
                                                where
                                                    od.Status == (short)OrderStatusState.FinalSuccess &&
                                                    oi.Type == (short)OrderItemType.ProductItem &&
                                                    od.OrderId == orderId
                                                select new { p.ProductId, od.Price }).FirstOrDefault();

                if (electronicProductDetails != null && electronicProductDetails.ProductId > 0)
                {
                    var product = GetById(electronicProductDetails.ProductId);
                    product.Price = electronicProductDetails.Price;
                    return product;
                }
                return null;
            }
        }
        
    }


}