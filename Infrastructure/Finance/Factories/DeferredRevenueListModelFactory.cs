using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance;
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
    public class DeferredRevenueListModelFactory : IDeferredRevenueListModelFactory
    {
        public DeferredRevenueListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<Pod> pods, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> ecAndPackagePair,
            IEnumerable<OrderedPair<long, string>> ecAndTestPair, IEnumerable<OrderedPair<long, long>> orderIdEventCustomerIdPairs, IEnumerable<Host> hosts,
            IEnumerable<DeferredRevenueViewModel> eventRevenueWiseDetails, IEnumerable<OrderedPair<long, decimal>> eventCustomerIdOrderTotalPairs, IEnumerable<OrderedPair<long, decimal>> eventCustomerIdTotalPaymentPairs)
        {
            var listModel = new DeferredRevenueListModel();
            var collection = new List<DeferredRevenueViewModel>();
            foreach (var @event in events)
            {
                var podNames = string.Join(", ", pods.Where(p => @event.PodIds.Contains(p.Id)).Select(p => p.Name));
                var host = hosts.Where(h => h.Id == @event.HostId).First();
                var viewModel = eventRevenueWiseDetails != null ? eventRevenueWiseDetails.Where(e => e.EventId == @event.Id).SingleOrDefault() : null;

                if (viewModel == null)
                {
                    viewModel = new DeferredRevenueViewModel
                                    {
                                        EventId = @event.Id,
                                        EventName = @event.Name,
                                        EventDate = @event.EventDate,
                                        EventAddress = Mapper.Map<Address, AddressViewModel>(host.Address),
                                        Pod = podNames,
                                        TotalLiability = 0
                                    };
                }
                else
                {
                    viewModel.EventName = @event.Name;
                    viewModel.EventDate = @event.EventDate;
                    viewModel.EventAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
                    viewModel.Pod = podNames;
                }

                var customerModels = new List<DeferredRevenueCustomerViewModel>();
                var customersOfTheEvent = eventCustomers.Where(ec => ec.EventId == @event.Id);
                foreach (var eventCustomer in customersOfTheEvent)
                {
                    var customer = customers.Where(c => c.CustomerId == eventCustomer.CustomerId).Single();
                    
                    var packagename =
                        string.Join(", ", ecAndPackagePair.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).ToArray());

                    var tests = string.Join(", ", ecAndTestPair.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).ToArray());

                    if (string.IsNullOrEmpty(packagename))
                        packagename = tests;
                    else if (!string.IsNullOrEmpty(tests))
                        packagename += " + " + tests;

                    var orderId =
                        orderIdEventCustomerIdPairs.Where(oe => oe.SecondValue == eventCustomer.Id).Select(oe => oe.FirstValue).Single();

                    var eventCustomerIdOrderTotalPair = eventCustomerIdOrderTotalPairs.Where(ecot => ecot.FirstValue == eventCustomer.Id).Single();

                    var eventCustomerIdTotalPaymentPair = eventCustomerIdTotalPaymentPairs.Where(ectp => ectp.FirstValue == eventCustomer.Id).Single();

                    var customerModel = new DeferredRevenueCustomerViewModel
                                        {
                                            CustomerId = customer.CustomerId,
                                            CustomerName = customer.NameAsString,
                                            CustomerPhone = customer.HomePhoneNumber,
                                            Email = customer.Email != null ? customer.Email.ToString() : "",
                                            CustomerAddress = Mapper.Map<Address, AddressViewModel>(customer.Address),
                                            CustomerOrder = packagename,
                                            OrderId = orderId,
                                            DiscountedTotal = eventCustomerIdOrderTotalPair.SecondValue,
                                            TotalPayment = eventCustomerIdTotalPaymentPair.SecondValue,
                                            RegistrationDate = eventCustomer.DataRecorderMetaData.DateCreated
                                        };

                    customerModels.Add(customerModel);
                }
                viewModel.Customers = customerModels;
                collection.Add(viewModel);
            }
            listModel.Collection = collection;
            return listModel;
        }
    }
}
