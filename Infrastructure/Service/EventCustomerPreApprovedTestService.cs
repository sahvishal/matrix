using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class EventCustomerPreApprovedTestService : IEventCustomerPreApprovedTestService
    {
        private readonly IEventCustomerPreApprovedTestRepository _eventCustomerPreApprovedTestRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventCustomerPreApprovedPackageTestRepository _eventCustomerPreApprovedPackageTestRepository;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IPackageTestRepository _packageTestRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IInsurancePaymentRepository _insurancePaymentRepository;
        private readonly ICustomerOrderHistoryService _customerOrderHistoryService;
        private readonly IDisqualifiedTestRepository _disqualifiedTestRepository;
        private readonly IDependentDisqualifiedTestRepository _dependentDisqualifiedTestRepository;
        private readonly ICorporateUploadHelper _corporateUploadHelper;

        public EventCustomerPreApprovedTestService(
            IEventCustomerPreApprovedTestRepository eventCustomerPreApprovedTestRepository,
            IPreApprovedTestRepository preApprovedTestRepository,
            IEventCustomerRepository eventCustomerRepository,
            IEventCustomerPreApprovedPackageTestRepository eventCustomerPreApprovedPackageTestRepository,
            IPreApprovedPackageRepository preApprovedPackageRepository,
            IPackageTestRepository packageTestRepository,
            IOrderRepository orderRepository,
            IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository,
            IEventRepository eventRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IInsurancePaymentRepository insurancePaymentRepository,
            ICustomerOrderHistoryService customerOrderHistoryService, IDisqualifiedTestRepository disqualifiedTestRepository, IDependentDisqualifiedTestRepository dependentDisqualifiedTestRepository, ICorporateUploadHelper corporateUploadHelper)
        {
            _eventCustomerPreApprovedTestRepository = eventCustomerPreApprovedTestRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventCustomerPreApprovedPackageTestRepository = eventCustomerPreApprovedPackageTestRepository;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _packageTestRepository = packageTestRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _eventRepository = eventRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _insurancePaymentRepository = insurancePaymentRepository;
            _customerOrderHistoryService = customerOrderHistoryService;
            _disqualifiedTestRepository = disqualifiedTestRepository;
            _dependentDisqualifiedTestRepository = dependentDisqualifiedTestRepository;
            _corporateUploadHelper = corporateUploadHelper;
        }

        public void UpdateEventCustomerPreApprovedTest(long eventId, long customerId)
        {
            var preApprovedTest = _preApprovedTestRepository.GetByCustomerId(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var preApprovedPackages = _preApprovedPackageRepository.GetByCustomerId(customerId);

            if (preApprovedTest != null && preApprovedTest.Any() && eventCustomer != null)
            {
                _eventCustomerPreApprovedTestRepository.Save(eventCustomer.Id, preApprovedTest.Select(x => x.TestId));
            }

            _eventCustomerPreApprovedPackageTestRepository.DeletePreApprovedPackageTests(eventCustomer.Id);

            if (preApprovedPackages != null && preApprovedPackages.Any())
            {
                foreach (var preApprovedPackage in preApprovedPackages)
                {
                    var preApprovedPacakgeTests = _packageTestRepository.GetbyPackageId(preApprovedPackage.PackageId);
                    if (preApprovedPacakgeTests != null && preApprovedPacakgeTests.Any())
                    {
                        _eventCustomerPreApprovedPackageTestRepository.Save(eventCustomer.Id, preApprovedPackage.PackageId, preApprovedPacakgeTests.Select(x => x.TestId));
                    }
                }
            }
        }

        public IEnumerable<EventCustomer> GetFutureEventCustomers(long customerId, bool isTodayIncluded = true)
        {
            return _eventCustomerRepository.GetEventCustomerForFurtureEventsByCustomerId(customerId, isTodayIncluded);
        }

        public IEnumerable<EventCusomerAdjustOrderViewModel> MarkcustomerForAdjustOrder(CorporateCustomerEditModel model, IEnumerable<EventCustomer> eventCustomers, long createdByOrgRoleUserId, long customerId, long? corporateUploadId)
        {
            var pairs = TestType.A1C.GetNameValuePairs();

            var preApprovedTestIds = model.PreApprovedTest.IsNullOrEmpty() ? new long[0] : pairs.Where(x => model.PreApprovedTest.Contains(x.SecondValue.ToLower())).Select(x => (long)x.FirstValue).ToArray();

            preApprovedTestIds = _corporateUploadHelper.RemoveFocFromPreApprovedTest(preApprovedTestIds.ToList()).ToArray();

            var eventIds = eventCustomers.Select(x => x.EventId);

            var events = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(eventIds);

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(x => x.Id));

            var orderIds = orders.Select(o => o.Id).ToArray();

            var orderEventPackageIdPairs = _eventPackageRepository.GetEventPackageIdsForOrder(orderIds); // orderId, EventPackaegId
            var eventPacakageTestIds = _eventPackageRepository.GetOrderIdEventPackageTestIdPairsForOrder(orderIds); //orderId, TestId(package test)
            var orderIdTestIdPairs = _eventTestRepository.GetOrderIdTestIdPairsForOrders(orderIds); // orderId, TestId

            var eventPackageIds = orderEventPackageIdPairs.Select(pair => pair.SecondValue).ToArray();

            var eventPackages = _eventPackageRepository.GetByIds(eventPackageIds).ToArray();

            var list = new List<EventCusomerAdjustOrderViewModel>();

            foreach (var eventCustomer in eventCustomers)
            {
                var order = orders.FirstOrDefault(x => x.CustomerId == eventCustomer.CustomerId && x.EventId == eventCustomer.EventId);

                if (order == null) continue;

                var theEvent = events.First(s => s.Id == eventCustomer.EventId);

                var eventPackagePair = orderEventPackageIdPairs.FirstOrDefault(x => x.FirstValue == order.Id);
                var preApprovedPackageUpdated = IsPreApprovedPackageUpdated(eventPackagePair, eventPackages, order, model.PreApprovedPackageId);
                var testIdInPackage = new List<long>();
                if (eventPackagePair != null)
                {
                    testIdInPackage = eventPacakageTestIds.Where(x => x.FirstValue == eventPackagePair.FirstValue).Select(s => s.SecondValue).ToList();
                }

                var preApprovedTestNotInOrder = PreApprovedTestUpdated(orderIdTestIdPairs, order, preApprovedTestIds, testIdInPackage);
                var preApprovedTestToUpdate = string.Empty;

                if (preApprovedTestNotInOrder != null)
                    preApprovedTestToUpdate = string.Join(",", preApprovedTestNotInOrder.Select(x => ((TestType)x).ToString()));

                if (preApprovedPackageUpdated || !preApprovedTestNotInOrder.IsNullOrEmpty())
                {
                    list.Add(new EventCusomerAdjustOrderViewModel
                    {
                        CustomerId = eventCustomer.CustomerId,
                        EventId = eventCustomer.EventId,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        MemberId = model.MemberId,
                        EventDate = theEvent.EventDate,
                        PreApprovedPackageToAdjust = preApprovedPackageUpdated ? model.PreApprovedPackage : string.Empty,
                        PreApprovedTestsToAdjust = preApprovedTestToUpdate
                    });


                    long newPackageId = 0;
                    long oldPackageId = 0;

                    if (preApprovedPackageUpdated)
                    {
                        newPackageId = model.PreApprovedPackageId;
                    }

                    if (eventPackagePair != null)
                    {
                        var package = eventPackages.First(x => x.Id == eventPackagePair.SecondValue).Package;
                        oldPackageId = package.Id;
                    }

                    var orderedTestIds = orderIdTestIdPairs.Where(x => x.FirstValue == order.Id).Select(x => x.SecondValue);

                    AdjustCustomerOrder(eventCustomer, order, newPackageId, oldPackageId, createdByOrgRoleUserId, customerId, orderedTestIds,
                        preApprovedTestIds, testIdInPackage, corporateUploadId.HasValue ? corporateUploadId.Value : 0);
                }
            }

            return list.IsNullOrEmpty() ? null : list;
        }

        private IEnumerable<long> PreApprovedTestUpdated(IEnumerable<OrderedPair<long, long>> orderEventTestIds, Order order, IEnumerable<long> preApprovedTestIds, IEnumerable<long> testIdsInPackage)
        {
            if (preApprovedTestIds.IsNullOrEmpty()) return preApprovedTestIds;

            var eventTestIdPairs = orderEventTestIds.Where(o => o.FirstValue == order.Id).ToList();

            if (eventTestIdPairs.IsNullOrEmpty() && testIdsInPackage.IsNullOrEmpty()) return preApprovedTestIds;

            var testIdsInOrder = eventTestIdPairs.Select(s => s.SecondValue);

            if (!testIdsInOrder.IsNullOrEmpty())
                testIdsInOrder = testIdsInPackage.Concat(testIdsInOrder);
            List<long> lstTestIdsInOrder = testIdsInOrder.ToList();

            foreach (var testId in testIdsInOrder)
            {
                if (!preApprovedTestIds.Contains(testId))
                {
                    lstTestIdsInOrder.Remove(testId);
                }
            }

            lstTestIdsInOrder.AddRange(preApprovedTestIds);
            // var testNotInOrder = preApprovedTestIds.Where(x => !testIdsInOrder.Contains(x));
            // var testNotInOrder = preApprovedTestIds;

            return lstTestIdsInOrder.IsNullOrEmpty() ? null : lstTestIdsInOrder.Distinct();
        }

        private bool IsPreApprovedPackageUpdated(OrderedPair<long, long> eventPackagePair, IEnumerable<EventPackage> eventPackages, Order order, long preApprovedPackageId)
        {
            if (preApprovedPackageId <= 0) return false;

            if (eventPackagePair == null) return true;

            var package = eventPackages.First(x => x.Id == eventPackagePair.SecondValue).Package;

            return package.Id != preApprovedPackageId;
        }

        private bool AdjustCustomerOrder(EventCustomer eventCustomer, Order currentOrder, long newPackageId, long oldPackageId, long createdByOrgRoleUserId,
            long customerId, IEnumerable<long> orderedTestIds, IEnumerable<long> preApprovedTestIds, IEnumerable<long> packageTestIds, long corporateUploadId)
        {
            if (corporateUploadId == 0) return false;

            if (currentOrder != null && !currentOrder.OrderDetails.IsEmpty())
            {
                if (eventCustomer == null) return false;

                var OrderId = currentOrder.Id;

                var forOrganizationRoleUser = GetForOrganizationRoleUser(customerId);

                IOrderController orderController = new Falcon.App.Infrastructure.Finance.Impl.OrderController();
                var currentPreApprovedTest = _preApprovedTestRepository.GetByCustomerId(customerId);

                if (IsOldPreApprovedTestSame(currentPreApprovedTest.Select(x => x.TestId), preApprovedTestIds))
                {
                    return false;
                }

                // var selectedTestIds = orderedTestIds.ToList();
                var selectedTestIds = new List<long>();

                //if (!currentPreApprovedTest.IsNullOrEmpty())
                //{
                //    var testIdToRemove = currentPreApprovedTest.Select(x => x.TestId);
                //    selectedTestIds = selectedTestIds.Where(x => !testIdToRemove.Contains(x)).ToList();
                //}

                //if (newPackageId != oldPackageId && oldPackageId != 0)
                //{
                //    selectedTestIds = selectedTestIds.Where(x => !packageTestIds.Contains(x)).ToList();
                //}

                selectedTestIds.AddRange(preApprovedTestIds);

                var orderables = new List<IOrderable>();
                long oldEventPackageId = 0;
                long newEventPackageId = 0;
                var oldEventTestIds = new List<long>();
                var newEventTestIds = new List<long>();
                EventPackage eventPackage = null;
                EventPackage oldEventPackage = null;

                if (newPackageId > 0)
                    eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventCustomer.EventId, newPackageId);

                if (oldPackageId > 0)
                    oldEventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventCustomer.EventId, oldPackageId);

                var testIdsInPackage = new List<long>();

                if (eventPackage != null)
                {
                    orderables.Add(eventPackage);
                    newEventPackageId = eventPackage.Id;
                    RemoveTestsAlreadyInPackage(selectedTestIds.ToList(), eventCustomer.EventId, eventPackage);
                    testIdsInPackage = eventPackage.Package.Tests.Select(x => x.Id).ToList();
                }

                if (oldEventPackage != null)
                {
                    oldEventPackageId = oldEventPackage.Id;
                    if (eventPackage == null)
                    {
                        orderables.Add(oldEventPackage);
                        RemoveTestsAlreadyInPackage(selectedTestIds.ToList(), eventCustomer.EventId, oldEventPackage);
                        testIdsInPackage = oldEventPackage.Package.Tests.Select(x => x.Id).ToList();
                    }
                }

                var oldEventTests = _eventTestRepository.GetByEventAndTestIds(eventCustomer.EventId, orderedTestIds);
                if (oldEventTests != null)
                {
                    oldEventTestIds = oldEventTests.Select(x => x.Id).ToList();
                }

                var disqualifiedTestIds = _disqualifiedTestRepository.GetLatestVersionTestId(eventCustomer.CustomerId, eventCustomer.EventId);
                var dependentDisqualifiedTestIds = _dependentDisqualifiedTestRepository.GetLatestVersionTestId(eventCustomer.CustomerId, eventCustomer.EventId);
                disqualifiedTestIds = (disqualifiedTestIds.Concat(dependentDisqualifiedTestIds)).Distinct();

                //removing disqualified test from new order
                selectedTestIds = selectedTestIds.Where(x => !disqualifiedTestIds.Contains(x)).ToList();

                //remove test which are already present in package test
                selectedTestIds = selectedTestIds.Where(x => !testIdsInPackage.Intersect(selectedTestIds).Contains(x)).ToList();

                if (!selectedTestIds.IsNullOrEmpty())
                {
                    var eventTests = _eventTestRepository.GetByEventAndTestIds(eventCustomer.EventId, selectedTestIds);
                    if (newPackageId > 0 || oldPackageId > 0)
                    {
                        foreach (var eventTest in eventTests)
                        {
                            eventTest.Price = eventTest.WithPackagePrice;
                        }
                    }

                    orderables.AddRange(eventTests);
                    newEventTestIds = eventTests.Select(x => x.Id).ToList();
                }

                if (((oldEventPackageId > 0 && newEventPackageId == 0) || (newEventPackageId == oldEventPackageId)) && (newEventTestIds.All(oldEventTestIds.Contains) && newEventTestIds.Count == oldEventTestIds.Count))
                {
                    return false;
                }

                if (orderables.IsNullOrEmpty()) return false;

                var insurancePayment = currentOrder.PaymentsApplied.Where(pi => pi.PaymentType == Falcon.App.Core.Finance.Enum.PaymentType.Insurance).Select(pi => pi).SingleOrDefault();
                if (insurancePayment != null)
                {
                    _insurancePaymentRepository.Delete(insurancePayment.Id);
                }

                bool indentedLineItemsAdded = false;

                foreach (var orderable in orderables)
                {
                    if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                    {
                        orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, createdByOrgRoleUserId,
                                               null,
                                               null, null, OrderStatusState.FinalSuccess);
                        indentedLineItemsAdded = true;
                    }
                    else
                        orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, createdByOrgRoleUserId,
                                                OrderStatusState.FinalSuccess);
                }

                Order newOrder = orderController.PlaceOrder(currentOrder);

                _customerOrderHistoryService.SaveCustomerOrderHistory(eventCustomer, corporateUploadId, oldEventPackageId, newEventPackageId, oldEventTestIds, newEventTestIds);
                return true;
            }
            return false;
        }

        private void RemoveTestsAlreadyInPackage(List<long> selectedTestIds, long eventId, EventPackage eventPackage)
        {
            var package = eventPackage != null ? eventPackage.Package : null;

            if (package != null && !selectedTestIds.IsNullOrEmpty())
            {
                var packageTestIds = package.Tests.Select(t => t.Id);
                selectedTestIds.RemoveAll(t => packageTestIds.Contains(t));
            }
        }

        private OrganizationRoleUser GetForOrganizationRoleUser(long customerId)
        {
            var orgRolesUser = _organizationRoleUserRepository.GetOrganizationRoleUser(customerId);
            if (orgRolesUser != null && orgRolesUser.RoleId == (long)Roles.Customer)
                return orgRolesUser;
            return null;
        }

        private void UpdateCustomerPreApprovedForFutureEvents(IEnumerable<EventCustomer> eventCustomers, CorporateCustomerEditModel customerEditModel)
        {
            if (!eventCustomers.IsNullOrEmpty())
            {
                var pairs = TestType.A1C.GetNameValuePairs();

                var preApprovedTestIds = customerEditModel.PreApprovedTest.IsNullOrEmpty() ? new long[0] : pairs.Where(x => customerEditModel.PreApprovedTest.Contains(x.SecondValue.ToLower())).Select(x => (long)x.FirstValue).ToArray();


                foreach (var eventCustomer in eventCustomers)
                {
                    if (!preApprovedTestIds.IsNullOrEmpty())
                    {
                        _eventCustomerPreApprovedTestRepository.Save(eventCustomer.Id, preApprovedTestIds);
                    }

                    if (customerEditModel.PreApprovedPackageId > 0)
                    {
                        var preApprovedPacakgeTests = _packageTestRepository.GetbyPackageId(customerEditModel.PreApprovedPackageId);

                        if (preApprovedPacakgeTests != null && preApprovedPacakgeTests.Any())
                        {
                            _eventCustomerPreApprovedPackageTestRepository.Save(eventCustomer.Id, customerEditModel.PreApprovedPackageId, preApprovedPacakgeTests.Select(x => x.TestId));
                        }
                    }
                }
            }
        }

        private void UpdateCustomerPreApprovedPackges(CorporateCustomerEditModel model, long createdByOrgRoleUserId, long customerId)
        {
            if (model.PreApprovedPackageId > 0)
            {
                _preApprovedPackageRepository.SavePreApprovedPackages(customerId, model.PreApprovedPackageId, createdByOrgRoleUserId);
            }
        }

        private void UpateCustomerPreApprovedTest(CorporateCustomerEditModel model, long createdByOrgRoleUserId, long customerId)
        {
            if (model.PreApprovedTest != null && model.PreApprovedTest.Any())
            {
                var pairs = TestType.A1C.GetNameValuePairs();
                var preApprovedTestIds =
                    pairs.Where(x => model.PreApprovedTest.Contains(x.SecondValue.ToLower())).Select(x => (long)x.FirstValue);

                if (preApprovedTestIds != null && preApprovedTestIds.Any())
                {
                    _preApprovedTestRepository.SavePreApprovedTests(customerId, preApprovedTestIds,
                        createdByOrgRoleUserId);
                }

            }
        }

        private bool IsOldPreApprovedTestSame(IEnumerable<long> oldTests, IEnumerable<long> newTests)
        {
            var firstNotSecond = oldTests.Except(newTests).ToList();
            var secondNotFirst = newTests.Except(oldTests).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}