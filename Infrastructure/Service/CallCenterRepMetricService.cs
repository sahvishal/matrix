using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.Impl;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Service
{
    public class CallCenterRepMetricService : ICallCenterRepMetricService
    {
        private readonly ICallCenterRepMetricDetailRepository _callCenterRepMetricDetailRepository;
        private readonly ICallCenterRepMetricDetailViewDataFactory _callCenterRepMetricDetailFactory;
        private readonly ICallCenterRepSpouseMetricDetailViewDataFactory _callCenterRepSpouseMetricDetailViewDataFactory;
        private readonly IEventCustomerRegistrationViewDataRepository _eventCustomerAggregateRepository;
        private readonly ICallCenterRepRepository _callCenterRepRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUniqueItemRepository<EventCustomer> _eventCustomerRepository;
        private readonly ICallCenterRepSpouseStatisticsViewDataFactory _callCenterRepSpouseStatisticsViewDataFactory;

        public CallCenterRepMetricService(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            _callCenterRepMetricDetailRepository = new CallCenterRepMetricDetailRepository(callCenterCallCenterUserId,
                                                                                     startDate,
                                                                                     endDate);
            _callCenterRepMetricDetailFactory = new CallCenterRepMetricDetailViewDataFactory();
            _callCenterRepSpouseMetricDetailViewDataFactory = new CallCenterRepSpouseMetricDetailViewDataFactory();
            _eventCustomerAggregateRepository = new EventCustomerRegistrationViewDataRepository();
            _callCenterRepRepository = new CallCenterRepRepository();
            _orderRepository = new OrderRepository();
            _eventCustomerRepository = new EventCustomerRepository();
            _callCenterRepSpouseStatisticsViewDataFactory = new CallCenterRepSpouseStatisticsViewDataFactory();
        }


        public List<CallCenterRepMetricDetailViewData> GetBookingCallCenterRepMetricDetailsViewData(long callCenterCallCenterUserId,
            DateTime startDate, DateTime endDate, int pageIndex, int pageSize, out int totalCount)
        {
            var eventCustomerIds =
                _callCenterRepMetricDetailRepository.GetBookedEventCustomersByCallCenterRep(callCenterCallCenterUserId, startDate,
                                                                                   endDate);
            var eventCustomers = _eventCustomerAggregateRepository.GetEventCustomerOrders(eventCustomerIds);

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var callCenterRep = _callCenterRepRepository.GetCallCenterRep(callCenterCallCenterUserId);

            var metricDetailList =
                _callCenterRepMetricDetailFactory.CreateCallCenterRepMetricDetailViewData(eventCustomers, orders,
                                                                                          callCenterRep);
            totalCount = metricDetailList.Count;
            return totalCount >= ((pageIndex * pageSize) + pageSize)
                       ? metricDetailList.GetRange((pageIndex * pageSize), pageSize)
                       : metricDetailList.GetRange((pageIndex * pageSize), totalCount - (pageIndex * pageSize));
        }

        public List<CallCenterRepMetricDetailViewData> GetClosingCallCenterRepMetricDetailsViewData(long callCenterRepId,
            DateTime startDate, DateTime endDate, int pageIndex, int pageSize, out int totalCount)
        {
            var eventCustomerIds =
                _callCenterRepMetricDetailRepository.GetClosedEventCustomersByCallCenterRep(callCenterRepId,
                                                                                      startDate, endDate);
            var eventCustomers = _eventCustomerAggregateRepository.GetEventCustomerOrders(eventCustomerIds);
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var callCenterRep = _callCenterRepRepository.GetCallCenterRep(callCenterRepId);

            var metricDetailList =
                _callCenterRepMetricDetailFactory.CreateCallCenterRepMetricDetailViewData(eventCustomers, orders,
                                                                                          callCenterRep);
            totalCount = metricDetailList.Count;
            return totalCount >= ((pageIndex * pageSize) + pageSize)
                       ? metricDetailList.GetRange((pageIndex * pageSize), pageSize)
                       : metricDetailList.GetRange((pageIndex * pageSize), totalCount - (pageIndex * pageSize));
        }

        public List<CallCenterRepMetricDetailViewData> GetAsrCallCenterRepMetricDetailsViewData(long callCenterCallCenterUserId,
            DateTime startDate, DateTime endDate, int pageIndex, int pageSize, out int totalCount)
        {
            var eventCustomerIds =
                _callCenterRepMetricDetailRepository.GetBookedEventCustomersByCallCenterRep(callCenterCallCenterUserId,
                                                                                      startDate, endDate);
            var eventCustomers = _eventCustomerAggregateRepository.GetEventCustomerOrders(eventCustomerIds);
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var callCenterRep = _callCenterRepRepository.GetCallCenterRep(callCenterCallCenterUserId);

            var metricDetailList =
                _callCenterRepMetricDetailFactory.CreateCallCenterRepMetricDetailViewData(eventCustomers, orders,
                                                                                          callCenterRep);
            totalCount = metricDetailList.Count;
            return totalCount >= ((pageIndex * pageSize) + pageSize)
                       ? metricDetailList.GetRange((pageIndex * pageSize), pageSize)
                       : metricDetailList.GetRange((pageIndex * pageSize), totalCount - (pageIndex * pageSize));
        }

        public CallCenterRepSpouseStatisticsViewData GetSpouseBookingStatistics(long callCenterCallCenterUserId,
            DateTime startDate, DateTime endDate)
        {
            var eventCustomerIdPairs =
                _callCenterRepMetricDetailRepository.GetAllSpouseEventCustomerPairs(callCenterCallCenterUserId,
                                                                                    startDate,
                                                                                    endDate);

            int totalCustomers,
                totalCustomerPairs,
                totalCancelledCustomers,
                totalCancelledCustomerPairs,
                totalNoShowCustomers,
                totalNoShowCustomerPairs,
                totalAttendedCustomers,
                totalAttendedCustomerPairs,
                totalCustomerCountForSales;
            totalCustomers =
                totalCustomerPairs =
                totalCancelledCustomers =
                totalCancelledCustomerPairs = totalNoShowCustomers = totalNoShowCustomerPairs = totalAttendedCustomers =
                                                                                                totalAttendedCustomerPairs
                                                                                                =
                                                                                                totalCustomerCountForSales
                                                                                                = 0;
            decimal totalAmount = 0m;

            foreach (var eventCustomerIdPair in eventCustomerIdPairs)
            {
                var ownerEventCustomer = _eventCustomerRepository.GetById(eventCustomerIdPair.FirstValue);
                var spouseEventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIdPair.SecondValue);

                totalCustomers += 1 + spouseEventCustomers.Count();
                totalCustomerPairs++;

                var priceToBeAdded = true;

                // Now we are calculating cancelled records
                if (!ownerEventCustomer.AppointmentId.HasValue || spouseEventCustomers.Any(ec => !ec.AppointmentId.HasValue))
                {
                    totalCancelledCustomerPairs++;
                    totalCancelledCustomers += !ownerEventCustomer.AppointmentId.HasValue ? 1 : 0;
                    totalCancelledCustomers += spouseEventCustomers.Any(ec => !ec.AppointmentId.HasValue)
                                                   ? spouseEventCustomers.Count(ec => !ec.AppointmentId.HasValue)
                                                   : 0;
                    if (!ownerEventCustomer.AppointmentId.HasValue || spouseEventCustomers.All(ec => !ec.AppointmentId.HasValue))
                        priceToBeAdded = false;
                }
                // Now we are calculating NoShow records
                if (ownerEventCustomer.NoShow || spouseEventCustomers.Any(ec => ec.NoShow))
                {
                    totalNoShowCustomerPairs++;
                    totalNoShowCustomers += ownerEventCustomer.NoShow ? 1 : 0;
                    totalNoShowCustomers += spouseEventCustomers.Any(ec => ec.NoShow)
                                                   ? spouseEventCustomers.Count(ec => ec.NoShow)
                                                   : 0;
                    if (ownerEventCustomer.NoShow || spouseEventCustomers.All(ec => ec.NoShow))
                        priceToBeAdded = false;
                }
                // Finally get the total attended customer count and only in this case we need to add the amount.
                if (ownerEventCustomer.TestConducted && spouseEventCustomers.Any(ec => ec.TestConducted))
                {
                    totalAttendedCustomerPairs++;
                    totalAttendedCustomers += ownerEventCustomer.TestConducted ? 1 : 0;
                    totalAttendedCustomers += spouseEventCustomers.Any(ec => ec.TestConducted)
                                                   ? spouseEventCustomers.Count(ec => ec.TestConducted)
                                                   : 0;
                }
                if (priceToBeAdded)
                {
                    var eventCustomerIds =
                        spouseEventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow).Select(ec => ec.Id).
                            ToList();
                    eventCustomerIds.Add(ownerEventCustomer.Id);
                    var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);
                    totalAmount += orders.Sum(o => o.DiscountedTotal);
                    totalCustomerCountForSales += orders.Count();
                }
            }
            return new CallCenterRepSpouseStatisticsViewData(totalCustomerPairs, totalCancelledCustomerPairs,
                                                             totalNoShowCustomerPairs, totalAttendedCustomerPairs,
                                                             totalCustomers, totalCancelledCustomers,
                                                             totalNoShowCustomers, totalAttendedCustomers,
                                                             totalCustomerCountForSales, totalAmount);
        }
    }
}
