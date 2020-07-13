using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation(Interface = typeof(ITechnicalLimitedScreeningCustomerFactory))]
    public class TechnicalLimitedScreeningCustomerFactory : ITechnicalLimitedScreeningCustomerFactory
    {
        public TechnicalLimitedScreeningCustomerListModel Create(IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, IEnumerable<Pod> pods, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> ecAndPackagePair,
            IEnumerable<OrderedPair<long, string>> ecAndTestPair, IEnumerable<TestUnabletoScreenViewModel> unableToScreenViewModel, bool isNewResultFlow)
        {
            var listModel = new TechnicalLimitedScreeningCustomerListModel();
            var customerViewModel = new List<TechnicalLimitedScreeningCustomerViewModel>();

            foreach (EventCustomerResult eventCustomerResult in eventCustomerResults)
            {
                var theEvent = events.Where(e => e.Id == eventCustomerResult.EventId).Single();
                var customer = customers.Where(c => c.CustomerId == eventCustomerResult.CustomerId).Single();
                var podNames = string.Join(", ", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => p.Name));
                var packagename = ecAndPackagePair.Where(p => p.FirstValue == eventCustomerResult.Id).Select(p => p.SecondValue).SingleOrDefault();
                var tests = string.Join(", ", ecAndTestPair.Where(p => p.FirstValue == eventCustomerResult.Id).Select(p => p.SecondValue).ToArray());
                var phone = ((customer.HomePhoneNumber ?? customer.OfficePhoneNumber) ?? customer.MobilePhoneNumber);

                if (string.IsNullOrEmpty(packagename)) packagename = tests;
                else if (!string.IsNullOrEmpty(tests)) packagename += " + " + tests;

                var viewModel = new TechnicalLimitedScreeningCustomerViewModel
                                {
                                    Address = Mapper.Map<Address, AddressViewModel>(customer.Address),
                                    EventCustomerResultId = eventCustomerResult.Id,
                                    EventId = theEvent.Id,
                                    EventName = theEvent.Name,
                                    CustomerId = customer.CustomerId,
                                    EventDate = theEvent.EventDate,
                                    Pod = podNames,
                                    CustomerOrder = packagename,
                                    CustomerName = customer.NameAsString,
                                    Email = customer.Email != null ? customer.Email.ToString() : "",
                                    Phone = phone != null ? phone.ToString() : "",
                                    Test = unableToScreenViewModel.Where(uv => uv.EventCustomerResultId == eventCustomerResult.Id).OrderBy(uv => uv.TestId).ToArray()
                                };
                if (isNewResultFlow)
                {
                    viewModel.CurrentState = ((NewTestResultStateNumber)eventCustomerResult.ResultState).GetNewPresentationfromResultState(eventCustomerResult.IsPartial, eventCustomerResult.SignedOffBy.HasValue);
                }
                else
                {
                    viewModel.CurrentState = ((TestResultStateNumber)eventCustomerResult.ResultState).GetPresentationfromResultState(eventCustomerResult.IsPartial);
                }


                customerViewModel.Add(viewModel);
            }

            listModel.Collection = customerViewModel;
            return listModel;
        }
    }
}