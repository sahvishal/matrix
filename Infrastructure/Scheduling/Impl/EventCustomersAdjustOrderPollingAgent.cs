using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Finance.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    public class CustomerOrderDetail
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public IEnumerable<long> PreApprovedTestIds { get; set; }
        public long PrePackageId { get; set; }
    }

    [DefaultImplementation]
    public class EventCustomersAdjustOrderPollingAgent : IEventCustomersAdjustOrderPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IEventCustomerAdjustOrderLogRepository _eventCustomerAdjustOrderLogRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IOrderController _orderController;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;

        public EventCustomersAdjustOrderPollingAgent(ILogManager logManager, IEventCustomerAdjustOrderLogRepository eventCustomerAdjustOrderLogRepository,
            IEventCustomerRepository eventCustomerRepository, IOrderRepository orderRepository, IPreApprovedPackageRepository preApprovedPackageRepository,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IOrderController orderController, IPreApprovedTestRepository preApprovedTestRepository)
        {
            _logger = logManager.GetLogger("Adjust Order Log");

            _eventCustomerAdjustOrderLogRepository = eventCustomerAdjustOrderLogRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _orderRepository = orderRepository;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _orderController = orderController;
            _preApprovedTestRepository = preApprovedTestRepository;
        }

        public void PollForAdjustOrder()
        {
            _logger.Info("Enter in Service to adjust Order");

            var eventCustomersToAdjustOrder = _eventCustomerAdjustOrderLogRepository.GetEventCustomerToAdjustOrder();

            if (eventCustomersToAdjustOrder.IsNullOrEmpty())
            {
                _logger.Info("No Event Customer Found For Adjusting Order");
                return;
            }

            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomersToAdjustOrder.Select(x => x.EventCustomerId));

            foreach (var eventCustomer in eventCustomers)
            {
                if (eventCustomer.AppointmentId == null)
                {
                    _logger.Info("Appointment has been cancel");
                    continue;
                }

                var customrePreApprovedTest = _preApprovedTestRepository.GetByCustomerId(eventCustomer.Id);

                if (customrePreApprovedTest.IsNullOrEmpty())
                {
                    _logger.Info("Customer  has no pre approved test" + eventCustomer.CustomerId);
                }

                var preApprovedPackage = _preApprovedPackageRepository.GetByCustomerId(eventCustomer.CustomerId);

                if (customrePreApprovedTest.IsNullOrEmpty())
                {
                    _logger.Info("Customer  has no pre-approved test" + eventCustomer.CustomerId);
                }

                if (preApprovedPackage.IsNullOrEmpty())
                {
                    _logger.Info("Customer  has no pre-approved package" + eventCustomer.CustomerId);
                }

                var customerOrderDtails = new CustomerOrderDetail
                {
                    CustomerId = eventCustomer.CustomerId,
                    EventId = eventCustomer.EventId,
                    PreApprovedTestIds = customrePreApprovedTest != null ? customrePreApprovedTest.Select(x => x.TestId) : null,
                    PrePackageId = preApprovedPackage.IsNullOrEmpty() ? 0 : preApprovedPackage.First().PackageId
                };

                ChangePackage(customerOrderDtails);
            }
        }

        public void ChangePackage(CustomerOrderDetail customerOrderDetail)
        {

            using (var scope = new TransactionScope())
            {
                try
                {
                    var eventid = customerOrderDetail.EventId;
                    var customerid = customerOrderDetail.CustomerId;

                    var order = GetOrder(customerid, eventid);


                    IOrderController orderController = new OrderController();
                    var orderDetail = orderController.GetActiveOrderDetail(order);

                    if (order == null || order.OrderDetails.IsEmpty()) return;

                    var orderables = new List<IOrderable>();
                    var selectedTestIds = new List<long>();

                    if (customerOrderDetail.PreApprovedTestIds != null && customerOrderDetail.PreApprovedTestIds.Any())
                    {
                        selectedTestIds = customerOrderDetail.PreApprovedTestIds.ToList();
                    }

                    long packageId = 0;

                    if (customerOrderDetail.PrePackageId > 0)
                    {
                        var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventid, customerOrderDetail.PrePackageId);
                        if (eventPackage != null)
                        {
                            packageId = eventPackage.PackageId;
                        }
                    }

                    if (packageId == 0)
                    {
                        if (orderDetail.OrderItem.OrderItemType == OrderItemType.EventPackageItem)
                        {
                            var eventPackage = _eventPackageRepository.GetById(orderDetail.OrderItem.ItemId);
                            packageId = eventPackage.PackageId;
                        }
                    }

                    if (packageId > 0)
                    {
                        orderables.Add(_eventPackageRepository.GetByEventAndPackageIds(eventid, packageId));
                        selectedTestIds = RemoveTestsAlreadyInPackage(selectedTestIds, eventid, packageId);
                    }

                    if (!selectedTestIds.IsNullOrEmpty())
                    {
                        var eventTests = _eventTestRepository.GetByEventAndTestIds(eventid, selectedTestIds);
                        if (packageId > 0)
                        {
                            foreach (var eventTest in eventTests)
                            {
                                eventTest.Price = eventTest.WithPackagePrice;
                            }
                        }

                        orderables.AddRange(eventTests);
                    }

                    var indentedLineItemsAdded = false;

                    // TODO: applying hook to the system all the indented line items will be attached to the first order item.
                    foreach (var orderable in orderables)
                    {
                        if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                        {
                            _orderController.AddItem(orderable, 1, customerid, 1, null, null, null, OrderStatusState.FinalSuccess);
                            indentedLineItemsAdded = true;
                        }
                        else
                            _orderController.AddItem(orderable, 1, customerid, 1, OrderStatusState.FinalSuccess);
                    }

                    _orderController.PlaceOrder(order);


                    scope.Complete();
                }
                catch (Exception exception)
                {
                    _logger.Error("Some Error occured" + exception.Message);
                }
            }
        }

        private Order GetOrder(long customerId, long eventId)
        {
            return _orderRepository.GetOrder(customerId, eventId);
        }

        private List<long> RemoveTestsAlreadyInPackage(List<long> selectedTestIds, long eventId, long packageId)
        {
            if (eventId <= 0) return null;

            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);

            var package = eventPackage != null ? eventPackage.Package : null;
            if (package == null || selectedTestIds.IsNullOrEmpty()) return null;

            var packageTestIds = package.Tests.Select(t => t.Id);
            selectedTestIds.RemoveAll(packageTestIds.Contains);

            return selectedTestIds;
        }
    }
}
