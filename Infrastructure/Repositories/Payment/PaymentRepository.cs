using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Payments;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    [DefaultImplementation]
    public class PaymentRepository : UniqueItemRepository<Core.Finance.Domain.Payment, PaymentEntity>, 
        IPaymentRepository
    {
        public PaymentRepository()
            : base(new PaymentMapper())
        {}

        protected override EntityField2 EntityIdField
        {
            get { return PaymentFields.PaymentId; }
        }

        public List<Core.Finance.Domain.Payment> GetByOrderId(long orderId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var paymentIds = linqMetaData.PaymentOrder.Where(paymentOrder => paymentOrder.OrderId == orderId)
                    .Select(po => po.PaymentId);
                return GetByIds(paymentIds).ToList();
            }
        }

        public List<long> GetPaymentsForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var paymentsForEvent = from ec in linqMetaData.EventCustomers
                                       join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                           ecod.EventCustomerId
                                       join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                       join p in linqMetaData.PaymentOrder on od.OrderId equals p.OrderId
                                       where
                                           ec.EventId == eventId && ecod.IsActive && !ec.NoShow &&
                                           ec.AppointmentId.HasValue
                                       select p.PaymentId;

                return paymentsForEvent.Distinct().ToList();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetOrderPaymentOrderedPairbyPaymentIds(IEnumerable<long> paymentIds)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from p in linqMetaData.PaymentOrder
                        where paymentIds.Contains(p.PaymentId)
                        select new OrderedPair<long, long>(p.OrderId, p.PaymentId)).ToArray();
            }
        }

        public IEnumerable<DeferredRevenueViewModel> GetEventWiseRevenueDetails(IEnumerable<long> eventIds)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var records = (from ec in linqMetaData.EventCustomers
                              join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                              join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals
                                  ecp.EventCustomerId
                              where eventIds.Contains(ec.EventId)
                              select new {ec.EventId, ecp.EventCustomerId, ea.CheckinTime, ea.CheckoutTime, ecp.NetPayment, ecp.OrderTotal}).ToArray().Select(ec => new { ec.EventId, 
                                  ec.NetPayment,
                                  Liability = !ec.CheckinTime.HasValue && !ec.CheckoutTime.HasValue ? ec.NetPayment : 0,
                                  ec.OrderTotal, 
                                  UnpaidAmount = (ec.OrderTotal > ec.NetPayment ? (ec.OrderTotal - ec.NetPayment) : 0) }).ToArray();

                return (from pair in records
                        group pair by pair.EventId
                        into grp
                        select new DeferredRevenueViewModel{ EventId = grp.Key,
                                                             TotalLiability = grp.Sum(p => p.Liability),
                                                             TotalRevenue = grp.Sum(p => p.OrderTotal),
                                                             TotalAmountDue = grp.Sum(p => p.UnpaidAmount)
                        }).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long,decimal>> GetEventCustomerIdOrderTotalPair(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return
                    (from ecp in linqMetaData.EventCustomerPayment
                     where eventCustomerIds.Contains(ecp.EventCustomerId)
                     select new OrderedPair<long, decimal>(ecp.EventCustomerId, ecp.OrderTotal)
                    ).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetEventCustomerIdTotalPaymentPair(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return
                    (from ecp in linqMetaData.EventCustomerPayment
                     where eventCustomerIds.Contains(ecp.EventCustomerId)
                     select new OrderedPair<long, decimal>(ecp.EventCustomerId, ecp.NetPayment)
                    ).ToArray();
            }
        }

        public bool UpdatePayment(IEnumerable<Core.Finance.Domain.Payment> payments, long orderId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new PaymentOrderEntity {OrderId = orderId};

                var bucket = new RelationPredicateBucket(PaymentOrderFields.PaymentId == payments.Select(p=>p.Id).ToArray());

                return (adapter.UpdateEntitiesDirectly(entity, bucket) > 0) ? true : false;
            }
        }

    }
}