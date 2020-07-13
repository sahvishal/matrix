using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class ShippingRevenueSummaryListModelFactory : IShippingRevenueSummaryListModelFactory
    {
        public ShippingRevenueSummaryListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, int>> eventIdShippingCountPairs,
            IEnumerable<OrderedPair<long, decimal>> eventIdShippingRevenuePairs)
        {
            var model = new ShippingRevenueSummaryListModel();
            var shippingRevenueSummaryModels = new List<ShippingRevenueSummaryViewModel>();

            events.ToList().ForEach(e =>
                                        {
                                            var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();

                                            var eventPods = pods.Where(p => e.PodIds.Contains(p.Id)).ToList();
                                            var shippingCount = eventIdShippingCountPairs.Where(sc => sc.FirstValue == e.Id).Select(sc => sc.SecondValue).FirstOrDefault();
                                            var shippingRevenue = eventIdShippingRevenuePairs.Where(sc => sc.FirstValue == e.Id).Select(sc => sc.SecondValue).FirstOrDefault();

                                            shippingRevenueSummaryModels.Add(new ShippingRevenueSummaryViewModel
                                                                     {
                                                                         EventId = e.Id,
                                                                         EventDate = e.EventDate,
                                                                         EventName = host.OrganizationName,
                                                                         EventAddress = Mapper.Map<Address, AddressViewModel>(host.Address),
                                                                         Vehicle = string.Join(", ", eventPods.Select(ep => ep.Name)),
                                                                         ShippingCount = shippingCount,
                                                                         Revenue = shippingRevenue,
                                                                     });

                                        });

            model.Collection = shippingRevenueSummaryModels;
            return model;
        }

        public ShippingRevenueDetailListModel CreateShippingRevenueDetail(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<Customer> customers,
            IEnumerable<ShippingDetail> shippingDetails, IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<ShippingOption> shippingOptions, IEnumerable<Order> orders)
        {
            var model = new ShippingRevenueDetailListModel();
            var shippingRevenueDetailModels = new List<ShippingRevenueDetailViewModel>();

            eventCustomers.ToList().ForEach(ec =>
                                                {
                                                    var eventData = events.Where(e => e.Id == ec.EventId).First();
                                                    var host = hosts.Where(h => h.Id == eventData.HostId).First();
                                                    var eventPods = pods.Where(p => eventData.PodIds.Contains(p.Id)).ToList();
                                                    var customer = customers.Where(c => c.CustomerId == ec.CustomerId).First();
                                                    var shippingDetailIds = shippingDetailIdEventCustomerIdPairs.Where(sdec => sdec.SecondValue == ec.Id).Select(sdec => sdec.FirstValue).ToArray();

                                                    var customerShippingDetails = shippingDetails.Where(sd => shippingDetailIds.Contains(sd.Id)).Select(sd => sd).ToArray();
                                                    IEnumerable<string> customerShippingOptions = null;
                                                    var shippingCost = 0.0m;
                                                    if (customerShippingDetails.Count() > 0)
                                                    {
                                                        var shippingoptionIds = customerShippingDetails.Select(csd => csd.ShippingOption.Id).ToArray();
                                                        shippingCost = customerShippingDetails.Sum(sd => sd.ActualPrice);
                                                        customerShippingOptions = shippingOptions.Where(so => shippingoptionIds.Contains(so.Id)).Select(so => so.Name).ToArray();
                                                    }

                                                    bool isPaid = false;
                                                    var order = orders.Where(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId).FirstOrDefault();
                                                    if (order != null)
                                                    {
                                                        isPaid = order.TotalAmountPaid >= order.DiscountedTotal;
                                                    }

                                                    shippingRevenueDetailModels.Add(new ShippingRevenueDetailViewModel
                                                                                        {
                                                                                            CustomerId = customer.CustomerId,
                                                                                            CustomerName = customer.Name,
                                                                                            CustomerAddress = Mapper.Map<Address, AddressViewModel>(customer.Address),
                                                                                            EventId = eventData.Id,
                                                                                            EventDate = eventData.EventDate,
                                                                                            EventName = host.OrganizationName,
                                                                                            EventAddress = Mapper.Map<Address, AddressViewModel>(host.Address),
                                                                                            Vehicle = string.Join(", ", eventPods.Select(ep => ep.Name)),
                                                                                            ShippingOptions = customerShippingOptions,
                                                                                            ShippingCost = shippingCost,
                                                                                            IsPaid = isPaid ? "Yes" : "No"
                                                                                        });
                                                });

            model.Collection = shippingRevenueDetailModels;
            return model;
        }
    }
}
