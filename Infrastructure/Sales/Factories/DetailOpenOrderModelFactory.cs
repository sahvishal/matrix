using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation]
    public class DetailOpenOrderModelFactory : IDetailOpenOrderModelFactory
    {
        public DetailOpenOrderListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, int>> bookedSlots, IEnumerable<OrderedPair<long, int>> unservicedAppts,
            IEnumerable<OrderedPair<long, int>> noShowAppts, IEnumerable<OrderedPair<long, int>> cancelledAppts, IEnumerable<OrderedPair<long, decimal>> eventIdOpenOrderTotalPairs,
            IEnumerable<OrderedPair<long, decimal>> eventIdTotalOutstandingRevenuePairs, IEnumerable<OrderedPair<long, decimal>> eventIdNoShowOutstandingRevenuePairs, IEnumerable<OrderedPair<long, decimal>> eventIdCancelledOutstandingRevenuePairs)
        {
            var model = new DetailOpenOrderListModel();
            var detailOpenOrdersModels = new List<DetailOpenOrdersModel>();

            events.ToList().ForEach(e =>
                                        {
                                            var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();

                                            var eventPods = pods.Where(p => e.PodIds.Contains(p.Id)).ToList();
                                            var slotCount = bookedSlots.Where(bs => bs.FirstValue == e.Id).FirstOrDefault().SecondValue;
                                            var unservicedAppt = unservicedAppts.Where(ua => ua.FirstValue == e.Id).Select(ua => ua.SecondValue).SingleOrDefault();
                                            var noShowAppt = noShowAppts.Where(ns => ns.FirstValue == e.Id).Select(ns => ns.SecondValue).SingleOrDefault();
                                            var cencelledAppt = cancelledAppts.Where(ca => ca.FirstValue == e.Id).Select(ca => ca.SecondValue).SingleOrDefault();
                                            var orderAmount = eventIdOpenOrderTotalPairs.Where(eo => eo.FirstValue == e.Id).Select(eo => eo.SecondValue).SingleOrDefault();
                                            var totalOutstandingRevenue = eventIdTotalOutstandingRevenuePairs.Where(or => or.FirstValue == e.Id).Select(or => or.SecondValue).SingleOrDefault();
                                            var noShowOutstandingRevenue = eventIdNoShowOutstandingRevenuePairs.Where(or => or.FirstValue == e.Id).Select(or => or.SecondValue).SingleOrDefault();
                                            var cancelledOutstandingRevenue = eventIdCancelledOutstandingRevenuePairs.Where(or => or.FirstValue == e.Id).Select(or => or.SecondValue).SingleOrDefault();

                                            detailOpenOrdersModels.Add(new DetailOpenOrdersModel()
                                                                           {
                                                                               EventDate = e.EventDate,
                                                                               Location = host.OrganizationName + " - " + host.Address.City + ", " + host.Address.State,
                                                                               Pod =
                                                                                   string.Join(", ",
                                                                                               eventPods.Select(
                                                                                                   ep => ep.Name)),
                                                                               OpenOrderTotal = orderAmount,
                                                                               OutstandingUnservicedRevenue = totalOutstandingRevenue - cancelledOutstandingRevenue,
                                                                               OutstandingNoShowRevenue = noShowOutstandingRevenue,
                                                                               OutstandingCancelledRevenue = cancelledOutstandingRevenue,
                                                                               OutstandingTotalRevenue = totalOutstandingRevenue,
                                                                               UnPaid = orderAmount - totalOutstandingRevenue,
                                                                               ScheduledAppointments = slotCount,
                                                                               UnServicedAppointments = unservicedAppt,
                                                                               NoShowAppointments = noShowAppt,
                                                                               CancelledAppointments = cencelledAppt,
                                                                               EventId = e.Id

                                                                           });

                                        });

            model.Collection = detailOpenOrdersModels;
            return model;
        }

        public CustomerOpenOrderListModel CreateCustomerOpenOrder(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<Customer> customers,
            IEnumerable<OrderedPair<long, decimal>> eventCustomerIdOpenOrderTotalPairs, IEnumerable<OrderedPair<long, decimal>> eventCustomerIdRevenuePairs, IEnumerable<OrderedPair<long,long>> orderIdEventCustomerIdPairs)
        {
            var model = new CustomerOpenOrderListModel();
            var customerOpenOrders = new List<CustomerOpenOrderViewModel>();

            eventCustomers.ToList().ForEach(ec =>
                                                {
                                                    var eventData = events.Where(e => e.Id == ec.EventId).First();
                                                    var host = hosts.Where(h => h.Id == eventData.HostId).First();
                                                    var eventPods = pods.Where(p => eventData.PodIds.Contains(p.Id)).ToList();
                                                    var customer = customers.Where(c => c.CustomerId == ec.CustomerId).First();
                                                    var orderTotal = eventCustomerIdOpenOrderTotalPairs.Where(ot => ot.FirstValue == ec.Id).Select(ot => ot.SecondValue).FirstOrDefault();
                                                    var revenue = eventCustomerIdRevenuePairs.Where(r => r.FirstValue == ec.Id).Select(r => r.SecondValue).FirstOrDefault();
                                                    var orderId = orderIdEventCustomerIdPairs.Where(oe => oe.SecondValue == ec.Id).Select(oe => oe.FirstValue).Single();
                                                    customerOpenOrders.Add(new CustomerOpenOrderViewModel
                                                                               {
                                                                                   CustomerId = customer.CustomerId,
                                                                                   CustomerName = customer.Name,
                                                                                   EventId = eventData.Id,
                                                                                   EventDate = eventData.EventDate,
                                                                                   Location = host.OrganizationName + " - " + host.Address.City + ", " + host.Address.State,
                                                                                   Pod = string.Join(",", eventPods.Select(ep => ep.Name).ToArray()),
                                                                                   OpenOrderTotal = orderTotal,
                                                                                   OutstandingRevenue = revenue,
                                                                                   UnPaid = orderTotal - revenue,
                                                                                   OrderId = orderId,
                                                                                   Status = ec.AppointmentId.HasValue ? (ec.NoShow ? "Un-serviced - No show" : "Un-serviced") : "Cancelled"
                                                                               });
                                                });
            model.Collection = customerOpenOrders;
            return model;
        }
    }
}
