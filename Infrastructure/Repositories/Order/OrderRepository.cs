using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Application.Attributes;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    [DefaultImplementation]
    public class OrderRepository : PersistenceRepository, IOrderRepository
    {
        private readonly IMapper<Core.Finance.Domain.Order, OrderEntity> _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICombinedPaymentInstrumentRepository _paymentInstrumentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository = new OrganizationRoleUserRepository();
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        public OrderRepository()
        {
            _orderDetailRepository = new OrderDetailRepository();
            _paymentInstrumentRepository = new Payment.CombinedPaymentInstrumentRepository();
            _mapper = new OrderMapper(new DataRecorderMetaDataFactory());
            _paymentRepository = new PaymentRepository();
        }

        public OrderRepository(IPersistenceLayer persistenceLayer, IOrderDetailRepository
            orderDetailRepository, ICombinedPaymentInstrumentRepository paymentInstrumentRepository,
            IMapper<Core.Finance.Domain.Order, OrderEntity> mapper, IPaymentRepository paymentRepository)
            : base(persistenceLayer)
        {
            _orderDetailRepository = orderDetailRepository;
            _paymentInstrumentRepository = paymentInstrumentRepository;
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }
        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }
        public IEnumerable<Core.Finance.Domain.Order> GetAllOrders(int pageNumber, int pageSize)
        {
            IEnumerable<OrderEntity> orderEntities;
            var orders = new List<Core.Finance.Domain.Order>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                orderEntities = linqMetaData.Order.Skip((pageNumber - 1) * pageSize).
                    Take(pageSize).ToList();
            }
            foreach (var orderEntity in orderEntities)
            {
                orders.Add(GetOrder(orderEntity.OrderId));
            }
            return orders;
        }

        public int CountAllOrders()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return adapter.GetDbCount(new EntityCollection<OrderEntity>(), null);
            }
        }

        public IEnumerable<Core.Finance.Domain.Order> GetAllOrdersForEvent(long eventId)
        {
            var orders = new List<Core.Finance.Domain.Order>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var ecustomerOrders = (from ec in linqMetaData.EventCustomers
                                       join ecod in linqMetaData.EventCustomerOrderDetail
                                           on ec.EventCustomerId equals ecod.EventCustomerId
                                       join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                       where ec.EventId == eventId
                                       select new { ec.EventId, ec.CustomerId, od.OrderId });

                var ecustomerOrdersArray = ecustomerOrders.Distinct().ToArray();

                var orderIds =
                    linqMetaData.EventCustomers.Join(
                        linqMetaData.EventCustomerOrderDetail, @t => @t.EventCustomerId, ecod => ecod.EventCustomerId,
                        (@t, ecod) => new { @t, ecod.OrderDetailId }).Join(linqMetaData.OrderDetail,
                                                                         @t => @t.OrderDetailId, od => od.OrderDetailId,
                                                                         (@t, od) => new { @t, od.OrderId }).Where(
                        @t => @t.t.t.EventId == eventId).Select(@t => @t.OrderId).Distinct();

                foreach (var orderId in orderIds)
                {
                    var order = GetOrder(orderId);

                    if (order == null || order.OrderDetails == null || order.OrderDetails.Count < 1) continue;
                    var eCustomerOrder = ecustomerOrdersArray.Where(o => o.OrderId == orderId).FirstOrDefault();
                    if (eCustomerOrder != null)
                    {
                        order.EventId = eCustomerOrder.EventId;
                        order.CustomerId = eCustomerOrder.CustomerId;
                    }
                    else
                    {
                        order.CustomerId = order.OrderDetails.First().ForOrganizationRoleUserId;
                    }
                    orders.Add(order);
                }

                return orders;
            }
        }

        public IEnumerable<Core.Finance.Domain.Order> GetAllOrdersForCustomer(long customerId)
        {
            var orders = new List<Core.Finance.Domain.Order>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orderIds =
                    linqMetaData.CustomerProfile.Join(linqMetaData.EventCustomers, c => c.CustomerId, ec => ec.CustomerId,
                                                (c, ec) => new { c.CustomerId, ec }).Join(
                        linqMetaData.EventCustomerOrderDetail, @t => @t.ec.EventCustomerId, ecod => ecod.EventCustomerId,
                        (@t, ecod) => new { @t, ecod.OrderDetailId }).Join(linqMetaData.OrderDetail,
                                                                         @t => @t.OrderDetailId, od => od.OrderDetailId,
                                                                         (@t, od) => new { @t, od.OrderId }).Where(
                        @t => @t.t.t.CustomerId == customerId).Select(@t => @t.OrderId).Distinct();

                foreach (var orderId in orderIds)
                {
                    orders.Add(GetOrder(orderId));
                }

                return orders;
            }
        }

        public List<Core.Finance.Domain.Order> GetAllActiveOrdersCreatedByCallCenterRep(long callCenterCallCenterUserId,
            DateTime startDate, DateTime endDate)
        {
            var orders = new List<Core.Finance.Domain.Order>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                // TODO: SRE
                // TODO: Need organization role user id of the callcenterrep
                var orderIds = from o in linqMetaData.Order
                               join od in linqMetaData.OrderDetail on o.OrderId equals
                                   od.OrderId
                               join ecod in linqMetaData.EventCustomerOrderDetail on
                                   od.OrderDetailId equals ecod.OrderDetailId
                               join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals
                                   ec.EventCustomerId
                               join oru in linqMetaData.OrganizationRoleUser on o.OrganizationRoleUserCreatorId
                                   equals oru.OrganizationRoleUserId
                               join org in linqMetaData.Organization on oru.OrganizationId
                                     equals org.OrganizationId
                               where
                                   ecod.IsActive && !ec.NoShow && ec.AppointmentId.HasValue &&
                                   o.DateCreated >= startDate && o.DateCreated <= endDate &&
                                   ec.DateCreated >= startDate && ec.DateCreated <= endDate &&
                                   oru.RoleId == (long)Roles.CallCenterRep &&
                                   ecod.IsActive && org.OrganizationTypeId == (long)OrganizationType.CallCenter
                               //&& ccccu.CallCenterCallCenterUserId == callCenterCallCenterUserId
                               select o.OrderId;

                foreach (var orderId in orderIds.Distinct().ToList())
                {
                    orders.Add(GetOrder(orderId));
                }

                return orders;
            }
        }

        //TODO: SRE
        //TODO: Not to use callCenterCallCenterRepId
        public List<Core.Finance.Domain.Order> GetAllOrdersCreatedByCallCenterRep(long callCenterRepId, DateTime startDate, DateTime endDate)
        {
            var callCenterRepOrganizationRoleUser =
               _organizationRoleUserRepository.GetOrganizationRoleUser(callCenterRepId);

            var orders = new List<Core.Finance.Domain.Order>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orderIds = linqMetaData.EventCustomers.Join(linqMetaData.EventCustomerOrderDetail,
                                                                ec => ec.EventCustomerId,
                                                                ecod => ecod.EventCustomerId,
                                                                (ec, ecod) =>
                                                                new { ec, ecod.OrderDetailId, ecod.IsActive }).Join(
                    linqMetaData.OrderDetail, @t => @t.OrderDetailId, od => od.OrderDetailId,
                    (@t, od) => new { @t, od.OrderId }).Join(linqMetaData.Order, @t => @t.OrderId, o => o.OrderId,
                                                           (@t, o) => new { @t, o }).Where(
                    @t => @t.t.t.ec.CreatedByOrgRoleUserId == callCenterRepOrganizationRoleUser.Id &&
                          @t.t.t.ec.DateCreated >= startDate &&
                          @t.t.t.ec.DateCreated <= endDate &&
                          @t.o.OrganizationRoleUserCreatorId == callCenterRepOrganizationRoleUser.Id &&
                          @t.o.DateCreated >= startDate && @t.o.DateCreated <= endDate).Select(@t => @t.o.OrderId).
                    Distinct();


                foreach (var orderId in orderIds)
                {
                    var order = GetOrder(orderId);
                    orders.Add(order);
                }

                return orders;
            }
        }

        public Core.Finance.Domain.Order GetOrderByEventCustomerId(long eventCustomerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orderId =
                    linqMetaData.EventCustomerOrderDetail.Join(linqMetaData.OrderDetail, ecod => ecod.OrderDetailId,
                                                               od => od.OrderDetailId,
                                                               (ecod, od) =>
                                                               new { ecod.EventCustomerId, od.OrderId, ecod.IsActive }).
                        Single(@t => eventCustomerId == @t.EventCustomerId && @t.IsActive).OrderId;

                return GetOrder(orderId);
            }
        }

        public List<Core.Finance.Domain.Order> GetAllOrdersByEventCustomerIds(IEnumerable<long> eventCustomerIds, bool considerCancelled = false)
        {
            var orders = new List<Core.Finance.Domain.Order>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var ecustomerOrders = (from ec in linqMetaData.EventCustomers
                                       join ecod in linqMetaData.EventCustomerOrderDetail
                                           on ec.EventCustomerId equals ecod.EventCustomerId
                                       join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                       where ecod.IsActive && eventCustomerIds.Contains(ecod.EventCustomerId)
                                       select new { ec.EventId, ec.CustomerId, od.OrderId });
                if (considerCancelled)
                {
                    ecustomerOrders = (from ec in linqMetaData.EventCustomers
                                       join ecod in linqMetaData.EventCustomerOrderDetail
                                           on ec.EventCustomerId equals ecod.EventCustomerId
                                       join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                       where eventCustomerIds.Contains(ecod.EventCustomerId)
                                       select new { ec.EventId, ec.CustomerId, od.OrderId });
                }

                var ecustomerOrdersArray = ecustomerOrders.Distinct().ToArray();

                //Might need to review Domain Object for Order
                foreach (var ecustomerOrder in ecustomerOrdersArray)
                {
                    var order = GetOrder(ecustomerOrder.OrderId);
                    order.EventId = ecustomerOrder.EventId;
                    order.CustomerId = ecustomerOrder.CustomerId;
                    orders.Add(order);
                }

                return orders;
            }
        }

        public List<Core.Finance.Domain.Order> GetByIds(IEnumerable<long> orderIds)
        {
            var orders = new List<Core.Finance.Domain.Order>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var ecustomerOrders = (from ec in linqMetaData.EventCustomers
                                       join ecod in linqMetaData.EventCustomerOrderDetail
                                           on ec.EventCustomerId equals ecod.EventCustomerId
                                       join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                       where orderIds.Contains(od.OrderId)
                                       select new { ec.EventId, ec.CustomerId, od.OrderId });

                var ecustomerOrdersArray = ecustomerOrders.Distinct().ToArray();

                //Might need to review Domain Object for Order
                foreach (var orderId in orderIds.Distinct())
                {
                    var order = GetOrder(orderId);

                    if (order == null || order.OrderDetails == null || order.OrderDetails.Count < 1) continue;
                    var eCustomerOrder = ecustomerOrdersArray.Where(o => o.OrderId == orderId).FirstOrDefault();
                    if (eCustomerOrder != null)
                    {
                        order.EventId = eCustomerOrder.EventId;
                        order.CustomerId = eCustomerOrder.CustomerId;
                    }
                    else
                    {
                        order.CustomerId = order.OrderDetails.First().ForOrganizationRoleUserId;
                    }
                    orders.Add(order);
                }

                return orders;
            }
        }
        
        public List<OrderedPair<long, List<Core.Finance.Domain.Order>>> GetCallCenterRepActiveOrderPairs(DateTime startDate, DateTime endDate)
        {
            var callCenterRepOrderPairs = new List<OrderedPair<long, List<Core.Finance.Domain.Order>>>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventCustomers = linqMetaData.EventCustomers.Join(linqMetaData.OrganizationRoleUser.Where(o => GetParentRoleIdByRoleId(o.RoleId) == (long)Roles.CallCenterRep),
                                            ec => ec.CreatedByOrgRoleUserId, oru => oru.OrganizationRoleUserId, (ec, oru) => ec).Where(ec => ec.DateCreated >= startDate &&
                                            ec.DateCreated <= endDate && !ec.NoShow && ec.AppointmentId.HasValue).ToList();

                
                var filteredOrderIds = eventCustomers.Join(linqMetaData.EventCustomerOrderDetail,
                                                           ec => ec.EventCustomerId,
                                                           ecod => ecod.EventCustomerId,
                                                           (ec, ecod) =>
                                                           new { ecod.OrderDetailId, ecod.IsActive }).Join(
                    linqMetaData.OrderDetail, @t => @t.OrderDetailId, od => od.OrderDetailId,
                    (@t, od) => new { @t.IsActive, od.OrderId }).Where(@t => @t.IsActive).Select(@t => new { @t.OrderId });

                var callCenterRepOrderGroups =
                    filteredOrderIds.Join(linqMetaData.Order, @t => @t.OrderId, o => o.OrderId, (@t, o) => o).Where(
                        o => o.DateCreated >= startDate && o.DateCreated <= endDate).GroupBy(
                        o => o.OrganizationRoleUserCreatorId);


                foreach (var callCenterRepOrderGroup in callCenterRepOrderGroups)
                {
                    if (callCenterRepOrderGroup != null && !callCenterRepOrderGroup.IsEmpty())
                    {
                        var groupOrderIds = callCenterRepOrderGroup.Select(group => group.OrderId).Distinct();
                        var orders = new List<Core.Finance.Domain.Order>();
                        foreach (var orderId in groupOrderIds)
                        {
                            orders.Add(GetOrder(orderId));
                        }
                        callCenterRepOrderPairs.Add(
                            new OrderedPair<long, List<Core.Finance.Domain.Order>>(
                                    callCenterRepOrderGroup.Key, orders));
                    }
                }

                return callCenterRepOrderPairs;
            }
        }

        public Core.Finance.Domain.Order GetOrder(long customerId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orderId =
                    linqMetaData.CustomerProfile.Join(linqMetaData.EventCustomers, c => c.CustomerId, ec => ec.CustomerId,
                                                (c, ec) => new { c.CustomerId, ec }).Join(
                        linqMetaData.EventCustomerOrderDetail, @t => @t.ec.EventCustomerId, ecod => ecod.EventCustomerId,
                        (@t, ecod) => new { @t, ecod.OrderDetailId, ecod.IsActive }).Join(linqMetaData.OrderDetail,
                                                                                        @t => @t.OrderDetailId,
                                                                                        od => od.OrderDetailId,
                                                                                        (@t, od) => new { @t, od.OrderId })
                        .
                        Where(
                        @t => @t.t.t.CustomerId == customerId && @t.t.t.ec.EventId == eventId).//&& @t.t.IsActive
                        Select(@t => @t.OrderId).SingleOrDefault();

                if (orderId == 0)
                {
                    return null;
                }
                var order = GetOrder(orderId);
                order.EventId = eventId;
                order.CustomerId = customerId;
                return order;
            }
        }

        public Core.Finance.Domain.Order GetOrder(long orderId)
        {
            OrderEntity orderEntity;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {
                    orderEntity = linqMetaData.Order.Single(o => o.OrderId == orderId);
                }
                catch (NotSupportedException)
                {
                    throw new ObjectNotFoundInPersistenceException<Core.Finance.Domain.Order>(orderId);
                }
            }
            List<OrderDetail> orderDetails = _orderDetailRepository.GetOrderDetailsForOrder(orderId);
            IEnumerable<PaymentInstrument> paymentsApplied = _paymentInstrumentRepository.GetByOrderId
                (orderId);
            Core.Finance.Domain.Order order = _mapper.Map(orderEntity);
            order.OrderDetails = orderDetails;
            order.PaymentsApplied = paymentsApplied.ToList();

            // TODO: This has to be moved to each payment instrument repository.
            // HACK: This is done to fetch datarecorder metadata for the payments made for this order.
            var payments = _paymentRepository.GetByOrderId(order.Id);
            order.PaymentsApplied.ForEach(
                pa => pa.DataRecorderMetaData = payments.Single(p => p.Id == pa.PaymentId).DataRecorderMetaData);

            return order;
        }

        public Core.Finance.Domain.Order GetInactiveOrder(long customerId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orderId =
                    linqMetaData.CustomerProfile.Join(linqMetaData.EventCustomers, c => c.CustomerId, ec => ec.CustomerId,
                                                (c, ec) => new { c.CustomerId, ec }).Join(
                        linqMetaData.EventCustomerOrderDetail, @t => @t.ec.EventCustomerId, ecod => ecod.EventCustomerId,
                        (@t, ecod) => new { @t, ecod.OrderDetailId, ecod.IsActive }).Join(linqMetaData.OrderDetail,
                                                                                        @t => @t.OrderDetailId,
                                                                                        od => od.OrderDetailId,
                                                                                        (@t, od) => new { @t, od.OrderId })
                        .
                        Where(
                        @t => @t.t.t.CustomerId == customerId && @t.t.t.ec.EventId == eventId && !@t.t.IsActive).
                        Select(@t => @t.OrderId).SingleOrDefault();

                return GetOrder(orderId);
            }
        }

        public Core.Finance.Domain.Order SaveOrder(Core.Finance.Domain.Order orderToSave)
        {
            OrderEntity orderEntity = _mapper.Map(orderToSave);

            // TODO: Better method of saving Order + Details?
            using (var transactionScope = new TransactionScope())
            {
                using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    if (!myAdapter.SaveEntity(orderEntity, true))
                    {
                        throw new PersistenceFailureException();
                    }
                }
                orderToSave.OrderDetails.ForEach(orderDetail => orderDetail.OrderId = orderEntity.OrderId);
                orderToSave.OrderDetails = _orderDetailRepository.SaveOrderDetails
                    (orderToSave.OrderDetails);
                transactionScope.Complete();
            }
            Core.Finance.Domain.Order order = _mapper.Map(orderEntity);
            order.OrderDetails = orderToSave.OrderDetails;
            return order;
        }

        public void ApplyPaymentToOrder(long orderId, long paymentId)
        {
            var paymentOrderEntity = new PaymentOrderEntity
            {
                OrderId = orderId,
                PaymentId = paymentId
            };

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(paymentOrderEntity))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<Core.Finance.Domain.Order> GetAllUpgradedDowngradedOrders(int pageNumber, int pageSize, CustomerUpsellListModelFilter filter, out int totalRecords)
        {
            var orders = new List<Core.Finance.Domain.Order>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                //var ordersWithCancelStatusItem = from o in linqMetaData.OrderDetail
                //                                 join oi in linqMetaData.OrderItem on o.OrderItemId equals oi.OrderItemId
                //                                 where o.Status == (short)EventPackageItemStatus.Cancelled.StatusCode
                //                                 select o.OrderId;

                var ordersWithCancelStatusItem = (from o in linqMetaData.Order
                                                  join od in linqMetaData.OrderDetail on o.OrderId equals od.OrderId
                                                  where od.DateCreated > o.DateCreated.AddMinutes(5)
                                                  select o.OrderId);

                var orderDetailMaxDateGrouping = (from od in linqMetaData.OrderDetail
                                                  where ordersWithCancelStatusItem.Contains(od.OrderId)
                                                  group od by od.OrderId).Select(od => new { OrderId = od.Key, MaxDate = od.Max(o => o.DateCreated) });

                if (filter == null)
                {
                    var query = (from o in linqMetaData.OrderDetail
                                 join ecod in linqMetaData.EventCustomerOrderDetail on o.OrderDetailId equals ecod.OrderDetailId
                                 join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals ec.EventCustomerId
                                 join od in orderDetailMaxDateGrouping on o.OrderId equals od.OrderId
                                 where ecod.IsActive
                                    && o.Status == (short)EventPackageItemStatus.Availed.StatusCode
                                    && ordersWithCancelStatusItem.Contains(o.OrderId) && ec.AppointmentId.HasValue
                                 orderby od.MaxDate descending
                                 select new { ec.EventId, ec.CustomerId, o.OrderId });

                    totalRecords = query.Count();
                    var ordersAvailedwithUpDownSell = query.TakePage(pageNumber, pageSize);

                    foreach (var ecustomerOrder in ordersAvailedwithUpDownSell)
                    {
                        var order = GetOrder(ecustomerOrder.OrderId);
                        order.EventId = ecustomerOrder.EventId;
                        order.CustomerId = ecustomerOrder.CustomerId;
                        orders.Add(order);
                    }
                    return orders;
                }
                else
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;
                    string zip = string.IsNullOrEmpty(filter.ZipCode) ? "" : filter.ZipCode;
                    string vehicle = string.IsNullOrEmpty(filter.Vehicle) ? "" : filter.Vehicle;
                    long upselledRole = filter.UpSellRole == 0 ? 0 : filter.UpSellRole;
                    long corporateAccountId = filter.CorporateAccountId <= 0 ? 0 : filter.CorporateAccountId;

                    var eventFilterQuery = (from e in linqMetaData.Events
                                            join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                                            join prospect in linqMetaData.Prospects on eh.HostId equals prospect.ProspectId
                                            join a in linqMetaData.Address on prospect.AddressId equals a.AddressId
                                            join z in linqMetaData.Zip on a.ZipId equals z.ZipId
                                            join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                            join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                            where (filter.FromDate != null ? fromDate <= e.EventDate : true) &&
                                                  (filter.ToDate != null ? toDate >= e.EventDate : true) && ep.IsActive &&
                                                  (z.ZipCode.Contains(zip)) && (p.Name.Contains(vehicle))
                                            select new { e, z });

                    if (!string.IsNullOrEmpty(filter.Territory))
                        eventFilterQuery = (from ez in eventFilterQuery
                                            join tz in linqMetaData.TerritoryZip on ez.z.ZipId equals tz.ZipId
                                            join t in linqMetaData.Territory on tz.TerritoryId equals t.TerritoryId
                                            where (t.Name.Contains(filter.Territory))
                                            select ez);

                    var corporateEventIds = from ea in linqMetaData.EventAccount select ea.EventId;
                    if (corporateAccountId > 0)
                    {
                        //eventFilterQuery = from ea in linqMetaData.EventAccount
                        //                   join efq in eventFilterQuery on ea.EventId equals efq.e.EventId
                        //                   where ea.AccountId == filter.CorporateAccountId
                        //                   select efq;

                        corporateEventIds = (from ea in linqMetaData.EventAccount
                                             where ea.AccountId == filter.CorporateAccountId
                                             select ea.EventId);

                        //eventFilterQuery = (from efq in eventFilterQuery where corporateEventIds.Contains(efq.e.EventId) select efq);
                    }

                    var eventIds = eventFilterQuery.Select(ez => ez.e.EventId);

                    var b = from od in linqMetaData.OrderDetail
                            where ordersWithCancelStatusItem.Contains(od.OrderId)
                            group od by od.OrderId
                                into a
                                select a.Max(od => od.OrderDetailId);

                    var queryOrderIdsforUpsellRoleFilter = (from od in linqMetaData.OrderDetail
                                                            join oru in linqMetaData.OrganizationRoleUser on od.OrganizationRoleUserCreatorId equals oru.OrganizationRoleUserId
                                                            where b.Contains(od.OrderDetailId)
                                                                //&& ordersWithCancelStatusItem.Contains(od.OrderId)
                                                            && oru.RoleId == (upselledRole > 0 ? upselledRole : oru.RoleId)
                                                            select od.OrderId);

                    var query = (from o in linqMetaData.OrderDetail
                                 join ecod in linqMetaData.EventCustomerOrderDetail on o.OrderDetailId equals ecod.OrderDetailId
                                 join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals ec.EventCustomerId
                                 where ecod.IsActive
                                 && o.Status == (short)EventPackageItemStatus.Availed.StatusCode
                                 && ec.AppointmentId.HasValue
                                 && queryOrderIdsforUpsellRoleFilter.Contains(o.OrderId)
                                 && eventIds.Contains(ec.EventId)
                                 && (corporateAccountId <= 0 || corporateEventIds.Contains(ec.EventId))
                                 orderby o.DateCreated descending
                                 select new { ec.EventId, ec.CustomerId, o.OrderId });

                    totalRecords = query.Count();
                    var ordersAvailedwithUpDownSell = query.TakePage(pageNumber, pageSize).ToArray();

                    foreach (var ecustomerOrder in ordersAvailedwithUpDownSell)
                    {
                        var order = GetOrder(ecustomerOrder.OrderId);
                        order.EventId = ecustomerOrder.EventId;
                        order.CustomerId = ecustomerOrder.CustomerId;
                        orders.Add(order);
                    }

                    return orders;
                }
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetOrderSumforEventIds(long[] eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventOrderQuery = from ec in linqMetaData.EventCustomers
                                      join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                          ecod.EventCustomerId
                                      join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals
                                          od.OrderDetailId
                                      where ecod.IsActive && ec.AppointmentId.HasValue
                                      select new { ec.EventId, od.OrderId, ec.NoShow };


                var orderedPair = new List<OrderedPair<long, decimal>>();

                foreach (var eventId in eventIds)
                {
                    var orderIds = eventOrderQuery.Where(eo => eo.EventId == eventId && !eo.NoShow).Select(eo => eo.OrderId);
                    if (!orderIds.Any())
                    {
                        orderedPair.Add(new OrderedPair<long, decimal>(eventId, 0));
                        continue;
                    }

                    var totalPrice = linqMetaData.OrderDetail.Where(od => orderIds.Contains(od.OrderId) && od.Status == (int)OrderStatusState.FinalSuccess).Sum(od => od.Price);

                    var orderDetailIds = linqMetaData.OrderDetail.Where(od => orderIds.Contains(od.OrderId) && od.Status == (int)OrderStatusState.FinalSuccess)
                                            .Select(eod => eod.OrderDetailId).ToArray();

                    var discountedPrice = (from scod in linqMetaData.SourceCodeOrderDetail
                                           where scod.IsActive && orderDetailIds.Contains(scod.OrderDetailId)
                                           select scod.Amount).Sum();

                    var shippingCharges = (from sdod in linqMetaData.ShippingDetailOrderDetail
                                           join sd in linqMetaData.ShippingDetail
                                               on sdod.ShippingDetailId equals sd.ShippingDetailId
                                           where sdod.IsActive && orderDetailIds.Contains(sdod.OrderDetailId)
                                           select sd.ActualPrice).Sum();

                    //var noShowOrderIds = eventOrderQuery.Where(eo => eo.EventId == eventId && eo.NoShow).Select(eo => eo.OrderId);
                    //var noShowPayments = 0.00m;
                    //if (noShowOrderIds.Any())
                    //{
                    //    foreach (var noShowOrderId in noShowOrderIds)
                    //    {
                    //        var payments = _paymentInstrumentRepository.GetByOrderId(noShowOrderId);
                    //        if (payments != null && payments.Any())
                    //            noShowPayments += payments.Sum(p => p.Amount);
                    //    }
                    //}
                    orderedPair.Add(new OrderedPair<long, decimal>(eventId, totalPrice - discountedPrice + shippingCharges));//+ noShowPayments
                }

                return orderedPair;
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetOrderEventCustomeridPairforOrderIds(IEnumerable<long> orderIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pair in
                            (from od in linqMetaData.OrderDetail
                             join ecod in linqMetaData.EventCustomerOrderDetail on od.OrderDetailId equals
                                 ecod.OrderDetailId
                             where orderIds.Contains(od.OrderId)
                             select new { od.OrderId, ecod.EventCustomerId })
                        group pair by pair.OrderId
                            into grp
                            select new OrderedPair<long, long>(grp.Key, grp.Max(p => p.EventCustomerId))).ToArray();

            }
        }

        public IEnumerable<OrderedPair<long, long>> GetOrderEventCustomerIdPairforEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pair in
                            (from od in linqMetaData.OrderDetail
                             join ecod in linqMetaData.EventCustomerOrderDetail on od.OrderDetailId equals
                                 ecod.OrderDetailId
                             where eventCustomerIds.Contains(ecod.EventCustomerId)
                             select new { od.OrderId, ecod.EventCustomerId })
                        group pair by pair.OrderId
                            into grp
                            select new OrderedPair<long, long>(grp.Key, grp.Max(p => p.EventCustomerId))).ToArray();

            }
        }

        public long GetOrderIdByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecod in linqMetaData.EventCustomerOrderDetail
                        join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                        where ecod.EventCustomerId == eventCustomerId
                        select od.OrderId).Distinct().Single();
            }
        }


        public long GetOrderIdByEventIdCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                        join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                        where ec.EventId == eventId && ec.CustomerId == customerId
                        select od.OrderId).Distinct().SingleOrDefault();
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetOpenOrderTotalForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pair in
                            (from ec in linqMetaData.EventCustomers
                             join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals
                                 ecp.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                 into ecea
                             from ee in ecea.DefaultIfEmpty()
                             where eventIds.Contains(ec.EventId)
                                   && (ec.AppointmentId.HasValue
                                           ? ((!ee.CheckinTime.HasValue && !ee.CheckoutTime.HasValue && !ec.NoShow) || (ec.NoShow && ecp.NetPayment > 0))
                                           : true)
                                   && ecp.OrderTotal > 0
                             select new { ec.EventId, ec.EventCustomerId, ecp.OrderTotal })
                        group pair by pair.EventId
                            into grp
                            select new OrderedPair<long, decimal>(grp.Key, grp.Sum(p => p.OrderTotal))).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetOutstandingRevenueForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pair in
                            (from ec in linqMetaData.EventCustomers
                             join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals
                                 ecp.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                 into ecea
                             from ee in ecea.DefaultIfEmpty()
                             where eventIds.Contains(ec.EventId)
                                   && (ec.AppointmentId.HasValue
                                           ? ((!ee.CheckinTime.HasValue && !ee.CheckoutTime.HasValue && !ec.NoShow) || (ec.NoShow && ecp.NetPayment > 0))
                                           : true)
                                   && ecp.NetPayment > 0
                             select new { ec.EventId, ec.EventCustomerId, ecp.NetPayment })
                        group pair by pair.EventId
                            into grp
                            select new OrderedPair<long, decimal>(grp.Key, grp.Sum(p => p.NetPayment))).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetNoshowOutstandingRevenueForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pair in
                            (from ec in linqMetaData.EventCustomers
                             join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals
                                 ecp.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where eventIds.Contains(ec.EventId)
                                   && ec.NoShow
                                   && ecp.NetPayment > 0
                             select new { ec.EventId, ec.EventCustomerId, ecp.NetPayment })
                        group pair by pair.EventId
                            into grp
                            select new OrderedPair<long, decimal>(grp.Key, grp.Sum(p => p.NetPayment))).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetCancelledOutstandingRevenueForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pair in
                            (from ec in linqMetaData.EventCustomers
                             join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals ecp.EventCustomerId
                             where eventIds.Contains(ec.EventId)
                                   && !ec.AppointmentId.HasValue
                                   && ecp.NetPayment > 0
                             select new { ec.EventId, ec.EventCustomerId, ecp.NetPayment })
                        group pair by pair.EventId
                            into grp
                            select new OrderedPair<long, decimal>(grp.Key, grp.Sum(p => p.NetPayment))).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetOpenOrderTotalForEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals
                            ecp.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                            into ecea
                        from ee in ecea.DefaultIfEmpty()
                        where eventCustomerIds.Contains(ec.EventCustomerId)
                              && (ec.AppointmentId.HasValue
                                      ? ((!ee.CheckinTime.HasValue && !ee.CheckoutTime.HasValue && !ec.NoShow) ||
                                         (ec.NoShow && ecp.NetPayment > 0))
                                      : true)
                              && ecp.OrderTotal > 0
                        select new OrderedPair<long, decimal>(ec.EventCustomerId, ecp.OrderTotal)).ToArray();

            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetOutstandingRevenueForEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals
                            ecp.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                            into ecea
                        from ee in ecea.DefaultIfEmpty()
                        where eventCustomerIds.Contains(ec.EventCustomerId)
                              && (ec.AppointmentId.HasValue
                                      ? ((!ee.CheckinTime.HasValue && !ee.CheckoutTime.HasValue && !ec.NoShow) ||
                                         (ec.NoShow && ecp.NetPayment > 0))
                                      : true)
                              && ecp.NetPayment > 0
                        select new OrderedPair<long, decimal>(ec.EventCustomerId, ecp.NetPayment)).ToArray();

            }
        }

        public IEnumerable<Core.Finance.Domain.Order> GetOrderByOrderIds(IEnumerable<long> orderIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from o in linqMetaData.Order where orderIds.Contains(o.OrderId) select o);
                return _mapper.MapMultiple(entities).ToArray();
            }
        }
    }
}